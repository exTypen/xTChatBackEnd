using Core.Entities;

namespace Entities.Concrete;

public class Chat : IEntity
{
    public int Id { get; set; }
    public int ChatTypeId { get; set; }
}