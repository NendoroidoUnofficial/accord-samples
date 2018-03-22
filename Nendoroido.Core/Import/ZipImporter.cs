using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Text;

namespace Nendoroido.Core.Import
{
    /// <summary>
    /// import ZIP file
    /// </summary>
    public class ZipImporter
    {
        /// <summary>
        /// import from url
        /// </summary>
        /// <param name="url"></param>
        public void Import(string url)
        {
            //把下載的ZIP 存到哪裡
            string zipPath = @"c:\example\start.zip";

            //壓縮目的地
            string extractPath = @"c:\example\extract";


            //1. extract file
            //using (ZipArchive archive = ZipFile.OpenRead(zipPath))
            //{
            //    foreach (ZipArchiveEntry entry in archive.Entries)
            //    {
            //        if (entry.FullName.EndsWith(".txt", StringComparison.OrdinalIgnoreCase))
            //        {
            //            entry.ExtractToFile(Path.Combine(extractPath, entry.FullName));
            //        }
            //    }
            //}

            //2. read file

        }
    }
}
