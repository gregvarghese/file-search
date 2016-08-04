#region

using System;
using System.IO;
using UlteriusFileSearch.Database;

#endregion

namespace UlteriusFileSearch.Ntfs
{
    internal class FileSystemMonitor
    {
      
        public readonly string Drive;
        private FileSystemWatcher _watcher;

        public FileSystemMonitor(string drive)
        {
            Drive = drive;
            
        }

        public void Start()
        {
            CreateFileWatcher();
        }

        public void StopWatcher()
        {
            if (_watcher != null)
            {
                _watcher.EnableRaisingEvents = false;
            }
        }

        private bool IsFolder(string path)
        {
            return (File.GetAttributes(path) & FileAttributes.Directory) == FileAttributes.Directory;
        }

        private void CreateFileWatcher()
        {
      
            _watcher = new FileSystemWatcher
            {
                Path = Drive,
                NotifyFilter = NotifyFilters.LastAccess | NotifyFilters.LastWrite
                               | NotifyFilters.FileName | NotifyFilters.DirectoryName,
                Filter = "*.*",
                IncludeSubdirectories = true
            };
          
           
            _watcher.Changed += OnChanged;
            _watcher.Created += OnCreated;
            _watcher.Deleted += OnDeleted;
            _watcher.Renamed += OnRenamed;

            // Begin watching.
            _watcher.EnableRaisingEvents = true;
        }

        private void OnRenamed(object sender, RenamedEventArgs e)
        {
            if (IsFolder(e.FullPath))
            {
                return;
            }
            var oldFile = Path.GetFileName(e.OldFullPath);
            var newFile = Path.GetFileName(e.FullPath);
            Console.WriteLine($"{oldFile}|{newFile}");
        }

        private void OnDeleted(object sender, FileSystemEventArgs e)
        {
         
        }

        private void OnCreated(object sender, FileSystemEventArgs e)
        {
            // throw new NotImplementedException();
        }

        private void OnChanged(object sender, FileSystemEventArgs e)
        {
            //throw new NotImplementedException();
        }
    }
}