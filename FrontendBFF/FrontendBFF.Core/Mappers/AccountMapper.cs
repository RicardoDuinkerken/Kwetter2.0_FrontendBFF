using FrontendBFF.Dal.Models;
using FrontendBFF.Grpc;

namespace FrontendBFF.Core.Mappers;

public static class AccountMapper
{
    public static CreateAccountRequest AccountToCreateAccountRequest(Account account)
    {
        return new()
        {
            Email = account.Email,
            Username = account.Username
        };
    }

    public static Account AccountResponseToAccount(AccountResponse response)
    {
        return new()
        {
            Id = response.Id,
            ProfileId = response.ProfileId,
            Email = response.Email,
            Username = response.Username
        };
    }
}