namespace TestProject
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.runButton = new System.Windows.Forms.Button();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.selectedPathTextBox = new System.Windows.Forms.TextBox();
            this.selectPathFolder = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // runButton
            // 
            this.runButton.Location = new System.Drawing.Point(503, 293);
            this.runButton.Name = "runButton";
            this.runButton.Size = new System.Drawing.Size(75, 23);
            this.runButton.TabIndex = 0;
            this.runButton.Text = "Run";
            this.runButton.UseVisualStyleBackColor = true;
            this.runButton.Click += new System.EventHandler(this.Run_Click);
            // 
            // treeView1
            // 
            this.treeView1.Location = new System.Drawing.Point(13, 13);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(321, 303);
            this.treeView1.TabIndex = 1;
            // 
            // selectedPathTextBox
            // 
            this.selectedPathTextBox.Location = new System.Drawing.Point(340, 15);
            this.selectedPathTextBox.Name = "selectedPathTextBox";
            this.selectedPathTextBox.Size = new System.Drawing.Size(157, 20);
            this.selectedPathTextBox.TabIndex = 2;
            this.selectedPathTextBox.Text = "C:\\";
            // 
            // selectPathFolder
            // 
            this.selectPathFolder.Location = new System.Drawing.Point(503, 12);
            this.selectPathFolder.Name = "selectPathFolder";
            this.selectPathFolder.Size = new System.Drawing.Size(75, 23);
            this.selectPathFolder.TabIndex = 3;
            this.selectPathFolder.Text = "Select path";
            this.selectPathFolder.UseVisualStyleBackColor = true;
            this.selectPathFolder.Click += new System.EventHandler(this.SelectPath_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(590, 328);
            this.Controls.Add(this.selectPathFolder);
            this.Controls.Add(this.selectedPathTextBox);
            this.Controls.Add(this.treeView1);
            this.Controls.Add(this.runButton);
            this.Name = "MainForm";
            this.Text = "FileSystem_Viewer";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button runButton;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
        private System.Windows.Forms.TextBox selectedPathTextBox;
        private System.Windows.Forms.Button selectPathFolder;
    }
}

