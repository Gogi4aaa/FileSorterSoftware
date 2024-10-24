using System.Text;

namespace FileSorterSoftware
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
		private string errFile = string.Empty;
        private string dir = string.Empty;
        private string[] filePaths;
        private string[] extensions;
        private void browseButton_Click(object sender, EventArgs e)
        {
            if (!(folderDialog.ShowDialog() == DialogResult.OK)) return;
            
            this.dir = folderDialog.SelectedPath;
            selectedDir.Text = dir;
            this.filePaths = Directory.GetFiles(dir, "*.*",
                SearchOption.TopDirectoryOnly);
            

            if (filePaths.Length == 0)
            {
                selectedDir.Text = string.Empty;
                MessageBox.Show("No files in selected folder!", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }

            this.extensions = this.filePaths
                .Select(x => x.Substring(x.LastIndexOf(".")))
                .Distinct()
                .OrderBy(x => x[1])
                .ToArray();

            extensionsList.Items.Clear();
            extensionsList.Items.AddRange(this.extensions);
        }

        private void sortButton_Click(object sender, EventArgs e)
        {
            progressOutput.Text = string.Empty;

            if (dir.Length == 0)
            {
                MessageBox.Show("No folder selected!", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }
            try
            {
				string[] prefferedExtensions = extensionsList.CheckedItems.Count > 0 ? extensionsList.CheckedItems.OfType<string>().ToArray() : extensions;
				string[] targetFiles = filePaths
					.Where(x => prefferedExtensions
						.Contains(x.Substring(x.LastIndexOf(".")))).ToArray();
				int folderCreated = 0;

				//check if file is opened by another app
				foreach (var targetFile in targetFiles)
				{
					this.errFile = targetFile;
					if (IsFileInUse(targetFile))
					{
						throw new IOException("File is already opened by another application!");
					}
				}
				foreach (var prefferedExtension in prefferedExtensions)
				{
					string dirName = $@"{prefferedExtension.TrimStart('.').ToUpper()} Files";
					string newDir = dir + @"\" + dirName;

					if (!Directory.Exists(newDir))
					{
						Directory.CreateDirectory(newDir);
						progressOutput.Text += $"Directory \"{dirName}\" was created successfully!" + Environment.NewLine;
						folderCreated++;
					}
					else
					{
						progressOutput.Text += $"Directory \"{dirName}\" already exists!" + Environment.NewLine;
					}

					foreach (var targetFile in targetFiles.Where(x => x.Substring(x.LastIndexOf(".")) == prefferedExtension))
					{
						this.errFile = targetFile;
						string fileName = targetFile.Substring(targetFile.LastIndexOf("\\") + 1);
						string newPath = newDir + @"\" + fileName;
						string rawName = fileName.Substring(0, fileName.Length - prefferedExtension.Length);
						string newName = (string)rawName;

						while (File.Exists(newPath))
						{
							if (newName.Length <= 3)
							{
								newName += "(1)";
							}

							if (Char.IsDigit(newName[^2]) && Char.IsDigit(newName[^3]))
							{
								bool isNumberNine = false;
								StringBuilder sb = new StringBuilder(newName);
								if (newName[^2] == '9')
								{
									sb[^2] = '0';
									isNumberNine = true;
								}
								else
								{
									sb[^2] = Convert.ToChar((int)(Char.GetNumericValue(sb[^2]) + 1) + '0');
								}

								string checkCount = newName[^3].ToString() + newName[^2].ToString();
								if (int.Parse(checkCount) > 10 && isNumberNine)
								{
									string s = sb[^3].ToString();
									int n = int.Parse(s) + 1;
									sb[^3] = Convert.ToChar(int.Parse(sb[^3].ToString()) + 1 + '0');
								}

								newName = sb.ToString();
							}
							else if (Char.IsDigit(newName[^2]) && newName[^2] == '9')
							{
								StringBuilder sb = new StringBuilder(newName);
								sb[^2] = '1';
								sb[^1] = '0';
								sb.Append(')');
								newName = sb.ToString();
							}
							else if (newName[^3] == '(' && Char.IsDigit(newName[^2]) && newName[^1] == ')')
							{
								StringBuilder sb = new StringBuilder(newName);
								sb[^2] = Convert.ToChar((int)(Char.GetNumericValue(sb[^2]) + 1) + '0');
								newName = sb.ToString();
							}
							else
							{
								newName += "(1)";
							}

							fileName = newName + prefferedExtension;
							newPath = newDir + @"\" + fileName;

							if (!File.Exists(newPath))
							{
								progressOutput.Text += $"Renamed \"{rawName + prefferedExtension}\" to \"{fileName}\"!" + Environment.NewLine;
							}
						}

						File.Move(targetFile, newPath);
						progressOutput.Text += $"Successfully moved \"{fileName}\" to \"{dirName}\"!";
						progressOutput.Text += Environment.NewLine;
					}
				}
				progressOutput.Text += $"Successfully created {folderCreated} folders!"
									   + Environment.NewLine;
				progressOutput.Text += $"Successfully sorted {targetFiles.Length} files!"
									   + Environment.NewLine;
				dir = string.Empty;
				selectedDir.Text = string.Empty;
				extensionsList.Items.Clear();
			}
			catch(Exception ex)
			{
				MessageBox.Show($"Error sorting file '{errFile}': {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
            
        }

		private bool IsFileInUse(string filePath)
		{
			try
			{
				// Attempt to open the file with exclusive access
				using (FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.None))
				{
					// If the file opens successfully, it is not in use
					return false;
				}
			}
			catch (IOException)
			{
				// If an IOException occurs, the file is in use
				return true;
			}
		}
	}
}