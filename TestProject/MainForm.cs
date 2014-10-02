using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using TestProject.Models;
using TestProject.Workers;

namespace TestProject
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            selectedPathTextBox.Text = @"D:\OneDrive\Pictures\Camera Roll";
        }

        private void Run_Click(object sender, EventArgs e)
        {
            var syncEvents = new SyncEvents();
            var nodeQueue = new SafeQueue<NodeInfo>(syncEvents);

            // start file system scaner.
            var scaner = new FileSystemWorker(nodeQueue, syncEvents);
            var scanerThread = new Thread(scaner.TraverseTree);
            scanerThread.Start(selectedPathTextBox.Text);

            // start XML writer.
            var xmlWriter = new XmlWorker(nodeQueue, syncEvents);
            var xmlThread = new Thread(xmlWriter.WriteXml);
            xmlThread.Start("D:\\xml.xml");
        }

        private void SelectPath_Click(object sender, EventArgs e)
        {
            folderBrowserDialog.ShowDialog();
            var selectedFolder = folderBrowserDialog.SelectedPath;

            this.selectedPathTextBox.Text = selectedFolder;
        }
    }
}
