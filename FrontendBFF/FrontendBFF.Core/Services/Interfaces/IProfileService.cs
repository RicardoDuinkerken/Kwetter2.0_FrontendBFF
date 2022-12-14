using FrontendBFF.Dal.Models;

namespace FrontendBFF.Core.Services.Interfaces;

public interface IProfileService
{
    Task<Profile> CreateProfile (Profile profile);
    Task<Profile> UpdateProfile (Profile profile);
}