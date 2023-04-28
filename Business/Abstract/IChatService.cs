using System.Security.Claims;
using Core.Entities;
using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Abstract;

public interface IChatService : IGenericService<Chat, int>
{
    public IDataResult<List<Chat>> GetAllByUser(int userId);
    public IDataResult<List<ChatDto>> GetAllDtos();
 
}