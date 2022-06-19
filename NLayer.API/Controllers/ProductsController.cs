using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NLayer.Core;
using NLayer.Core.DTOs;
using NLayer.Core.Services;

namespace NLayer.API.Controllers
{
   
    public class ProductsController : CustomBaseController
    {
        private readonly IMapper _mapper;
        private readonly IService<Product> _service;
        private readonly IProductService _productService;
        public ProductsController(IService<Product> service, IMapper mapper, Core.Services.IProductService productService)
        {
            _service = service;
            _mapper = mapper;
            _productService = productService;
        }

        [HttpGet("[action]")] //  otomatik olarak methodun adını alır.
        public async Task<IActionResult> GetProductWithCategory()
        {
            return CreateActionResult(await _productService.GetProductWithCategory());
        }

        [HttpGet]
        public async Task<IActionResult> All()
        {
            var products=await _service.GetAllAsync();
            var productsDto = _mapper.Map<List<ProductDTO>>(products);
            return CreateActionResult(CustomResponseDTO<List<ProductDTO>>.Success(200,productsDto));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var product = await _service.GetByIdAsync(id);
            if (product is null)
            {
                return CreateActionResult(CustomResponseDTO<NoContentDTO>.Fail(404, "Bu id'ye sahip ürün bulunamadı"));
            }
            var productDto = _mapper.Map<ProductDTO>(product);
            return CreateActionResult(CustomResponseDTO<ProductDTO>.Success(200, productDto));
        }


        [HttpPost()]
        public async Task<IActionResult> Save(ProductDTO productDto)
        {
            var product = await _service.AddAsync(_mapper.Map<Product>(productDto));
            var productsDto = _mapper.Map<ProductDTO>(product);
            return CreateActionResult(CustomResponseDTO<ProductDTO>.Success(201, productsDto));
        }

        [HttpPut()]
        public async Task<IActionResult> Update(ProductUpdateDTO productUpdateDto)
        {
            await _service.UpdateAsync(_mapper.Map<Product>(productUpdateDto));
            return CreateActionResult(CustomResponseDTO<NoContentDTO>.Success(204));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var product= await _service.GetByIdAsync(id);   

            if(product is null)
            {
                return CreateActionResult(CustomResponseDTO<NoContentDTO>.Fail(404, "Bu id'ye sahip ürün bulunamadı"));
            }

            await _service.RemoveAsync(_mapper.Map<Product>(product));
            return CreateActionResult(CustomResponseDTO<List<NoContentDTO>>.Success(204));
        }





    }
}
