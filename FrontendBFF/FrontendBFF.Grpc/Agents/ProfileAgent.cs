using FrontendBFF.Grpc.Agents.Interfaces;
using Grpc.Net.Client;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace FrontendBFF.Grpc.Agents;

public class ProfileAgent : IProfileAgent
{
    private readonly string _address;
    private readonly ILogger<ProfileAgent> _logger;

    public ProfileAgent(IConfiguration configuration, ILogger<ProfileAgent> logger)
    {
        _address = configuration["ProfileService"] ?? "http://localhost:5007";
        _logger = logger;
    }

    public async Task<ProfileResponse> CreateProfile(CreateProfileRequest request)
    {
        using var channel = GrpcChannel.ForAddress(_address);
        var client = new ProfileService.ProfileServiceClient(channel);
        return await client.CreateProfileAsync(request);
    }

    public async Task<ProfileResponse> UpdateProfile(UpdateProfileRequest request)
    {
        using var channel = GrpcChannel.ForAddress(_address);
        var client = new ProfileService.ProfileServiceClient(channel);
        return await client.UpdateProfileAsync(request);
    }
}