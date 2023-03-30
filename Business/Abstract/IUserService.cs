using Core.Entities.Concrete;
using Core.Utilities.Results;

namespace Business.Abstract;

public interface IUserService
{
    void Add(User user);
    User GetByUserName(string userName);
    IResult Update(User user);
    IDataResult<List<OperationClaim>> GetClaims(User user);
}