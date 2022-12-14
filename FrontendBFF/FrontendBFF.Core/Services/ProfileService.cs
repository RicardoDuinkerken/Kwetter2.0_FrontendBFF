using FrontendBFF.Core.Mappers;
using FrontendBFF.Core.Services.Interfaces;
using FrontendBFF.Dal.Models;
using FrontendBFF.Grpc.Agents.Interfaces;
using GenericDal;

namespace FrontendBFF.Core.Services;

public class ProfileService : IProfileService
{
    private readonly IAsyncRepository<Profile, long> _profileRepository;
    private readonly IProfileAgent _profileAgent;

    public ProfileService(IAsyncRepository<Profile, long> profileRepository, IProfileAgent profileAgent)
    {
        _profileRepository = profileRepository;
        _profileAgent = profileAgent;
    }


    public async Task<Profile> CreateProfile(Profile profile)
    {
        return ProfileMapper.ProfileResponseToProfile(
            await _profileAgent.CreateProfile(
                ProfileMapper.ProfileToCreateProfileRequest(profile)));
    }

    public async Task<Profile> UpdateProfile(Profile profile)
    {
        return ProfileMapper.ProfileResponseToProfile(
            await _profileAgent.UpdateProfile(
                ProfileMapper.ProfileToUpdateProfileRequest(profile)));
    }
}