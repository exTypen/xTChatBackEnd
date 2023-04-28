using Business.Abstract;
using Business.Constants;
using Core.Extensions;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.AspNetCore.Http;
using IResult = Core.Utilities.Results.IResult;

namespace Business.Managers;

public class ChatManager : IChatService
{
    private IChatDal _chatDal;
    private IHttpContextAccessor _httpContextAccessor;

    public ChatManager(IChatDal chatDal, IHttpContextAccessor httpContextAccessor)
    {
        _chatDal = chatDal;
        _httpContextAccessor = httpContextAccessor;
    }

    public IResult Add(Chat entity)
    { 
        _chatDal.Add(entity);
        return new SuccessResult();
    }

    public IResult Update(Chat entity)
    {
        _chatDal.Update(entity);
        return new SuccessResult();
    }

    public IResult Delete(Chat entity)
    {
        _chatDal.Delete(entity);
        return new SuccessResult();
    }

    public IDataResult<List<Chat>> GetAll()
    {
        return new SuccessDataResult<List<Chat>>(_chatDal.GetAll());
    }

    public IDataResult<Chat> GetById(int id)
    {
        return new SuccessDataResult<Chat>(_chatDal.Get(c => c.Id == id));
    }

    public IDataResult<List<Chat>> GetAllByUser(int userId)
    {
        return new SuccessDataResult<List<Chat>>(_chatDal.GetAllByUser(userId));
    }
    
    public IDataResult<List<ChatDto>> GetAllDtos()
    {
        if (_httpContextAccessor.HttpContext.User.ClaimNameIdentifier().Count == 0)
        {
            return new ErrorDataResult<List<ChatDto>>(Messages.NoJwt);
        }
        int userId = Int32.Parse(_httpContextAccessor.HttpContext.User.ClaimNameIdentifier()[0]);
        return new SuccessDataResult<List<ChatDto>>(_chatDal.GetAllDtosByUser(userId).OrderBy(p => p.LastUpdate).Reverse().ToList());
    }

    public List<int> GetUsers(int chatId)
    {
        return _chatDal.GetUsers(chatId);
    }

}