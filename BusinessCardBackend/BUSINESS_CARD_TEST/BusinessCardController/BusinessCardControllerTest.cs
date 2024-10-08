using BUSINESS_CARD_SERVICE;
using BUSINESS_CARD_SERVICE.CommonServices.QrCode;
using BUSINESS_CARD_SERVICE.CommonServices;
using BusinessCardBackend.Controllers;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BUSINESS_CARD_ENTITIES;
using Microsoft.AspNetCore.Mvc;
using BUSINESS_CARD_CORE;
using FluentAssertions;
using BUSINESS_CARD_CORE.CommonEnums;

namespace BUSINESS_CARD_TEST
{
  public class BusinessCardControllerTests
  {
    private readonly Mock<IBusinessCardService> _mockBusinessCardService;
    private readonly Mock<ICsvService> _mockCsvBase64Service;
    private readonly Mock<IXmlService> _mockXmlBase64Service;
    private readonly Mock<IQrCodeService> _mockQrCodeService;
    private readonly BusinessCardsController _controller;
    public BusinessCardControllerTests()
    {
      _mockBusinessCardService = new Mock<IBusinessCardService>();
      _mockCsvBase64Service = new Mock<ICsvService>();
      _mockXmlBase64Service = new Mock<IXmlService>();
      _mockQrCodeService = new Mock<IQrCodeService>();

      _controller = new BusinessCardsController(
          _mockBusinessCardService.Object,
          _mockCsvBase64Service.Object,
          _mockXmlBase64Service.Object,
          _mockQrCodeService.Object);
    }

    [Fact]
    public async Task Get_ShouldReturnOk_WhenEntitiesAreFound()
    {
      // Arrange
      var searchParam = new BusinessCardSearchParam(); // Add your actual search params here
      var expectedEntities = new PaginationResult<BusinessCard>(); // Mock some data


      _mockBusinessCardService.Setup(service => service.SearchAsync(searchParam))
          .ReturnsAsync(expectedEntities);

      // Act
      var result = await _controller.Get(searchParam);

      // Assert
      var okResult = result as OkObjectResult;
      okResult.Should().NotBeNull();
      okResult.StatusCode.Should().Be(200);
      okResult.Value.Should().BeEquivalentTo(expectedEntities);
    }

    [Fact]
    public async Task Post_ShouldReturnOk_WhenBusinessCardIsInserted()
    {
      // Arrange
      var newBusinessCard = new BusinessCardInsertParam()
      {
        DOB = DateTime.Parse("10-11-1998"),
        Email = "wardalquraan6@gmail.com",
        Gender = "Male",
        Id = 0,
        Name = "Ward Al Quraan",
        Phone = "0799184039",
      }; // Add actual properties for the business card
      var insertedBusinessCard = new BusinessCard(); // Expected result after insertion

      _mockBusinessCardService.Setup(service => service.InsertAsync(newBusinessCard))
          .ReturnsAsync(insertedBusinessCard);

      // Act
      var result = await _controller.Post(newBusinessCard);

      // Assert
      var okResult = result as OkObjectResult;
      okResult.Should().NotBeNull();
      okResult.StatusCode.Should().Be(200);
      okResult.Value.Should().BeEquivalentTo(insertedBusinessCard);
    }

    [Fact]
    public async Task Delete_ShouldReturnOk_WhenBusinessCardIsDeleted()
    {
      // Arrange
      int idToDelete = 1; // Set the ID of the business card to delete
      bool isDeleted = false; // Mock the deleted business card

      _mockBusinessCardService.Setup(service => service.DeleteAsync(idToDelete))
          .ReturnsAsync(isDeleted);

      // Act
      var result = await _controller.Delete(idToDelete);

      // Assert
      var okResult = result as OkObjectResult;
      okResult.Should().NotBeNull();
      okResult.StatusCode.Should().Be(200);
    }

    [Fact]
    public async Task Export_ShouldReturnCsvFile_WhenFileTypeIsCSV()
    {
      // Arrange
      BusinessCardSearchParam param = new BusinessCardSearchParam();
      param.FileType = FileType.CSV;
      var expectedBytes = Encoding.UTF8.GetBytes("mock data"); // Mock file content

      _mockCsvBase64Service.Setup(service => service.GetBase64(param))
          .ReturnsAsync(expectedBytes);

      // Act
      var result = await _controller.Export(param);

      // Assert
      var fileResult = result as FileContentResult;
      fileResult.Should().NotBeNull();
      fileResult.ContentType.Should().Be("text/csv");
      fileResult.FileDownloadName.Should().Be("businessCards.csv");
      fileResult.FileContents.Should().BeEquivalentTo(expectedBytes);
    }

    [Fact]
    public async Task Export_ShouldReturnCsvFile_WhenFileTypeIsXML()
    {
      // Arrange
      BusinessCardSearchParam param = new BusinessCardSearchParam();
      param.FileType = FileType.XML;
      var expectedBytes = Encoding.UTF8.GetBytes("mock data"); // Mock file content

      _mockXmlBase64Service.Setup(service => service.GetBase64(param))
          .ReturnsAsync(expectedBytes);

      // Act
      var result = await _controller.Export(param);

      // Assert
      var fileResult = result as FileContentResult;
      fileResult.Should().NotBeNull();
      fileResult.ContentType.Should().Be("application/xml");
      fileResult.FileDownloadName.Should().Be("businessCards.xml");
      fileResult.FileContents.Should().BeEquivalentTo(expectedBytes);
    }






  }




}
