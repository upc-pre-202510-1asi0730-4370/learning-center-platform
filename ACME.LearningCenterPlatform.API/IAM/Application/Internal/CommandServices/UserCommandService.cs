using ACME.LearningCenterPlatform.API.IAM.Application.Internal.OutbountServices;
using ACME.LearningCenterPlatform.API.IAM.Domain.Model.Agggregates;
using ACME.LearningCenterPlatform.API.IAM.Domain.Model.Commands;
using ACME.LearningCenterPlatform.API.IAM.Domain.Repositories;
using ACME.LearningCenterPlatform.API.IAM.Domain.Services;
using ACME.LearningCenterPlatform.API.Shared.Domain.Repositories;

namespace ACME.LearningCenterPlatform.API.IAM.Application.Internal.CommandServices;

public class UserCommandService(
    IUserRepository userRepository,
    ITokenService tokenService,
    IHashingService hashingService,
    IUnitOfWork unitOfWork
    ): IUserCommandService
{
    public async Task<(User user, string token)> Handle(SignInCommand command)
    {
        var user = await userRepository.FindByUsernameAsync(command.Username);
        
        if (user == null || !hashingService.VerifyPassword(command.Password, user.PasswordHash))
            throw new Exception("Invalid username or password");
        
        var token = tokenService.GenerateToken(user);
        return (user, token);
    }

    public async Task Handle(SignUpCommand command)
    {
        if (userRepository.ExistsByUsername(command.Username))
            throw new Exception("Username already exists");
        
        var hashedPassword = hashingService.HashPassword(command.Password);
        var user = new User(command.Username, hashedPassword);
        try
        {
            await userRepository.AddAsync(user);
            await unitOfWork.CompleteAsync();
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
        
    }
}