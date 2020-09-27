using Domain.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using Domain.Wrappers;
using Domain.Model;
using System.Threading.Tasks;
using BarCode.Data.Interface;
using System.Linq;
using System.Drawing;

namespace Infrastructure.Services
{
    public class BarCodeUtilityService : IBarCodeUtilityService
    {
        private IBarCodeRepo _barCodeRepo;
        public BarCodeUtilityService(IBarCodeRepo barCodeRepo)
        {
            this._barCodeRepo = barCodeRepo;
        }

        public Task<Response<BarCodeData>> SendBarCodImage(CodeReader model)
        {
            var responseData = new  Response<BarCodeData>();
            try
            {
                model.Image = System.IO.File.ReadAllBytes(model.FileURL);
                var apiResponse =  _barCodeRepo.GetCodeFromImage(model.Image);
                responseData.Succeeded = true;
                responseData.Data = apiResponse.Result;
                responseData.Message = "Success";
            }

            catch (Exception ex)
            {
                responseData.Succeeded = false;
                responseData.Errors.Add(ex.Message);
                responseData.Message = "Error in getting data";
            }

            return Task.FromResult(responseData);

        }

        public Task<Response<byte>> GetBarCodeImage(string name)
        {
            var responseData = new Response<byte>();
            var imgData=_barCodeRepo.GetBarCodeImage(name);
            responseData.Image = imgData.Result;
            return Task.FromResult(responseData);
        }
    }
}
