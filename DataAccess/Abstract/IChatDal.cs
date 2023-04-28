using Core.DataAccess;
using Entities.Concrete;
using Entities.DTOs;

namespace DataAccess.Abstract;

public interface IChatDal : IEntityRepository<Chat>
{
    List<Chat> GetAllByUser(int userId);
    List<ChatDto> GetAllDtosByUser(int userId);
}