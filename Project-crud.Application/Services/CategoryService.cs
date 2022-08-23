using AutoMapper;
using ProjectCrud.Domain.DTOs;
using ProjectCrud.Domain.Entity;
using ProjectCrud.Domain.Repository;
using ProjectCrud.Domain.Validations;

namespace ProjectCrud.Application.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly IMapper _mapper;
        private readonly ICategoryRepository _categoryRepository;

        public CategoryService(IMapper mapper,
            ICategoryRepository categoryRepository)
        {
            _mapper = mapper;
            _categoryRepository = categoryRepository;
        }

        public async Task<ResultService<CategoryDto>> CreateAsync(CategoryDto categoryDto)
        {
            if (categoryDto == null)
                return ResultService.Fail<CategoryDto>("A categoria deve ser informada");

            var validationResult = await new CategoryDtoValidator().ValidateAsync(categoryDto);
            if (!validationResult.IsValid)
                return ResultService.RequestError<CategoryDto>("Um ou mais erros foram encontrados", validationResult);


            var categoryPersist = await _categoryRepository.CreateAsync(_mapper.Map<Category>(categoryDto));
            var categoryDtoMapped = _mapper.Map<CategoryDto>(categoryPersist);
            return ResultService.Ok(categoryDtoMapped);
        }

        public async Task<ResultService> DeleteAsync(Guid categoryId)
        {
            if (categoryId == Guid.Empty)
                return ResultService.Fail<CategoryDto>("Id deve ser informado");

            var category = await _categoryRepository.FindByIdAsync(categoryId);
            if (category == null)
                return ResultService.Fail<CategoryDto>("Categoria não encontrada");

            if (await _categoryRepository.DeleteAsync(category))
                return ResultService.Ok("Categoria deletada com sucesso");

            return ResultService.Fail<CategoryDto>("Ocorreu um erro ao remover categoria");
        }

        public async Task<ResultService<CategoryDto>> FindByIdAsync(Guid categoryId)
        {
            if (categoryId == Guid.Empty)
                return ResultService.Fail<CategoryDto>("Id deve ser informado");

            var category = await _categoryRepository.FindByIdAsync(categoryId);
            if (category == null)
                return ResultService.Fail<CategoryDto>("Categoria não encontrada");

            var categoryMapped = _mapper.Map<CategoryDto>(category);
            return ResultService.Ok(categoryMapped);
        }

        public async Task<ResultService<ICollection<CategoryDto>>> FindAllAsync()
        {
            var categories = await _categoryRepository.FindAllAsync();
            return ResultService.Ok(_mapper.Map<ICollection<CategoryDto>>(categories));
        }
    }
}
