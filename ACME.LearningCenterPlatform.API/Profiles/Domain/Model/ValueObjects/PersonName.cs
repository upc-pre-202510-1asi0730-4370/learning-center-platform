namespace ACME.LearningCenterPlatform.API.Profiles.Domain.Model.ValueObjects;

public record PersonName(string FirstName, string LastName)
{
    public PersonName() : this(string.Empty, string.Empty)
    {
        
    }

    public string FullName => $"{FirstName} {LastName}";
}