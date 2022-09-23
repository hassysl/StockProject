using StockProject.Dtos.ProductDtos;
using StockProject.Entities.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockProject.Bussiness.Mappings
{
    public class ProductMapping
    {
        public ProductCreateDto ProductToDtoCreate(Product product)
        {

            return new ProductCreateDto()
            {
                Name = product.Name,
               Price = product.Price,
               Stock = product.Stock,
               CategoryId = product.CategoryId,
            };
        }
        public Product DtoToProductCreate(ProductCreateDto productDto)
        {
            return new Product()
            {
                Name = productDto.Name,
                Price = productDto.Price,
                Stock = productDto.Stock,
                CategoryId = productDto.CategoryId,
            };
        }

        public ProductUpdateDto ProductToDtoUpdate(Product product)
        {
            return new ProductUpdateDto()
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price,
                Stock = product.Stock,
                CategoryId = product.CategoryId,
            };
        }
        public Product DtoToProductUpdate(ProductUpdateDto productDto)
        {
            return new Product()
            {
                Id = productDto.Id,
                Name = productDto.Name,
                Price = productDto.Price,
                Stock = productDto.Stock,
                CategoryId = productDto.CategoryId,
            };
        }

        public ProductListDto ProductoDtoList(Product product)
        {

            return new ProductListDto()
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price,
                Stock = product.Stock,
                CategoryId = product.CategoryId,

            };
        }
        public Product DtoToProductList(ProductListDto productDto)
        {
            return new Product()
            {
                Id = productDto.Id,
                Name = productDto.Name,
                Price = productDto.Price,
                Stock = productDto.Stock,
                CategoryId = productDto.CategoryId,
            };
        }
    }
}
