using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task3B.Core.DTOs;
using Task3B.Core.ViewModels;

namespace Task3B.Service.Services.File
{
    public interface IFileService
    {
        Task<string> SaveFile(IFormFile file, string folderName);
    }
}
