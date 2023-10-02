using System.Collections.Generic;
using System.Linq;
using WpfControlLib.Models.Interfaces;


namespace WpfControlLib.Repositories.Interfaces
{
    public interface IRepository<T> where T : IEntity
    {
        void Add(T item);

        IEnumerable<T> GetAll();

        // T Get(int id) => GetAll().FirstOrDefault(item => item.Id == id);
        //T Get(int id)
        //{
        //    var ff =  GetAll().FirstOrDefault(item => item.Id == id);
        //    return ff;
        //}
        

        bool Remove(T item);

        void Update(int id, T item);
    }
}
