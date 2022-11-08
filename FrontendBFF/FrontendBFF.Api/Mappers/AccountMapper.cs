using FrontendBFF.Api.Dto;
using FrontendBFF.Dal.Models;

namespace FrontendBFF.Api.Mappers;

public static class AccountMapper
{
    public static AccountDto AccountToAccountDto(Account account)
    {
        return new()
        {
            Id = account.Id,
            ProfileId = account.ProfileId,
            Email = account.Email,
            Username = account.Username
        };
    }

    public static Account AccountDtoToAccount(AccountDto account)
    {
        return new()
        {
            Id = account.Id,
            ProfileId = account.ProfileId,
            Email = account.Email,
            Username = account.Username
        };
    }
    
    public static ChangeUsernameDto AccountTochangeUsernameDto(Account account)
    {
        return new()
        {
            AccountId = account.Id,
            Username = account.Username
        };
    }
    
    public static string ChangeUsernameDtoToUsername(ChangeUsernameDto usernameDto)
    {
        return usernameDto.Username;
    }
    
    public static long ChangeUsernameDtoToAccountId(ChangeUsernameDto usernameDto)
    {
        return usernameDto.AccountId;
    }
}