using BUSINESS_CARD_CONTEXT;
using BUSINESS_CARD_ENTITIES;
using BUSINESS_CARD_REPOSITORIES;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUSINESS_CARD_SERVICE
{
    public class BusinessCardService:IBusinessCardService
    {
        private readonly IBusinessCardRepo _businessCardRepo;

        public BusinessCardService(IBusinessCardRepo businessCardRepo)
        {
            _businessCardRepo = businessCardRepo;
        }

        public async Task<List<BusinessCard>> SearchAsync(BusinessCardParam param)
        {
            return await _businessCardRepo.SearchAsync(param);
        }

        public async Task<BusinessCard> InsertAsync(BusinessCard businessCard)
        {
            if (businessCard.Image != null) 
            {
                businessCard.ImagePath = await SaveImage(businessCard.Image);
            }
            return await _businessCardRepo.InsertAsync(businessCard);
        }

        private async Task<string> SaveImage(IFormFile file)
        {
            if (file == null || file.Length == 0)
            {
                return null; // Handle error accordingly
            }

            var filePath = Path.Combine("wwwroot/images", file.FileName); // Change the path as needed
            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            return filePath; // Return the path where the image is saved
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _businessCardRepo.DeleteAsync(id);
        }
    }
}
