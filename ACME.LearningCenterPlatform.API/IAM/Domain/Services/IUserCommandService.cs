using ACME.LearningCenterPlatform.API.IAM.Domain.Model.Agggregates;
using ACME.LearningCenterPlatform.API.IAM.Domain.Model.Commands;

namespace ACME.LearningCenterPlatform.API.IAM.Domain.Services;

public interface IUserCommandService
{
    Task<(User user, string token)> Handle(SignInCommand command);
    
    Task Handle(SignUpCommand command);
}