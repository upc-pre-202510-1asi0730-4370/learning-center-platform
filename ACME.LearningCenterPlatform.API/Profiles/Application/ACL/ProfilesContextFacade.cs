using ACME.LearningCenterPlatform.API.Profiles.Domain.Model.Commands;
using ACME.LearningCenterPlatform.API.Profiles.Domain.Model.Queries;
using ACME.LearningCenterPlatform.API.Profiles.Domain.Model.ValueObjects;
using ACME.LearningCenterPlatform.API.Profiles.Domain.Services;
using ACME.LearningCenterPlatform.API.Profiles.Interfaces.REST;

namespace ACME.LearningCenterPlatform.API.Profiles.Application.ACL;

public class ProfilesContextFacade(
    IProfileCommandService profileCommandService,
    IProfileQueryService profileQueryService
    ) :  IProfilesContextFacade
{
    public async Task<int> CreateProfile(string firstName, string lastName, string email, string street, string number, string city,
        string postalCode, string country)
    {
        var createProfileCommand = new CreateProfileCommand(
            firstName, lastName, email, street, number, city, postalCode, country);
        var profile = await profileCommandService.Handle(createProfileCommand);
        return profile?.Id ?? 0;
    }

    public async Task<int> FetchProfileIdByEmail(string email)
    {
        var getProfileByEmailQuery = new GetProfileByEmailQuery(new EmailAddress(email));
        var profile = await profileQueryService.Handle(getProfileByEmailQuery);
        return profile?.Id ?? 0;
    }
}