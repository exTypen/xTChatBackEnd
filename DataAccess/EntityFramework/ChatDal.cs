using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace DataAccess.EntityFramework;

public class ChatDal : EfEntityRepositoryBase<Chat, Context>, IChatDal
{
    public List<Chat> GetAllByUser(int userId)
    {
        List<Chat> returnList = new();
        using (var context = new Context())
        {
            var result = from userToChatBind in context.UserToChatBinds
                select userToChatBind;
            var listOfBinds = result.ToList();
            foreach (var bind in listOfBinds)
            {
                if (bind.UserId == userId)
                {
                    returnList.Add(new ChatDal().Get(c=>c.Id == bind.ChatId));
                }
            }
        }

        return returnList;
    }

    public List<ChatDto> GetAllDtosByUser(int userId)
    {
        using (var context = new Context())
        {
            var result = from chat in GetAllByUser(userId)
                join chatType in context.ChatTypes on chat.ChatTypeId equals chatType.Id
                select new ChatDto()
                {
                    Id = chat.Id,
                    LastUpdate = chat.LastUpdate,
                    ChatType = chatType,
                    Users = (from bind in context.UserToChatBinds.Where(b => b.ChatId == chat.Id)
                        select bind).ToList(),
                    Messages = (from message in context.Messages.Where(m => m.ChatId == chat.Id)
                        select message).ToList(),
                };
            return result.ToList();
        }
    }

    public List<int> GetUsers(int chatId)
    {
        using (var context = new Context())
        {
            var result = context.UserToChatBinds.Where(b => b.ChatId == chatId).Select(b=>b.UserId).ToList();
            return result.ToList();
        }
    }
}