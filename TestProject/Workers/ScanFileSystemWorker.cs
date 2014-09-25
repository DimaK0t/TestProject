﻿using System;
using System.Collections.Generic;
using System.IO;

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
            //TODO: get dir info.

       
            string[] files;
            if (TryGetFiles(root, out files))
            {
                foreach (var file in files)
                {
                    var fileInfo = GetFileInfo(file);
                }
            }

            string[] subDirs;
            if (TryGetSubDirectories(root, out subDirs))
            {
                foreach (var str in subDirs)
                {
                    TraverseTree(str);
                }
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

        private bool TryGetFiles(string currentDir, out string[] files)
        {
            files = null;

            try
            {
                files = System.IO.Directory.GetFiles(currentDir);
                return true;
            }

            catch (UnauthorizedAccessException e)
            {
                Console.WriteLine(e.Message);
            }

            catch (DirectoryNotFoundException e)
            {
                Console.WriteLine(e.Message);
            }

            return false;
        }

        private bool TryGetSubDirectories(string currentDir, out string[] directories)
        {
            directories = null;

            try
            {
                directories = System.IO.Directory.GetDirectories(currentDir);
                return true;
            }

            catch (UnauthorizedAccessException e)
            {
                Console.WriteLine(e.Message);
            }

            catch (DirectoryNotFoundException e)
            {
                Console.WriteLine(e.Message);
            }

            return false;
        }
    }
}