using Core.Utilities.Results;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Core.Utilities.Business.FileManager
{
    public class CarImagesFileHelper
    {
        public static string Add(IFormFile file)
        {
            string extension = Path.GetExtension(file.FileName).ToUpper();
            string newGUID = CreateGuid() + extension;
            
            var path = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).FullName + @"\Images");
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            string imagePath;
            using (FileStream fileStream = File.Create(path + "\\" + newGUID))
            {
                file.CopyToAsync(fileStream);
                imagePath = path + "\\" + newGUID;
                fileStream.Flush();
            }
            return imagePath;
        }

        public static void Update(IFormFile file, string OldPath)
        {
            string extension = Path.GetExtension(file.FileName).ToUpper();
            using (FileStream fileStream = File.Open(OldPath,FileMode.Open))
            {
                file.CopyToAsync(fileStream);
                fileStream.Flush();
            }
        }

        public static void Delete(string Path)
        {
            File.Delete(Path);
        }

        public static string CreateGuid()
        {
            return Guid.NewGuid().ToString("N") + "-" + DateTime.Now.Month + "-" + DateTime.Now.Day + "-" + DateTime.Now.Year;
        }
    }
}
