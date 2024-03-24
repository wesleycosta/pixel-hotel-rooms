﻿using PixelHotel.Core.Services;
using PixelHotelRooms.Application.Abstractions;
using PixelHotelRooms.Application.Responses;
using PixelHotelRooms.Domain.Aggregates;
using PixelHotelRooms.Domain.Repositories;

namespace PixelHotelRooms.Application.Services;

internal sealed class CategoryService : QueryServiceBase, ICategoryService
{
    private readonly ICategoryRepository _categoryRepository;
    private readonly ICategoryMapper _categoryMapper;

    public CategoryService(ICategoryRepository categoryRepository,
        ICategoryMapper categoryMapper)
    {
        _categoryRepository = categoryRepository;
        _categoryMapper = categoryMapper;
    }

    public async Task<Result> GetById(Guid id)
    {
        var categoryResponse = await GetCategoryResponseById(id);
        if (categoryResponse is null)
        {
            return NotFoundResult(nameof(Category));
        }

        return SuccessfulResult(categoryResponse);
    }

    private async Task<CategoryResponse> GetCategoryResponseById(Guid id)
        => await _categoryRepository.GetFirstByExpression(category => category.Id == id,
            p => _categoryMapper.MapToCategoryResponse(p));
}