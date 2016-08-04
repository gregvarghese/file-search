#region

using System;
using System.Collections.Generic;
using UlteriusFileSearch.Database;

#endregion

namespace UlteriusFileSearch
{
    public class SearchService
    {
        private readonly string _cachePath;
        private DatabaseController databaseController;


        public SearchService(string cachePath)
        {
            _cachePath = cachePath;
         
        }


        public void Configure()
        {
           databaseController = new DatabaseController(_cachePath);
            databaseController.Start();
            Console.WriteLine("File Database Ready");
        }

        public bool IsScanning()
        {
            return databaseController.IsScanning();
        }
        public string CurrentScanDrive()
        {
            return databaseController.GetCurrentDrive();
        }
        public bool Refresh()
        {
            return databaseController.Refresh();
        }

        public List<string> Search(string keyword)
        {
            return databaseController?.Search(keyword);
        }

        public void Close()
        {
            //  indexConnection.Close();
        }
    }
}