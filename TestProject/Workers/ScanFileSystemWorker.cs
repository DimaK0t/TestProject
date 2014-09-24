using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestProject.Models;

namespace TestProject.Workers
{
    public class ScanFileSystemWorker
    {
        public void TraverseTree(string root)
        {
            if (!Directory.Exists(root))
            {
                // throw new ArgumentException();
                return;
            }
            
            //TODO: get dir info

            var subDirs = GetSubFolders(root);
            var files = GetFiles(root);

            if (files == null)
            {
                return;
            }

            foreach (var file in files)
            {
                var fileInfo = GetFileInfo(file);
            }

            // Push the subdirectories onto the stack for traversal.
            foreach (var str in subDirs)
            {
                TraverseTree(str);
            }
        }

        private FileInfo GetFileInfo(string path)
        {
            FileInfo fi = null;
            try
            {
                // Perform whatever action is required in your scenario.
                fi = new FileInfo(path);
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (PathTooLongException e)
            {
                //Don`t process files with too long name. But dont stop process tree.
                Console.WriteLine(e.Message);
            }
            return fi;
        }

        private IEnumerable<string> GetFiles(string currentDir)
        {
            string[] files = null;
            try
            {
                files = System.IO.Directory.GetFiles(currentDir);
            }

            catch (UnauthorizedAccessException e)
            {
                Console.WriteLine(e.Message);
            }

            catch (DirectoryNotFoundException e)
            {
                Console.WriteLine(e.Message);
            }
            return files;
        }

        private IEnumerable<string> GetSubFolders(string currentDir)
        {
            string[] subDirs = null;
            try
            {
                subDirs = System.IO.Directory.GetDirectories(currentDir);
            }

            catch (UnauthorizedAccessException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (DirectoryNotFoundException e)
            {
                Console.WriteLine(e.Message);
            }

            return subDirs;
        }
    }
}