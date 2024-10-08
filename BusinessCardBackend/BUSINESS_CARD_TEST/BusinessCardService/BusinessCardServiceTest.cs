using BUSINESS_CARD_CORE.CommonEnums;
using BUSINESS_CARD_ENTITIES;
using BUSINESS_CARD_REPOSITORIES;
using BUSINESS_CARD_SERVICE.CommonServices.QrCode;
using BUSINESS_CARD_SERVICE.CommonServices;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BUSINESS_CARD_SERVICE;
using Microsoft.AspNetCore.Http;

namespace BUSINESS_CARD_TEST
{
  public class BusinessCardServiceTests
  {
    private readonly Mock<ICsvService> _mockCsvBase64Service;
    private readonly Mock<IXmlService> _mockXmlBase64Service;
    private readonly Mock<IQrCodeService> _mockQrCodeService;
    private readonly Mock<IBusinessCardRepo> _mockBusinessCardRepo;
    private readonly BusinessCardService _service;

    public BusinessCardServiceTests()
    {
      _mockCsvBase64Service = new Mock<ICsvService>();
      _mockXmlBase64Service = new Mock<IXmlService>();
      _mockQrCodeService = new Mock<IQrCodeService>();
      _mockBusinessCardRepo = new Mock<IBusinessCardRepo>();

      _service = new BusinessCardService(
          _mockBusinessCardRepo.Object,
          _mockCsvBase64Service.Object,
          _mockXmlBase64Service.Object,
          _mockQrCodeService.Object
          );
    }
  }

  
    
}
