using BarCode.Data.Interface;
using Domain.Wrappers;

using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using Domain.Model;
using System.Linq;


namespace BarCode.Data
{
    public class BarCodeRepo : IBarCodeRepo
    {
        private const string BaseURL = @"https://api.qrserver.com/v1/";

        public async Task<List<BarCodeData>> GetCodeFromImage(byte[] img)
        {
            var client = new HttpClient();
            var formDataContent = new MultipartFormDataContent();

            var fileContent = new ByteArrayContent(img);
            fileContent.Headers.ContentType = MediaTypeHeaderValue.Parse("multipart/form-data");

            formDataContent.Add(fileContent, "file", "download.png");
            var response = await client.PostAsync(BaseURL +"read-qr-code/", formDataContent);
            var responseContent = await response.Content.ReadAsStringAsync();

            return JsonSerializer.Deserialize<List<BarCodeData>>(responseContent);
        }

        public async Task<byte[]> GetBarCodeImage(string name)
        {
            var client = new HttpClient();
            var url = string.Format(BaseURL +"create-qr-code/?size=150x150&data={0}", name);
            var response = await client.GetAsync(url);
            return await response.Content.ReadAsByteArrayAsync();
        }
    }
}
