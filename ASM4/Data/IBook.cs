using AMS4.Models;

namespace AMS4.Data
{
    public interface IBook
    {
        List<Book> GetAll();
        void Insert(Book p);
        void Update(Book p);
        void Delete(int p);
        Book? FindById(int id);
    }
}
