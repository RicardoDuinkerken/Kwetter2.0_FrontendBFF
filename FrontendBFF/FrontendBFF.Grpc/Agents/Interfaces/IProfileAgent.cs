namespace FrontendBFF.Grpc.Agents.Interfaces;

public interface IProfileAgent
{
    Task<ProfileResponse> CreateProfile(CreateProfileRequest request);
    Task<ProfileResponse> UpdateProfile(UpdateProfileRequest request);
}