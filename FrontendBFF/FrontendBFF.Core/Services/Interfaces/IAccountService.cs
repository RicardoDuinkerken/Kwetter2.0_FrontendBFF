using FrontendBFF.Dal.Models;

namespace FrontendBFF.Core.Services.Interfaces;

public interface IAccountService
{
    // Task<List<Account>> GetAccounts();
    // Task<Account> GetAccountById(long id);
    // Task<Account> GetAccountByEmail(String email);
    Task<Account> CreateAccount(Account account);
    // Task<Account> UpdateAccount(Account account);
    // Task<bool> DeleteAccount(Account account);
}   