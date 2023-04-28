using Core.Entities;
using Core.Utilities.Results;
using Entities.Concrete;

namespace Business.Abstract;

public interface IMessageService : IGenericService<Message, int>
{
    public IDataResult<List<Message>> GetAllByUser(int userId);
    public IDataResult<List<Message>> GetAllByChat(int chatId);
}