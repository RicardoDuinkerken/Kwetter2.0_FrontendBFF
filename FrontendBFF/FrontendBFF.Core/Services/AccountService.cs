using FrontendBFF.Core.Services.Interfaces;
using FrontendBFF.Dal.Models;
using GenericDal;

namespace FrontendBFF.Core.Services;

public class AccountService : IAccountService
{
    private readonly IAsyncRepository<Account, long> _accountRepository;

    public AccountService(IAsyncRepository<Account, long> accountRepository)
    {
        _accountRepository = accountRepository;
    }

    public async Task<List<Account>> GetAccounts()
    {
        return await _accountRepository.GetAllAsync();
    }

    public async Task<Account> GetAccountById(long id)
    {
        return await _accountRepository.GetByIdAsync(id);
    }

    public async Task<Account> GetAccountByEmail(string email)
    {
        return await _accountRepository.FirstOrDefaultAsync(p => p.Email == email);
    }

    public async Task<Account> CreateAccount(Account account)
    {
        return await _accountRepository.CreateAsync(account);
    }

    public Task<Account> UpdateAccount(Account account)
    {
        throw new NotImplementedException();
    }

    public Task<bool> DeleteAccount(Account account)
    {
        throw new NotImplementedException();
    }
}