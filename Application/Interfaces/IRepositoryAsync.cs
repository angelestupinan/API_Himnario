using Ardalis.Specification;
using Domain.Entities;
using System.Linq.Expressions;

namespace Application.Interfaces
{
    //tiene definidos los comandos basicos CRUD
    public interface IRepositoryAsync<T> : IRepositoryBase<T> where T : class
    {
        //esta implementacion sirve para acceder a una propiedad especifica  
        Task<T> GetOneAsync(Expression<Func<T, bool>> filter = null, bool tracked = true);
    }

    //tiene las implementaciones para leer 
    public interface IReadRepositoryAsync<T> : IReadRepositoryBase<T> where T : class
    {
    }
}
