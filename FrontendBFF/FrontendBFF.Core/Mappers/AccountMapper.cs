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

    public static HasProfileRequest IdToHasProfileRequest(long id)
    {
        return new()
        {
            AccountId = id
        };
    }

    public static bool HasProfileResponseToBool(HasProfileResponse response)
    {
        return response.HasProfile;
    }

    public static CheckAvailabilityUsernameRequest UsernameToCheckAvailabilityUsernameRequest(string username)
    {
        return new()
        {
            Username = username
        };
    }
    
    public static bool CheckUsernameAvailabilityResponseToBool(CheckUsernameAvailabilityResponse response)
    {
        return response.Available;
    }

    public static ChangeUsernameRequest IdAndUsernameToChangeUsernameRequest(long accountId, string username)
    {
        return new()
        {
            Id = accountId,
            Username = username
        };
    }
}