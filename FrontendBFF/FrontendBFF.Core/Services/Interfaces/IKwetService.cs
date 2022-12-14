using FrontendBFF.Dal.Models;

namespace FrontendBFF.Core.Services.Interfaces;

public interface IKwetService
{
    Task<Kwet> CreateKwet (Kwet kwet);
    Task<Kwet> UpdateKwet (Kwet kwet);
    Task<long> DeleteKwet (Kwet kwet);
}