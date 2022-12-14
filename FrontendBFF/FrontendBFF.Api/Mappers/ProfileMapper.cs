using FrontendBFF.Api.Dto.ProfileDto;
using FrontendBFF.Dal.Models;

namespace FrontendBFF.Api.Mappers;

public static class ProfileMapper
{
    public static CreateProfileDto ProfileToCreateProfileDto(Profile profile)
    {
        return new()
        {
            Username = profile.Username
        };
    }
    
    public static Profile CreateProfileDtoToProfile(CreateProfileDto profile)
    {
        return new()
        {
            Username = profile.Username
        };
    }
    
    public static UpdateProfileDto ProfileToUpdateProfileDto(Profile profile)
    {
        return new()
        {
            Id = profile.Id,
            Username = profile.Username,
            Location = profile.Location,
            WebLink = profile.WebLink,
            Age = profile.Age,
            Bio = profile.Bio
        };
    }
    
    public static Profile UpdateProfileDtoToProfile(UpdateProfileDto profile)
    {
        return new()
        {
            Id = profile.Id,
            Username = profile.Username,
            Location = profile.Location,
            WebLink = profile.WebLink,
            Age = profile.Age,
            Bio = profile.Bio
        };
    }
}