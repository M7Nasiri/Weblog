using App.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.Application.Services
{
    public class FileService: IFileService
    {
        private const long MaxFileSize = 2 * 1024 * 1024; // 2MB in bytes
        private readonly string[] AllowedExtensions = { ".jpg", ".jpeg", ".png" };

        public string Upload(Stream fileStream, string fileName, string folder)
        {
            // Check file extension
            var fileExtension = Path.GetExtension(fileName).ToLower();
            if (!Array.Exists(AllowedExtensions, ext => ext == fileExtension))
            {
                throw new InvalidOperationException("Only JPG, JPEG, and PNG files are allowed.");
            }

            // Check file size
            if (fileStream.Length > MaxFileSize)
            {
                throw new InvalidOperationException("File size exceeds the maximum limit of 2 MB.");
            }
            var uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Files", folder);

            if (!Directory.Exists(uploadsFolder))
                Directory.CreateDirectory(uploadsFolder);

            var uniqueName = Guid.NewGuid() + Path.GetExtension(fileName);

            var filePath = Path.Combine(uploadsFolder, uniqueName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                fileStream.CopyTo(stream);
            }

            return Path.Combine("/Files", folder, uniqueName);
        }


        public void Delete(string fileName)
        {
            if (string.IsNullOrWhiteSpace(fileName))
                return;

            fileName = fileName.TrimStart('/', '\\');

            var fullPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", fileName);

            if (File.Exists(fullPath))
                File.Delete(fullPath);
        }
    }
}
