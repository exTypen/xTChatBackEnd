using Business.Abstract;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using DataAccess;
using DataAccess.Abstract;
using DataAccess.EntityFramework;

namespace Business.Managers;

public class UserManager : IUserService
{
    private IUserDal _userDal;

    public UserManager(IUserDal userDal)
    {
        _userDal = userDal;
    }

    public void Add(User user)
    {
        _userDal.Add(user);
    }

    public User GetByUserName(string userName)
    {
        return _userDal.Get(u => u.UserName == userName);
    }

    public IResult Update(User user)
    {
        _userDal.Update(user);
        return new SuccessResult();
    }

    public IDataResult<List<OperationClaim>> GetClaims(User user)
    {
        return new SuccessDataResult<List<OperationClaim>>(_userDal.GetClaims(user));
    }
}