using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Managers;

public class MessageManager : IMessageService
{
    private IMessageDal _messageDal;

    public MessageManager(IMessageDal messageDal)
    {
        _messageDal = messageDal;
    }

    public IResult Add(Message entity)
    {
        _messageDal.Add(entity);
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
}