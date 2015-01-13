using System.Collections.Generic;

namespace ModuleManager.Web.Controllers.Api.Interfaces
{
    public interface IGenericApiController<T> where T : class
    {
        IEnumerable<T> GetAll();
        T GetOne(string schooljaar, string key);
        bool Delete(T entity);
        bool Edit(T entity);
        bool Create(T entity); 
    }
}