using AutoMapper;
using GestaoInt.Communication.Request;
using GestaoInt.Communication.Responses;
using GestaoInt.Domain.Entities;

namespace GestaoInt.Application.AutoMapper;

public class AutoMapping: Profile
{
    public AutoMapping()
    {
        RequestToEntity();
        EntityToResponseToEntity();
    }

    private void RequestToEntity()
    {
        CreateMap<RequestMovementJson, Movement>();
    }

    private void EntityToResponseToEntity()
    {
        CreateMap<ResponseRegisterdMovementJson, Movement>();
    }
}
