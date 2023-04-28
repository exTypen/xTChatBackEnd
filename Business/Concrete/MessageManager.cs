using Business.Abstract;
using Business.Constants;
using Core.Extensions;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using IResult = Core.Utilities.Results.IResult;

namespace Business.Managers;

public class MessageManager : IMessageService
{
    private IMessageDal _messageDal;
    private IChatService _chatService;
    private IHttpContextAccessor _httpContextAccessor;

    public MessageManager(IMessageDal messageDal, IChatService chatService, IHttpContextAccessor httpContextAccessor)
    {
        _messageDal = messageDal;
        _chatService = chatService;
        _httpContextAccessor = httpContextAccessor;
    }

    public IResult Add(Message entity)
    {
        if (_httpContextAccessor.HttpContext.User.ClaimNameIdentifier().Count == 0)
        {
            return new ErrorResult(Messages.NoJwt);
        }
        int userId = Int32.Parse(_httpContextAccessor.HttpContext.User.ClaimNameIdentifier()[0]);
        entity.SenderId = userId;
        _messageDal.Add(entity);
        var chat = _chatService.GetById(entity.ChatId).Data;
        chat.LastUpdate = entity.SendTime;
        _chatService.Update(chat);
        return new SuccessResult();
    }

    public IResult Update(Message entity)
    {
        _messageDal.Update(entity);
        return new SuccessResult();
    }

    public IResult Delete(Message entity)
    {
        _messageDal.Delete(entity);
        return new SuccessResult();
    }

    public IDataResult<List<Message>> GetAll()
    {
        return new SuccessDataResult<List<Message>>(_messageDal.GetAll());
    }

    public IDataResult<Message> GetById(int id)
    {
        return new SuccessDataResult<Message>(_messageDal.Get(m => m.Id == id));
    }

    public IDataResult<List<Message>> GetAllByUser(int userId)
    {
        return new SuccessDataResult<List<Message>>(_messageDal.GetAll(m => m.SenderId == userId));
    }

    public IDataResult<List<Message>> GetAllByChat(int chatId)
    {
        return new SuccessDataResult<List<Message>>(_messageDal.GetAll(m => m.SenderId == chatId));
    }
}