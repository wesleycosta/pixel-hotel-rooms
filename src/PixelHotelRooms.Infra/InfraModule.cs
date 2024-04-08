﻿using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PixelHotel.Core.Abstractions;
using PixelHotel.Core.Events.Abstractions;
using PixelHotel.Infra.Abstractions;
using PixelHotelRooms.Domain.CategoryAggregate;
using PixelHotelRooms.Infra.Data;
using PixelHotelRooms.Infra.Data.Repositories;
using PixelHotelRooms.Infra.Extensions;

namespace PixelHotelRooms.Infra;

public class InfraModule : IModuleRegiterWithConfiguration
{
    public IServiceCollection RegisterServices(IServiceCollection services, IConfiguration configuration)
    {
        services.AddContext(configuration);
        services.AddScoped<ICategoryRepository, CategoryRepository>();
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddSingleton<IPublisherEvent, PublisherEvent>(); // TODO: arrumar

        return services;
    }
}