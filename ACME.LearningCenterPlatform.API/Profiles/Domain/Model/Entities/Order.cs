using ACME.LearningCenterPlatform.API.Profiles.Domain.Model.Aggregates;

namespace ACME.LearningCenterPlatform.API.Profiles.Domain.Model.Entities;

public class Order
{
    public Order(int profileId)
    {
        ProfileId = profileId;
    }

    public int Id { get; set; }
    
    public int ProfileId { get; set; }
    public Profile Profile { get; set; }
}