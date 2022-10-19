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

    public async Task<Account> CreateAccount(Account account)
    {
        return await _accountRepository.CreateAsync(AccountMapper.AccountResponseToAccount(
            await _accountAgent.CreateAccount(AccountMapper.AccountToCreateAccountRequest(account))));
    }
}