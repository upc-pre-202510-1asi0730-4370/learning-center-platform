using ACME.LearningCenterPlatform.API.IAM.Domain.Model.Agggregates;

namespace ACME.LearningCenterPlatform.API.IAM.Application.Internal.OutbountServices;

public interface ITokenService
{
    string GenerateToken(User user);

    Task<int?> ValidateToken(string token);
}