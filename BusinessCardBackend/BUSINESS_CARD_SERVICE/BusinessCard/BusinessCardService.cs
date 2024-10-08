using BUSINESS_CARD_CONTEXT;
using BUSINESS_CARD_CORE;
using BUSINESS_CARD_CORE.CommonEnums;
using BUSINESS_CARD_ENTITIES;
using BUSINESS_CARD_REPOSITORIES;
using BUSINESS_CARD_SERVICE.CommonServices;
using BUSINESS_CARD_SERVICE.CommonServices.QrCode;
using BUSINESS_CARD_SERVICE.Helpers;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace BUSINESS_CARD_SERVICE
{
  public class BusinessCardService : IBusinessCardService
  {
    private readonly IBusinessCardRepo _businessCardRepo;
    private readonly IXmlService _xmlBase64Service;
    private readonly ICsvService _csvBase64Service;
    private readonly IQrCodeService _qrCodeService;

    public BusinessCardService(IBusinessCardRepo businessCardRepo, ICsvService csvBase64Service, IXmlService xmlBase64Service, IQrCodeService qrCodeService)
    {
      _businessCardRepo = businessCardRepo;
      _csvBase64Service = csvBase64Service;
      _xmlBase64Service = xmlBase64Service;
      _qrCodeService = qrCodeService;
    }

    public async Task<PaginationResult<BusinessCard>> SearchAsync(BusinessCardSearchParam param)
    {
      return await _businessCardRepo.SearchAsync(param);
    }
   
    public Task<BusinessCard> InsertAsync(BusinessCard businessCard)
    {
      throw new NotImplementedException();
    }

    public async Task<BusinessCard> InsertAsync(BusinessCardInsertParam businessCard)
    {
      if (businessCard.Image != null)
      {
        businessCard.Base64 = await FilesHelper.GetBase64(businessCard.Image);
      }
      return await _businessCardRepo.InsertAsync(businessCard);
    }

    public async Task<bool> DeleteAsync(int id)
    {
      return await _businessCardRepo.DeleteAsync(id);
    }


    public async Task<int> Import(ImportFileParams @params)
    {
      List<BusinessCard> businessCards = new List<BusinessCard>();
      switch (@params.FileType)
      {
        case FileType.CSV:
          businessCards = await _csvBase64Service.GetBusinessCards(@params.File);
          break;
        case FileType.XML:
          businessCards = await _xmlBase64Service.GetBusinessCards(@params.File);
          break;
        default:
          var businessCard = await _qrCodeService.GetBusinessCard(@params.File);
          if(businessCard != null)
          {
            businessCards.Add(businessCard);
          }
          break;
      }
      if(businessCards.Any())
      {
        return await _businessCardRepo.BulkInsertAsync(businessCards);
      }
      return 0;

    }
  }
}
