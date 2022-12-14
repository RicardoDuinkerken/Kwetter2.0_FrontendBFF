namespace FrontendBFF.Grpc.Agents.Interfaces;

public interface IKwetAgent
{
    Task<KwetResponse> CreateKwet(CreateKwetRequest request);
    Task<KwetResponse> UpdateKwet(UpdateKwetRequest request);
    Task<DeleteKwetResponse> DeleteKwet(DeleteKwetRequest request);
}