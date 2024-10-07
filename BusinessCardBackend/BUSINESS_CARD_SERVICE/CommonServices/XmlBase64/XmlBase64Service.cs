using BUSINESS_CARD_ENTITIES;
using BUSINESS_CARD_REPOSITORIES;
using BUSINESS_CARD_SERVICE.Helpers;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BUSINESS_CARD_SERVICE.CommonServices
{
  public class XmlBase64Service:IXmlBase64Service
  {
    private readonly IBusinessCardRepo _businessCardRepo;

    public XmlBase64Service(IBusinessCardRepo businessCardRepo)
    {
      _businessCardRepo = businessCardRepo;
    }

    public async Task<byte[]> GetBase64(BusinessCardSearchParam param)
    {
      var businessCards = await _businessCardRepo.GetAllAsync(param);
      var xml = FilesHelper.SerializeToXml(businessCards); ;
      return Encoding.UTF8.GetBytes(xml);
    }

    public async Task<List<BusinessCard>> GetBusinessCards(IFormFile file)
    {
      var businessCards = new List<BusinessCard>();

      using (var stream = file.OpenReadStream())
      using (var reader = new StreamReader(stream, Encoding.UTF8, detectEncodingFromByteOrderMarks: false))
      {
        var xDocument = await XDocument.LoadAsync(reader, LoadOptions.None, default);

        foreach (var element in xDocument.Descendants("BusinessCard"))
        {
          var businessCard = new BusinessCard();

          foreach (var property in typeof(BusinessCard).GetProperties())
          {
            // Check if the XML element with the same name exists
            var xmlElement = element.Element(property.Name);
            if (xmlElement != null)
            {
              // Convert the XML value to the property type and set it
              var value = Convert.ChangeType(xmlElement.Value, property.PropertyType);
              property.SetValue(businessCard, value);
            }
          }

          businessCards.Add(businessCard);
        }
      }

      return businessCards;
    }


  }
}
