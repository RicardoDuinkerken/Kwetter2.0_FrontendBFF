using FrontendBFF.Grpc.Agents.Interfaces;
using Grpc.Net.Client;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace FrontendBFF.Grpc.Agents;

public class KwetAgent : IKwetAgent
{
    private readonly string _address;
    private readonly ILogger<KwetAgent> _logger;

    public KwetAgent(IConfiguration configuration, ILogger<KwetAgent> logger)
    {
        _address = configuration["KwetService"] ?? "http://localhost:5009";
        _logger = logger;
    }
    
    public async Task<KwetResponse> CreateKwet(CreateKwetRequest request)
    {
        using var channel = GrpcChannel.ForAddress(_address);
        var client = new KwetService.KwetServiceClient(channel);
        return await client.CreateKwetAsync(request);
    }

    public async Task<KwetResponse> UpdateKwet(UpdateKwetRequest request)
    {
        using var channel = GrpcChannel.ForAddress(_address);
        var client = new KwetService.KwetServiceClient(channel);
        return await client.UpdateKwetAsync(request);
    }

    public async Task<DeleteKwetResponse> DeleteKwet(DeleteKwetRequest request)
    {
        using var channel = GrpcChannel.ForAddress(_address);
        var client = new KwetService.KwetServiceClient(channel);
        return await client.DeleteKwetAsync(request);
    }
}