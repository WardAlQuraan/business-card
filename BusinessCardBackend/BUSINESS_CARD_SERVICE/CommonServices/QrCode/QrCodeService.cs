using BUSINESS_CARD_ENTITIES;
using Microsoft.AspNetCore.Http;
using ZXing;
using System.Drawing;
using BUSINESS_CARD_SERVICE.CommonServices.QrCode;
using Newtonsoft.Json;
using ZXing.QrCode;
using ZXing.Common;

namespace BUSINESS_CARD_SERVICE.CommonServices
{
  public class QrCodeService : IQrCodeService
  {
    public async Task<byte[]> GetBase64(BusinessCard businessCard)
    {
      businessCard.Base64 = null;

      string json = JsonConvert.SerializeObject(businessCard);

      var qrCodeWriter = new QRCodeWriter();
      BitMatrix qrCode = qrCodeWriter.encode(json, BarcodeFormat.QR_CODE, 300, 300);

      using (var bitmap = new Bitmap(qrCode.Width, qrCode.Height))
      {
        for (int x = 0; x < qrCode.Width; x++)
        {
          for (int y = 0; y < qrCode.Height; y++)
          {
            // Use the indexer to get the pixel value
            bitmap.SetPixel(x, y, qrCode[x, y] ? Color.Black : Color.White);
          }
        }

        // Convert Bitmap to byte array
        using (var ms = new MemoryStream())
        {
          bitmap.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
          return ms.ToArray(); // Return the byte array of the QR code image
        }
      }

    }
    public async Task<BusinessCard?> GetBusinessCard(IFormFile file)
    {
      var reader = new BarcodeReaderGeneric();
      using (var stream = file.OpenReadStream())
      {
        // Load the image from the stream
        using (var bitmap = new Bitmap(stream))
        {
          LuminanceSource source = new ZXing.Windows.Compatibility.BitmapLuminanceSource(bitmap);
          Result result = reader.Decode(source);
          if (result is not null)
          {
            var qrData = result.Text;
            try
            {

              var businessCard = JsonConvert.DeserializeObject<BusinessCard>(qrData);
              return businessCard;
            }
            catch
            {
              throw new Exception("Invalid Qr Code");

            }
          }
          else
          {
            throw new Exception("Invalid Qr Code");
          }
        }
      }
    }

  }



}
