using System;
using System.Collections.Generic;
using System.IO;
using TestProject.Models;

namespace TestProject.Workers
{
    public class FileSystemWorker
    {
        private Queue<NodeInfo> _queue;
        private SyncEvents _syncEvents;

        public FileSystemWorker(Queue<NodeInfo> queue, SyncEvents syncEvents)
        {
             _queue = queue;
            _syncEvents = syncEvents;
        }

        public void TraverseTree(object rootObject)
        {
            var root = (string)rootObject;

            if (!Directory.Exists(root))
            {
                // throw new ArgumentException();
                return;
            }
            
            DirectoryInfo directoryInfo;
            if (TryGetDirectoryInfo(root, out directoryInfo))
            {
                //todo: do anything with this info    
            }
       
            string[] files;
            if (TryGetFiles(root, out files))
            {
                foreach (var file in files)
                {
                    FileInfo fileInfo;
                    if (TryGetFileInfo(file, out fileInfo))
                    {
                        //todo: do anything with this info
                    }
                }
            }

            string[] subDirs;
            if (!TryGetSubDirectories(root, out subDirs))
            {
                return;
            }

            foreach (var str in subDirs)
            {
                TraverseTree(str);
            }
        }

        private bool TryGetDirectoryInfo(string path, out DirectoryInfo directoyInfo)
        {
            directoyInfo = null;
            try
            {
                directoyInfo = new DirectoryInfo(path);
                return true;
            }
            catch (DirectoryNotFoundException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (PathTooLongException e)
            {
                //Don`t process directory with too long name. But dont stop process tree.
                Console.WriteLine(e.Message);
            }

            return false;
        }

        private bool TryGetFileInfo(string path, out FileInfo fileInfo)
        {
            fileInfo = null;
            try
            {
                fileInfo = new FileInfo(path);
                return true;
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

            return false;
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