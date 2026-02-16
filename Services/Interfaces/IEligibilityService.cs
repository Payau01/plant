namespace Clgproj.Services.Interfaces
{
    public interface IEligibilityService
    {
        Task<(bool IsEligible, string Reason)>
           ValidateAsync(int farmerId, int schemeId);

    }
}
