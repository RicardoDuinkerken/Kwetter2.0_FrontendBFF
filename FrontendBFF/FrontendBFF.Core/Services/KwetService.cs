using FrontendBFF.Core.Mappers;
using FrontendBFF.Core.Services.Interfaces;
using FrontendBFF.Dal.Models;
using FrontendBFF.Grpc.Agents.Interfaces;
using GenericDal;

namespace FrontendBFF.Core.Services;

public class KwetService : IKwetService
{
    private readonly IAsyncRepository<Kwet, long> _kwetRepository;
    private readonly IKwetAgent _kwetAgent;

    public KwetService(IAsyncRepository<Kwet, long> kwetRepository, IKwetAgent kwetAgent)
    {
        _kwetRepository = kwetRepository;
        _kwetAgent = kwetAgent;
    }

    public async Task<Kwet> CreateKwet(Kwet kwet)
    {
        return KwetMapper.KwetResponseToKwet(
            await _kwetAgent.CreateKwet(
                KwetMapper.KwetToCreateKwetRequest(kwet)));
    }

    public async Task<Kwet> UpdateKwet(Kwet kwet)
    {
        return KwetMapper.KwetResponseToKwet(
            await _kwetAgent.UpdateKwet(
                KwetMapper.KwetToUpdateKwetRequest(kwet)));
    }

    public async Task<long> DeleteKwet(Kwet kwet)
    {
        return KwetMapper.DeleteKwetResponseToLong(
            await _kwetAgent.DeleteKwet(
                KwetMapper.KwetToDeleteKwetRequest(kwet)));
    }
}