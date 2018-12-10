using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Steeltoe.Common.Net;

namespace SMBDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            string uncPath = args[0];
            string username = args[1];
            string password = args[2];
            string domain = ""; // domain not used

            NetworkCredential credential = new NetworkCredential(username, password, domain);
            using (WindowsNetworkFileShare networkPath = new WindowsNetworkFileShare(uncPath, credential))
            {
                FindFiles(uncPath);
            }

        }

        public static void FindFiles(string targetDirectory)
        {
            string[] fileEntries = Directory.GetFiles(targetDirectory);
            foreach (string fileName in fileEntries)
                Console.WriteLine("Found file '{0}'.", fileName);

            string[] subdirectoryEntries = Directory.GetDirectories(targetDirectory);
            foreach (string subdirectory in subdirectoryEntries)
                FindFiles(subdirectory);
        }


    }
}
