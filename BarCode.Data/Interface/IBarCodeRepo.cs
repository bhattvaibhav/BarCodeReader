using Domain.Model;
using Domain.Wrappers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BarCode.Data.Interface
{
    public interface IBarCodeRepo
    {
       Task<List<BarCodeData>> GetCodeFromImage (byte[] img);
        Task<byte[]> GetBarCodeImage(string name);
    }
}
