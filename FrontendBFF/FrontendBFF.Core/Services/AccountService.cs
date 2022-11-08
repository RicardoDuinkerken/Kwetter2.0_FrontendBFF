using FrontendBFF.Core.Mappers;
using FrontendBFF.Core.Services.Interfaces;
using FrontendBFF.Dal.Models;
using FrontendBFF.Grpc.Agents.Interfaces;
using GenericDal;

namespace FrontendBFF.Core.Services;

public class AccountService : IAccountService
{
    private readonly IAsyncRepository<Account, long> _accountRepository;
    private readonly IAccountAgent _accountAgent;

    public AccountService(IAsyncRepository<Account, long> accountRepository, IAccountAgent accountAgent)
    {
        _accountRepository = accountRepository;
        _accountAgent = accountAgent;   
    }

    public async Task<bool> HasProfile(long accountId)
    {
        return AccountMapper.HasProfileResponseToBool(await _accountAgent.HasProfile(AccountMapper.IdToHasProfileRequest(accountId)));
    }
    
    public async Task<bool> CheckAvailabilityUsername(string username)
    {
         return AccountMapper.CheckUsernameAvailabilityResponseToBool(await _accountAgent.CheckAvailabilityUsername(AccountMapper.UsernameToCheckAvailabilityUsernameRequest(username)));
    }

    public async Task<Account> ChangeUsername(long accountId, string username)
    {
        return AccountMapper.AccountResponseToAccount(
            await _accountAgent.ChangeUsername(
                AccountMapper.IdAndUsernameToChangeUsernameRequest(accountId, username)));
    }
}