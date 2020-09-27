using Domain.Model;
using Domain.Wrappers;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interface
{
   public interface IBarCodeUtilityService
    {
       Task<Response<BarCodeData>>SendBarCodImage(CodeReader model);
       Task<Response<byte>> GetBarCodeImage(string name);     
    }
}
