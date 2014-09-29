using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TestProject.Workers;

namespace TestProject
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void Run_Click(object sender, EventArgs e)
        {
            var scaner = new FileSystemWorker();
            scaner.TraverseTree(selectedPathTextBox.Text);
            this.runButton .BackColor = Color.Red;
        }

        private void SelectPath_Click(object sender, EventArgs e)
        {
            folderBrowserDialog.ShowDialog();
            var selectedFolder = folderBrowserDialog.SelectedPath;

            this.selectedPathTextBox.Text = selectedFolder;
        }
    }
}
