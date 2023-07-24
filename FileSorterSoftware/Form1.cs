using System.Text;

namespace FileSorterSoftware
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private string dir = string.Empty;
        private string[] filePaths;
        private string[] extensions;
        private void browseButton_Click(object sender, EventArgs e)
        {
            if (folderDialog.ShowDialog() == DialogResult.OK)
            {
                dir = folderDialog.SelectedPath;
                selectedDir.Text = dir;
                filePaths = Directory.GetFiles(dir, "*.*",
                    SearchOption.TopDirectoryOnly);
                extensions = filePaths.Select(x => x.Substring(x.LastIndexOf("."))).Distinct().OrderBy(x => x[1]).ToArray();
                if (filePaths.Length == 0)
                {
                    selectedDir.Text = string.Empty;
                    MessageBox.Show("No files in selected folder!", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);

                    return;
                }

                extensionsList.Items.Clear();
                extensionsList.Items.AddRange(extensions);
            }
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
            string[] prefferedExtensions = extensionsList.CheckedItems.Count > 0 ? extensionsList.CheckedItems.OfType<string>().ToArray() : extensions;
            string[] targetFiles = filePaths.Where(x => prefferedExtensions.Contains(x.Substring(x.LastIndexOf(".")))).ToArray();

            foreach (var prefferedExtension in prefferedExtensions)
            {
                string dirName = $@"{prefferedExtension.TrimStart('.').ToUpper()} Files";
                string newDir = dir + @"\" + dirName;

                if (!Directory.Exists(newDir))
                {
                    Directory.CreateDirectory(newDir);
                    progressOutput.Text += $"Directory \"{dirName}\" was created successfully!" + Environment.NewLine;
                }
                else
                {
                    progressOutput.Text += $"Directory \"{dirName}\" already exists!" + Environment.NewLine;
                }

                foreach (var targetFile in targetFiles.Where(x => x.Substring(x.LastIndexOf(".")) == prefferedExtension))
                {

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

            dir = string.Empty;
            selectedDir.Text = string.Empty;
            extensionsList.Items.Clear();
        }



    }
}