using FrontendBFF.Dal.Models;
using FrontendBFF.Grpc;

namespace FrontendBFF.Core.Mappers;

public static class ProfileMapper
{
    public static Profile ProfileResponseToProfile(ProfileResponse response)
    {
        return new()
        {
            Id = response.Id,
            Username = response.Username,
            Age = response.Age,
            Bio = response.Bio,
            Location = response.Location,
            WebLink = response.Weblink
        };
    }

    public static CreateProfileRequest ProfileToCreateProfileRequest(Profile profile)
    {
        return new()
        {
            Username = profile.Username
        };
    }

    public static UpdateProfileRequest ProfileToUpdateProfileRequest(Profile profile)
    {
        return new()
        {
            Id = profile.Id,
            Username = profile.Username,
            Age = profile.Age,
            Location = profile.Location,
            Bio = profile.Bio,
            Weblink = profile.WebLink
        };
    }
}