using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Repository Pattern е дизајн патерн кој служи како слој помеѓу апликацијата и
// базата на податоци. 

namespace NotesApp.DataAccess
{
    // Интерфејс е „договор“ за класи.
    // Кажува што треба да прави класата, ама не кажува како.
    // Класата која го имплементира интерфејсот мора да ги направи сите методи од интерфејсот.
    public interface IRepository<T>
    {
        // CRUD
        List<T> GetAll();
        T GetById(int id);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
