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
    private readonly Mock<ICsvBase64Service> _mockCsvBase64Service;
    private readonly Mock<IXmlBase64Service> _mockXmlBase64Service;
    private readonly Mock<IQrCodeService> _mockQrCodeService;
    private readonly Mock<IBusinessCardRepo> _mockBusinessCardRepo;
    private readonly BusinessCardService _service;

    public BusinessCardServiceTests()
    {
      _mockCsvBase64Service = new Mock<ICsvBase64Service>();
      _mockXmlBase64Service = new Mock<IXmlBase64Service>();
      _mockQrCodeService = new Mock<IQrCodeService>();
      _mockBusinessCardRepo = new Mock<IBusinessCardRepo>();

      _service = new BusinessCardService(
          _mockBusinessCardRepo.Object,
          _mockCsvBase64Service.Object,
          _mockXmlBase64Service.Object,
          _mockQrCodeService.Object
          );
    }

    [Fact]
    public async Task Import_ShouldReturnCount_WhenCsvFileIsProcessed()
    {
      // Arrange
      var mockFile = new Mock<IFormFile>();
      mockFile.Setup(m => m.Length).Returns(100); // Set the length of the file
      mockFile.Setup(m => m.FileName).Returns("mockfile.csv"); // Set a file name
      mockFile.Setup(m => m.OpenReadStream()).Returns(new MemoryStream(Encoding.UTF8.GetBytes("mock csv content"))); // Set CSV content
      mockFile.Setup(m => m.CopyToAsync(It.IsAny<Stream>(), It.IsAny<CancellationToken>()))
          .Returns(Task.CompletedTask); // Mock file copy operation

      var importParams = new ImportFileParams { FileType = FileType.CSV, File = mockFile.Object }; // Use the mock file

      var businessCards = new List<BusinessCard>
    {
        new BusinessCard(), // Mock business cards
        new BusinessCard()
    };

      _mockCsvBase64Service.Setup(service => service.GetBusinessCards(importParams.File))
          .ReturnsAsync(businessCards); // Mock the CSV service to return the list of business cards

      _mockBusinessCardRepo.Setup(repo => repo.BulkInsertAsync(businessCards))
          .ReturnsAsync(businessCards.Count); // Mock the repository to return the count of inserted business cards

      // Act
      var result = await _service.Import(importParams); // Call the import method

      // Assert
      Assert.Equal(businessCards.Count, result); // Assert that the result is equal to the expected count
    }

    [Fact]
    public async Task Import_ShouldReturnCount_WhenXmlFileIsProcessed()
    {
      // Arrange
      var mockFile = new Mock<IFormFile>();
      mockFile.Setup(m => m.Length).Returns(100); // Set the length of the file
      mockFile.Setup(m => m.FileName).Returns("mockfile.xml"); // Set a file name
      mockFile.Setup(m => m.OpenReadStream()).Returns(new MemoryStream(Encoding.UTF8.GetBytes("<BusinessCards><Card></Card></BusinessCards>"))); // Set XML file content
      mockFile.Setup(m => m.CopyToAsync(It.IsAny<Stream>(), It.IsAny<CancellationToken>()))
          .Returns(Task.CompletedTask); // Mock file copy operation

      var importParams = new ImportFileParams { FileType = FileType.XML, File = mockFile.Object };

      var businessCards = new List<BusinessCard>
    {
        new BusinessCard(), // Mock business cards
        new BusinessCard()
    };

      // Setup the mocked service to return the business cards from the XML file
      _mockXmlBase64Service.Setup(service => service.GetBusinessCards(importParams.File))
          .ReturnsAsync(businessCards);

      // Setup the mocked repository to return the count of inserted business cards
      _mockBusinessCardRepo.Setup(repo => repo.BulkInsertAsync(businessCards))
          .ReturnsAsync(businessCards.Count);

      // Act
      var result = await _service.Import(importParams);

      // Assert
      Assert.Equal(businessCards.Count, result);
    }

    [Fact]
    public async Task Import_ShouldReturnCount_WhenQrCodeFileIsProcessed()
    {
      // Arrange
      var mockFile = new Mock<IFormFile>();
      mockFile.Setup(m => m.Length).Returns(100); // Set the length of the file
      mockFile.Setup(m => m.FileName).Returns("mockfile.qr"); // Set a file name
      mockFile.Setup(m => m.OpenReadStream()).Returns(new MemoryStream(Encoding.UTF8.GetBytes("mock qr code content"))); // Set QR code content
      mockFile.Setup(m => m.CopyToAsync(It.IsAny<Stream>(), It.IsAny<CancellationToken>()))
          .Returns(Task.CompletedTask); // Mock file copy operation

      var importParams = new ImportFileParams { FileType = FileType.QR, File = mockFile.Object };

      var businessCard = new BusinessCard(); // Mock business card
      _mockQrCodeService.Setup(service => service.GetBusinessCard(importParams.File))
          .ReturnsAsync(businessCard); // Mock the QR code service to return a business card

      _mockBusinessCardRepo.Setup(repo => repo.BulkInsertAsync(It.IsAny<List<BusinessCard>>()))
          .ReturnsAsync(1); // Mock the repository to return 1 for inserted business card

      // Act
      var result = await _service.Import(importParams);

      // Assert
      Assert.Equal(1, result); // Assert that the result is 1
    }


    [Fact]
    public async Task Import_ShouldReturnZero_WhenNoBusinessCardsAreProcessed()
    {
      // Arrange
      var mockFile = new Mock<IFormFile>();
      mockFile.Setup(m => m.Length).Returns(100); // Set the length of the file
      mockFile.Setup(m => m.FileName).Returns("mockfile.csv"); // Set a file name
      mockFile.Setup(m => m.OpenReadStream()).Returns(new MemoryStream(Encoding.UTF8.GetBytes("mock csv content"))); // Set CSV content
      mockFile.Setup(m => m.CopyToAsync(It.IsAny<Stream>(), It.IsAny<CancellationToken>()))
          .Returns(Task.CompletedTask); // Mock file copy operation

      var importParams = new ImportFileParams { FileType = FileType.CSV, File = mockFile.Object };

      // Mock the CSV service to return an empty list
      _mockCsvBase64Service.Setup(service => service.GetBusinessCards(importParams.File))
          .ReturnsAsync(new List<BusinessCard>()); // No business cards returned

      // Act
      var result = await _service.Import(importParams);

      // Assert
      Assert.Equal(0, result); // Assert that the result is 0
    }

  }
}
