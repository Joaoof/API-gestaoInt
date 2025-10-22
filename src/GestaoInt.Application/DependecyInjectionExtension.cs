using GestaoInt.Application.AutoMapper;
using GestaoInt.Application.UseCase.Movements.Register;
using Microsoft.Extensions.DependencyInjection;

namespace GestaoInt.Application;

public static class DependecyInjectionExtension
{
    public static void AddApplication(this IServiceCollection services)
    {
        AddAutoMapper(services);
        AddUseCases(services);
    }

    public static void AddAutoMapper(IServiceCollection services)
    {
        services.AddAutoMapper(typeof(AutoMapping));
    }

    public static void AddUseCases(IServiceCollection services)
    {
        services.AddScoped<IRegisterMovementUseCase, RegisterMovementUseCase>();
    }
}
