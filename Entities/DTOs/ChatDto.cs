using Core.Entities;
using Entities.Binds;
using Entities.Concrete;

namespace Entities.DTOs;

public class ChatDto : IDto
{
    public int Id { get; set; }
    public DateTime LastUpdate { get; set; }
    public ChatType ChatType { get; set; }
    public List<UserToChatBind> Users { get; set; }
    public List<Message> Messages { get; set; }
}