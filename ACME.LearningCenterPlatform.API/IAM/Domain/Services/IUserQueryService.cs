using ACME.LearningCenterPlatform.API.IAM.Domain.Model.Agggregates;
using ACME.LearningCenterPlatform.API.IAM.Domain.Model.Queries;

namespace ACME.LearningCenterPlatform.API.IAM.Domain.Services;

public interface IUserQueryService
{
    Task<User?> Handle(GetUserByIdQuery query);
    
    Task<IEnumerable<User>> Handle(GetAllUsersQuery query);
    
    Task<User?> Handle(GetUserByUsernameQuery query);
}