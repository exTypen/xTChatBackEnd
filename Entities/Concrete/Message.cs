using Core.Entities;

namespace Entities.Concrete;

public class Message : IEntity
{
    public int Id { get; set; }
    public int SenderId { get; set; }
    public int ChatId { get; set; }
    public string Text { get; set; }
    public DateTime SendTime { get; set; }
}