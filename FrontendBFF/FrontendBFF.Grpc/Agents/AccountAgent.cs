using FrontendBFF.Grpc.Agents.Interfaces;
using Grpc.Net.Client;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace FrontendBFF.Grpc.Agents;

public class AccountAgent : IAccountAgent
{
    private readonly string _address;
    private readonly ILogger<AccountAgent> _logger;

    public AccountAgent(IConfiguration configuration, ILogger<AccountAgent> logger)
    {
        _address = configuration["AccountService"] ?? "http://localhost:5003";
        _logger = logger;
    }

    public async Task<HasProfileResponse> HasProfile(HasProfileRequest request)
    {
        using var channel = GrpcChannel.ForAddress(_address);
        var client = new AccountService.AccountServiceClient(channel);
        return await client.HasProfileAsync(request);
    }

    public async Task<CheckUsernameAvailabilityResponse> CheckAvailabilityUsername(CheckAvailabilityUsernameRequest request)
    {
        using var channel = GrpcChannel.ForAddress(_address);
        var client = new AccountService.AccountServiceClient(channel);
        return await client.CheckAvailabilityUsernameAsync(request);
    }

    public async Task<AccountResponse> ChangeUsername(ChangeUsernameRequest request)
    {
        using var channel = GrpcChannel.ForAddress(_address);
        var client = new AccountService.AccountServiceClient(channel);
        return await client.ChangeUsernameAsync(request);
    }
}