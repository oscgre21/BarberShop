using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BarberShop.API.Controllers.Base;
using BarberShop.BL.DTOs.ViewModel;
using BarberShop.Services.Demo;
using BarberShop.BL.DTOs.Global;
using BarberShop.Services.Global;

namespace BarberShop.API.Controllers.Global
{
    public class ServicesController :   BaseMinApiController
    {

        IProductServices _product;
        public ServicesController(IProductServices demo)
        {
            _product = demo;
        }

        [HttpGet]
        [Route("getProductAndServices")]
        public async Task<IActionResult> getProductAndServices()
        {
            var model = await _product.getProductAndServices();
            return Ok(model);
        }


        [HttpGet]
        [Route("getServices")]
        public async Task<IActionResult> getServices()
        {
             var model = await _product.getListServices();
            return Ok(model);
        }
        [HttpGet]
        [Route("getProducts")]
        public async Task<IActionResult> getProducts()
        {
            var model = await _product.getListProducts();
            return Ok(model);
        }
        #region CRUD
        [HttpGet]
        [Route("get")]
        public async Task<IActionResult> get()
        {
            //var model = await _demo.GetListOf();
            return Ok("Ok");
        }

        [HttpGet]
        [Route("getByID")]
        public async Task<IActionResult> getByID(Guid ids)
        {
            // var model = await _demo.GetOfByID(ids);
            return Ok();
        }
        [HttpPost]
        [Route("save")]
        public async Task<IActionResult> save([FromBody] DemoDto obj)
        {
            if (ModelState.IsValid)
            {
                //var info = await _demo.SaveOf(obj);
                return Ok();
            }

            return NotFound();
        }

        #endregion

    }


}
