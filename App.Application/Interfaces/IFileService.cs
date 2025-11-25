using System;
using System.Collections.Generic;
using System.Text;

namespace App.Application.Interfaces
{
    public interface IFileService
    {
        string Upload(Stream fileStream, string fileName, string folder);
        void Delete(string fileName);
    }
}
