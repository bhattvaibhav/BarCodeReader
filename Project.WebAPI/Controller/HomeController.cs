using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Interface;
using Domain.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Net.Http;
using Newtonsoft.Json;
using System.Drawing;
using System.Net;

namespace Project.WebAPI.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private IBarCodeUtilityService _barCodeUtilityService;

        public HomeController(IBarCodeUtilityService barCodeUtilityService)
        {
            _barCodeUtilityService = barCodeUtilityService;
        }


        [HttpGet]
        public async Task<IActionResult> GetDataFromImage()
        {
            var codeReader = new CodeReader();
            codeReader.FileURL = @"F:\download.png";
            var response = await _barCodeUtilityService.SendBarCodImage(codeReader);
            return Ok(response);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> FetchBarCodeImage(string id)
        {
           var result = await _barCodeUtilityService.GetBarCodeImage(id);
           return File(result.Image, "image/png"); 
        }
    }
}
