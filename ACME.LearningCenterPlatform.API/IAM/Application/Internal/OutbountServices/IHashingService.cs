namespace ACME.LearningCenterPlatform.API.IAM.Application.Internal.OutbountServices;

public interface IHashingService
{
    string HashPassword(string password);
    
    bool VerifyPassword(string password, string passwordHash);
}