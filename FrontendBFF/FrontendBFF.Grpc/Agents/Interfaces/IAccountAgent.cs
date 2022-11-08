namespace FrontendBFF.Grpc.Agents.Interfaces;

public interface IAccountAgent
{
    Task<AccountResponse> CreateAccount(CreateAccountRequest account);
    Task<HasProfileResponse> HasProfile(HasProfileRequest request);
    Task<CheckUsernameAvailabilityResponse> CheckAvailabilityUsername(CheckAvailabilityUsernameRequest request);
}