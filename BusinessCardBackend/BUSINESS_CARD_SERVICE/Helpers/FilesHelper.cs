using BUSINESS_CARD_ENTITIES;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace BUSINESS_CARD_SERVICE.Helpers
{
  public static class FilesHelper
  {
    public static string SerializeToXml<T>(IEnumerable<T> items)
    {
      var xmlSerializer = new XmlSerializer(typeof(List<T>));
      using var stringWriter = new StringWriter();
      xmlSerializer.Serialize(stringWriter, items.ToList());
      return stringWriter.ToString();
    }


    public static string ConvertToCsv<T>(IEnumerable<T> items)
    {
      var stringBuilder = new StringBuilder();

      // Get all properties of BusinessCard excluding NotMapped properties
      var props = typeof(T).GetProperties()
          .Where(p => p.GetCustomAttribute<NotMappedAttribute>() == null)
          .ToArray();

      // Append the header line dynamically based on property names
      stringBuilder.AppendLine(string.Join(',', props.Select(p => p.Name))); // CSV Header

      foreach (var item in items)
      {
        // Use reflection to get property values dynamically
        var values = props.Select(p =>
        {
          var value = p.GetValue(item);
          return value != null ? value.ToString().Replace(",", ";") : ""; // Handle null and escape commas
        });

        stringBuilder.AppendLine(string.Join(',', values));
      }

      return stringBuilder.ToString();
    }



    public static async Task<string> GetBase64(IFormFile file)
    {
      using (var memoryStream = new MemoryStream())
      {
        await file.CopyToAsync(memoryStream); // Copy the IFormFile to a MemoryStream
        var fileBytes = memoryStream.ToArray(); // Get the byte array from the MemoryStream
        var base64String = Convert.ToBase64String(fileBytes); // Convert to Base64 string
        return base64String;
      }
    }
  }
}
