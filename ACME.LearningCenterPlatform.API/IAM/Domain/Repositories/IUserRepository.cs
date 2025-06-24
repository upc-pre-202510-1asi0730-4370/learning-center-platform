using ACME.LearningCenterPlatform.API.IAM.Domain.Model.Agggregates;
using ACME.LearningCenterPlatform.API.Shared.Domain.Repositories;

namespace ACME.LearningCenterPlatform.API.IAM.Domain.Repositories;

public interface IUserRepository : IBaseRepository<User>
{
    
    Task<User?> FindByUsernameAsync(string username);
    
    bool ExistsByUsername(string username);
    
}