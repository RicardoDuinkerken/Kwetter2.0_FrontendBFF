namespace FrontendBFF.Grpc.Agents.Interfaces;

public interface IAccountAgent
{
    Task<HasProfileResponse> HasProfile(HasProfileRequest request);
    Task<CheckUsernameAvailabilityResponse> CheckAvailabilityUsername(CheckAvailabilityUsernameRequest request);
    Task<AccountResponse> ChangeUsername(ChangeUsernameRequest request);
}