using AutoMapper;
using VShop.ProductApi.DTOs;
using VShop.ProductApi.Models;
using VShop.ProductApi.Repositories;

namespace VShop.ProductApi.Services;

public class ProductService : IProductService
{
    private readonly IProductRepository _productRepository;
    private readonly IMapper _mapper;

    public ProductService(
        IProductRepository productRepository,
        IMapper mapper)
    {
        _productRepository = productRepository;
        _mapper = mapper;
    }

    public async Task AddProduct(ProductDTO dto)
    {
        var entity = _mapper.Map<Product>(dto);
        await _productRepository.Add(entity);
        dto.Id = entity.Id;
    }

    public async Task UpdateProduct(ProductDTO dto)
    {
        var entity = _mapper.Map<Product>(dto);
        await _productRepository.Update(entity);
    }

    public async Task RemoveProduct(Guid id)
    {
        await _productRepository.Delete(id);
    }

    public async Task<ProductDTO> GetProductById(Guid id)
    {
        var entity = await _productRepository.GetById(id);
        return _mapper.Map<ProductDTO>(entity);
    }

    public async Task<IEnumerable<ProductDTO>> GetProducts()
    {
        var entity = await _productRepository.GetAll();
        return _mapper.Map<IEnumerable<ProductDTO>>(entity);
    }
}