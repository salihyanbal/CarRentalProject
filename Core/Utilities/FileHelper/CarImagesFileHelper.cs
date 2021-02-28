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
            string newGUID = CreateGuid() + extension; // 218382138213-27.02.2021.jpg
            var directory  = Directory.GetCurrentDirectory() + "\\wwwroot";
            var path = directory + @"\Images";
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
            return imagePath.Replace("\\", "/");
        }

        public static void Update(IFormFile file, string OldPath)
        {
            string extension = Path.GetExtension(file.FileName).ToUpper();
            using (FileStream fileStream = File.Open(OldPath.Replace("/", "\\"),FileMode.Open))
            {
                file.CopyToAsync(fileStream);
                fileStream.Flush();
            }
        }

        public static void Delete(string ImagePath)
        {
            if(File.Exists(ImagePath.Replace("/", "\\")) && Path.GetFileName(ImagePath)!="default.png"){
                File.Delete(ImagePath.Replace("/", "\\"));
            }
        }

        public static string CreateGuid()
        {
            return Guid.NewGuid().ToString("N") + "-" + DateTime.Now.Month + "-" + DateTime.Now.Day + "-" + DateTime.Now.Year;
        }
    }
}
