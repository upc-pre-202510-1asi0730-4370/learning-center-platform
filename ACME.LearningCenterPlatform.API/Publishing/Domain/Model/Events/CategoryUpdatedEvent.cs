using ACME.LearningCenterPlatform.API.Shared.Domain.Model.Events;

namespace ACME.LearningCenterPlatform.API.Publishing.Domain.Model.Events;

public class CategoryUpdatedEvent(string name) : IEvent
{
    public string Name { get; } = name;
}