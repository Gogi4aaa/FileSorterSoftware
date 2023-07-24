namespace FileSorterSoftware
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            selectedDir = new TextBox();
            label1 = new Label();
            browseButton = new Button();
            extensionsList = new CheckedListBox();
            progressOutput = new RichTextBox();
            label2 = new Label();
            label3 = new Label();
            sortButton = new Button();
            folderDialog = new FolderBrowserDialog();
            SuspendLayout();
            // 
            // selectedDir
            // 
            selectedDir.Enabled = false;
            selectedDir.Font = new Font("Segoe UI Semibold", 12.75F, FontStyle.Bold, GraphicsUnit.Point);
            selectedDir.Location = new Point(36, 44);
            selectedDir.Name = "selectedDir";
            selectedDir.Size = new Size(540, 30);
            selectedDir.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 12.75F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(36, 18);
            label1.Name = "label1";
            label1.Size = new Size(116, 23);
            label1.TabIndex = 1;
            label1.Text = "Path to folder";
            // 
            // browseButton
            // 
            browseButton.Font = new Font("Segoe UI Semibold", 12.75F, FontStyle.Bold, GraphicsUnit.Point);
            browseButton.Location = new Point(591, 44);
            browseButton.Name = "browseButton";
            browseButton.Size = new Size(166, 30);
            browseButton.TabIndex = 2;
            browseButton.Text = "Browse";
            browseButton.UseVisualStyleBackColor = true;
            browseButton.Click += browseButton_Click;
            // 
            // extensionsList
            // 
            extensionsList.Font = new Font("Segoe UI Semibold", 12.75F, FontStyle.Bold, GraphicsUnit.Point);
            extensionsList.FormattingEnabled = true;
            extensionsList.Items.AddRange(new object[] { " " });
            extensionsList.Location = new Point(36, 122);
            extensionsList.Name = "extensionsList";
            extensionsList.Size = new Size(114, 304);
            extensionsList.TabIndex = 3;
            // 
            // progressOutput
            // 
            progressOutput.Enabled = false;
            progressOutput.Font = new Font("Segoe UI Semibold", 12.75F, FontStyle.Bold, GraphicsUnit.Point);
            progressOutput.Location = new Point(256, 122);
            progressOutput.Name = "progressOutput";
            progressOutput.Size = new Size(501, 245);
            progressOutput.TabIndex = 4;
            progressOutput.Text = "";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 12.75F, FontStyle.Bold, GraphicsUnit.Point);
            label2.Location = new Point(256, 96);
            label2.Name = "label2";
            label2.Size = new Size(75, 23);
            label2.TabIndex = 5;
            label2.Text = "Progress";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI Semibold", 12.75F, FontStyle.Bold, GraphicsUnit.Point);
            label3.Location = new Point(36, 96);
            label3.Name = "label3";
            label3.Size = new Size(91, 23);
            label3.TabIndex = 6;
            label3.Text = "Extensions";
            // 
            // sortButton
            // 
            sortButton.Font = new Font("Segoe UI Semibold", 12.75F, FontStyle.Bold, GraphicsUnit.Point);
            sortButton.Location = new Point(633, 391);
            sortButton.Name = "sortButton";
            sortButton.Size = new Size(124, 35);
            sortButton.TabIndex = 7;
            sortButton.Text = "Sort";
            sortButton.UseVisualStyleBackColor = true;
            sortButton.Click += sortButton_Click;
            // 
            // folderDialog
            // 
            folderDialog.Description = "Select folder";
            folderDialog.InitialDirectory = "Desktop";
            folderDialog.ShowNewFolderButton = false;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(sortButton);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(progressOutput);
            Controls.Add(extensionsList);
            Controls.Add(browseButton);
            Controls.Add(label1);
            Controls.Add(selectedDir);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Form1";
            RightToLeftLayout = true;
            Text = "FileSorter";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox selectedDir;
        private Label label1;
        private Button browseButton;
        private CheckedListBox extensionsList;
        private RichTextBox progressOutput;
        private Label label2;
        private Label label3;
        private Button sortButton;
        private FolderBrowserDialog folderDialog;
    }
}