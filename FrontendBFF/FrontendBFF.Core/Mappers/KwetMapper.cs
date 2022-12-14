using FrontendBFF.Dal.Models;
using FrontendBFF.Grpc;

namespace FrontendBFF.Core.Mappers;

public static class KwetMapper
{
    public static Kwet KwetResponseToKwet(KwetResponse response)
    {
        return new()
        {
            Id = response.Id,
            Username = response.Username,
            Content = response.Content
        };
    }

    public static CreateKwetRequest KwetToCreateKwetRequest(Kwet kwet)
    {
        return new()
        {
            Username = kwet.Username,
            Content = kwet.Content
        };
    }

    public static UpdateKwetRequest KwetToUpdateKwetRequest(Kwet kwet)
    {
        return new()
        {
            Id = kwet.Id,
            Username = kwet.Username,
            Content = kwet.Content
        };
    }

    public static DeleteKwetRequest KwetToDeleteKwetRequest(Kwet kwet)
    {
        return new()
        {
            Id = kwet.Id
        };
    }

    public static long DeleteKwetResponseToLong(DeleteKwetResponse response)
    {
        return response.Id;
    }
}