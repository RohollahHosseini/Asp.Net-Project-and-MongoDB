using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using Product_Management.Models.Product;
using Product_Management.Repositories.Conteracts.Common;

namespace Product_Management.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductManagementController(IUnitOfWork unitOfWork) :ControllerBase
    {

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result=await unitOfWork.productService.GetAllAsync();

            return Ok(result);
        }

        [HttpGet("GetProductById")]
        public async Task<IActionResult> GetProductByIdAsync(string id)
        {
            var result=await unitOfWork.productService.GetByIdAsync(id);

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Post(ProductEntity entity)
        {
            var resutl=await unitOfWork.productService.CreateAsync(entity);

            return Ok(resutl);
        }



        [HttpDelete]
        public async Task<IActionResult>Delete(string id)
        {
            var result = await unitOfWork.productService.DeleteAsync(id);

            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> Put(ProductEntity model)
        {
            var result=await unitOfWork.productService.UpdateAsync(model.ProductId, model);

            return Ok(result);   
        }
    }
}
