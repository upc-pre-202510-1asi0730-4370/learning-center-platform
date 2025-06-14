namespace ACME.LearningCenterPlatform.API.Publishing.Domain.Model.Entities;

public class Category
{
    public int Id { get; set; }
    public string Name { get; set; }

    public Category()
    {
        Name = string.Empty;
    }
}