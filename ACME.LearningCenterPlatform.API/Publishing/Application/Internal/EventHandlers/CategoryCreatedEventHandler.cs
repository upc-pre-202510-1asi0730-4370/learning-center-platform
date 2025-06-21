using ACME.LearningCenterPlatform.API.Publishing.Domain.Model.Events;
using ACME.LearningCenterPlatform.API.Shared.Application.Internal.EventHandlers;

namespace ACME.LearningCenterPlatform.API.Publishing.Application.Internal.EventHandlers;

public class CategoryCreatedEventHandler : IEventHandler<CategoryCreatedEvent>
{
    public Task Handle(CategoryCreatedEvent domainEvent, CancellationToken cancellationToken)
    {
        return On(domainEvent);
    }

    private static Task On(CategoryCreatedEvent domainEvent)
    {
        Console.WriteLine("Category Created: {0}", domainEvent.Name);
        return Task.CompletedTask;
    }
}