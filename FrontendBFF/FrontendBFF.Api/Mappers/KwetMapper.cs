using FrontendBFF.Api.Dto.KwetDto;
using FrontendBFF.Api.Dto.ProfileDto;
using FrontendBFF.Dal.Models;
using Grpc.Core;

namespace FrontendBFF.Api.Mappers;

public class KwetMapper
{
    public static CreateKwetDto ProfileToCreateProfileDto(Kwet kwet)
    {
        return new()
        {
            Username = kwet.Username,
            Content = kwet.Content
        };
    }
    
    public static Kwet CreateKwetDtoToKwet(CreateKwetDto kwet)
    {
        return new()
        {
            Username = kwet.Username,
            Content = kwet.Content
        };
    }
    
    public static UpdateKwetDto KwetToUpdateKwetDto(Kwet kwet)
    {
        return new()
        {
            Id = kwet.Id,
            Username = kwet.Username,
            Content = kwet.Content
        };
    }
    
    public static Kwet UpdateKwetDtoToKwet(UpdateKwetDto kwet)
    {
        return new()
        {
            Id = kwet.Id,
            Username = kwet.Username,
            Content = kwet.Content
        };
    }

    public static DeleteKwetDto KwetToDeleteKwetDto(Kwet kwet)
    {
        return new()
        {
            Id = kwet.Id
        };
    }

    public static Kwet DeleteKwetDtoToKwet(DeleteKwetDto kwet)
    {
        return new()
        {
            Id = kwet.Id
        };
    }
}