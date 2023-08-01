using Microsoft.AspNetCore.Hosting;
using System.IO;
using System;
using Microsoft.AspNetCore.Http;
using E_Ticaret_Project.Models;

namespace E_Ticaret_Project.Helpers
{
    public class ImageSaveMethod
    {

        private readonly IWebHostEnvironment _webHostEnvironment;

        public ImageSaveMethod(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }

        // Method tanımı
        public string FotografEkle(IFormFile sliderPhoto, string klasorAdi)
        {
            // Fotoğrafı yüklemek için benzersiz bir dosya adı oluşturun
            string fotografinAdi = Guid.NewGuid().ToString() + "_" + sliderPhoto.FileName;

            // Fotoğrafı kaydetmek için hedef dosya yolunu oluşturun
            string uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, klasorAdi);

            //fotoğrafın ismini ve yolunu combinliyoruz
            string filePath = Path.Combine(uploadsFolder, fotografinAdi);

            //Yolunu ve fotoğrafın ismini biliyoruz bu kodda ise yüklüyoruz.
            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                sliderPhoto.CopyTo(fileStream);
            }

            return fotografinAdi;
        }



    }
}
