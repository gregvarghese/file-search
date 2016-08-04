#region

using System;
using System.Collections.Generic;
using System.IO;

#endregion

namespace UlteriusFileSearch.Database
{
    //keeps everything together
    internal class DatabaseController
    {
        private readonly DatabaseManager _databaseManager;
        private readonly string _path;
        private DatabaseListener _databaseListener;

        public DatabaseController(string path)
        {
            _path = path;
            _databaseListener = new DatabaseListener();
            _databaseManager = new DatabaseManager(path);
        }

        

        public string GetCurrentDrive()
        {
            return _databaseManager.CurrentDrive;
        }

        public bool IsScanning()
        {
            return _databaseManager.Scanning;
        }

        private void Scan()
        {
            _databaseManager.Scanning = true;
            _databaseManager.CreateDatabase();
            _databaseManager.Scanning = false;
        }

        public List<string> Search(string keyword)
        {
          
            return _databaseManager.Search(keyword);
        }

        public bool Refresh()
        {
            return _databaseManager.CreateDatabase();
        }

        public void Start()
        {
            if (File.Exists(_path))
            {
                if (_databaseManager.OutOfSync())
                {

                    Scan();
                }
            }
            else
            {
                Console.WriteLine("Getting ready to scan");
                Scan();
            }
        }
    }
}