using System.Collections.Generic;
using Core.Utilities.Results;

namespace Core.Entities;

public interface IGenericService<T, idType>
{
    public IResult Add(T entity);
    public IResult Update(T entity);
    public IResult Delete(T entity);
    public IDataResult<List<T>> GetAll();
    public IDataResult<T> GetById(idType id);
}