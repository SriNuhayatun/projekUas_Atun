using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace projekUas_Atun.Views.Services.MemberServices
{
   
    public class FileService
    {
        IWebHostEnvironment _alat;

        public FileService(IWebHostEnvironment e)
        {
            _alat = e;
        }
        public async Task<string> SimpanFile(IFormFile filenya)
        {
            string namaFolder = "FileFoto";
            if (filenya == null)
            {
                return string.Empty;
            }
            var alamatLengkap = Path.Combine(_alat.WebRootPath, namaFolder);
            
            if (!Directory.Exists(alamatLengkap))
            { 
                Directory.CreateDirectory(alamatLengkap);
            }
           
            var namaFilenya = filenya.FileName;
            var alamatFilenya = Path.Combine(alamatLengkap, namaFilenya);
           
            using (var stream = new FileStream(alamatFilenya, FileMode.Create))
            {
                await filenya.CopyToAsync(stream);
            }
            return Path.Combine("/" + namaFolder + "/" + namaFilenya);

        }
    }
    
    
}
