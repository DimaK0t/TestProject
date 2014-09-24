using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestProject
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
           

        }

        private void SelectPath_Click(object sender, EventArgs e)
        {
            folderBrowserDialog.ShowDialog();
            var selectedFolder = folderBrowserDialog.SelectedPath;

            this.selectedPathTextBox.Text = selectedFolder;
        }
    }
}
