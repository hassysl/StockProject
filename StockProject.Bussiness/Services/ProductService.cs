using FluentValidation;
using StockProject.Bussiness.Interfaces;
using StockProject.Common;
using StockProject.Dtos.ProductDtos;
using StockProject.Entities.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockProject.Bussiness.Services
{
    public class ProductService : IProductService
    {
        private readonly IValidator<ProductCreateDto> _createDtoValidator;
        private readonly IValidator<ProductUpdateDto> _updateDtoValidator;
        private readonly IProductRepository _repo;

        public ProductService(IValidator<ProductCreateDto> createDtoValidator, IValidator<ProductUpdateDto> updateDtoValidator, IProductRepository repo)
        {
            _createDtoValidator = createDtoValidator;
            _updateDtoValidator = updateDtoValidator;
            _repo = repo;
        }

        public async Task<IResponse<ProductCreateDto>> CreateAsync(ProductCreateDto dto)
        {
            var result = _createDtoValidator.Validate(dto);
            if (result.IsValid)
            {
                //mapleme
                var mappedEntity = new Product()
                {
                    Name = dto.Name,
                    Price = dto.Price,
                    Stock = dto.Stock,
                    CategoryId = dto.CategoryId,
                };

                await _repo.CreateAsync(mappedEntity);
                return new Response<ProductCreateDto>(true, dto);
            }
            return new Response<ProductCreateDto>(false, dto);
        }

        public async Task<IResponse<List<ProductListDto>>> GetAllAsync()
        {
            var data = await _repo.GetAllAsync();
            var listDto = new List<ProductListDto>();
            foreach (var item in data)
            {
                listDto.Add(new ProductListDto
                {
                    Id = item.Id,
                    Name = item.Name,
                    Price = item.Price,
                    Stock = item.Stock,
                    CategoryId = item.CategoryId,

                });
            }

            return new Response<List<ProductListDto>>(true, listDto);
        }

        public async Task<IResponse<Product>> GetByIdAsync<IDto>(int id)
        {
            var data = await _repo.GetByFilterAsync(x => x.Id == id);
            if (data == null)
                return new Response<Product>(false, data);
            return new Response<Product>(true, data);
        }

        public async Task<IResponse> RemoveAsync(int id)
        {
            var data = await _repo.GetByFilterAsync(x => x.Id == id);
            if (data == null)
                return new Response(false);
            _repo.Remove(data);
            return new Response(true);
        }

        public async Task<IResponse<ProductUpdateDto>> UpdateAsync(ProductUpdateDto dto)
        {
            var result = _updateDtoValidator.Validate(dto);
            if (result.IsValid)
            {
                var unchangedData = await _repo.GetByFilterAsync(x => x.Id == dto.Id); //.FindAsync(x);
                if (unchangedData == null)
                {
                    return new Response<ProductUpdateDto>(false, dto);
                }
                var entity = new Product()
                {
                    Id = dto.Id,
                    Name = dto.Name,
                    Price = dto.Price,
                    Stock = dto.Stock,
                    CategoryId = dto.CategoryId,
                };
                _repo.Update(entity, unchangedData);
                return new Response<ProductUpdateDto>(true, dto);
            }
            return new Response<ProductUpdateDto>(false, dto);
        }
    }
}
