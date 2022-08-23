using AutoMapper;
using ProjectCrud.Domain.DTOs;
using ProjectCrud.Domain.Entity;
using ProjectCrud.Domain.Repository;
using ProjectCrud.Domain.Validations;

namespace ProjectCrud.Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public ProductService(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<ResultService<ProductDto>> CreateAsync(ProductDto productDto)
        {
            if (productDto == null)
                return ResultService.Fail<ProductDto>("Objeto nao pode ser nullo");

            var result = await new ProductDtoValidator().ValidateAsync(productDto);
            if (!result.IsValid)
                return ResultService.RequestError<ProductDto>("Um ou mais erros foram encontrados", result);

            var productPersist = await _productRepository.CreateAsync(_mapper.Map<Product>(productDto));
            var ProductDtoPersistido = _mapper.Map<ProductDto>(productPersist);

            return ResultService.Ok(ProductDtoPersistido);
        }

        public async Task<ResultService> DeleteAsync(Guid productId)
        {
            if (productId == Guid.Empty)
                return ResultService.Fail<ProductDto>("Id do product deve ser informado");

            var product = await _productRepository.FindByIdAsync(productId);
            if (product == null)
                return ResultService.Fail("Produto nao encontrado");

            if (await _productRepository.DeleteAsync(product))
                return ResultService.Ok("Produto removido com sucesso");

            return ResultService.Fail("Ocorreu um erro ao remover o Produto");
        }

        public async Task<ResultService> UpdateAsync(ProductDto ProductDto)
        {
            if (ProductDto.Id == Guid.Empty)
                return ResultService.Fail<ProductDto>("ID precisa ser informado");

            var result = await new ProductDtoValidator().ValidateAsync(ProductDto);
            if (!result.IsValid)
                return ResultService.RequestError<ProductDto>("Um ou mais erros foram encontrados", result);

            var product = await _productRepository.FindByIdAsync(ProductDto.Id);
            if (product == null)
                return ResultService.Fail("Produto nao encontrado");

            //Mapeando propriedades informadas para edição, na entidade ja existente no banco!
            var productUpdated = _mapper.Map(ProductDto, product);

            if (await _productRepository.UpdateAsync(productUpdated))
                return ResultService.Ok("Produto alterado com sucesso");

            return ResultService.Fail("Ocorreu um erro ao editar o Produto");
        }

        public async Task<ResultService> FindByIdAsync(Guid productId)
        {
            if (productId == Guid.Empty)
                return ResultService.Fail<ProductDto>("Id do Produto deve ser informado");

            var product = await _productRepository.FindByIdAsync(productId);
            if (product == null)
                return ResultService.Fail<ProductDto>("Produto nao encontrado");

            var ProductDto = _mapper.Map<ProductDto>(product);
            return ResultService.Ok(ProductDto);
        }

        public async Task<ResultService<ICollection<ProductDto>>> FindAllAsync()
        {
            var products = await _productRepository.FindAllAsync();
            var productsMapped = _mapper.Map<ICollection<ProductDto>>(products);
            return ResultService.Ok(productsMapped);
        }
    }
}
