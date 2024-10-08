using BUSINESS_CARD_ENTITIES;
using BUSINESS_CARD_REPOSITORIES;
using BUSINESS_CARD_SERVICE.Helpers;
using CsvHelper;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Formats.Asn1;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUSINESS_CARD_SERVICE.CommonServices
{
  public class CsvService:ICsvService
  {
    private readonly IBusinessCardRepo _businessCardRepo;

    public CsvService(IBusinessCardRepo businessCardRepo)
    {
      _businessCardRepo = businessCardRepo;
    }

    public async Task<byte[]> GetBase64(BusinessCardSearchParam param)
    {
      var businessCards = await _businessCardRepo.GetAllAsync(param);
      var xml = FilesHelper.ConvertToCsv(businessCards); ;
      return Encoding.UTF8.GetBytes(xml);
    }


    public async Task<List<BusinessCard>> GetBusinessCards(IFormFile file)
    {
      using (var reader = new StreamReader(file.OpenReadStream()))
      using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
      {
        var records = csv.GetRecords<BusinessCard>().ToList();
        return records;
      }
    }

  }
}
