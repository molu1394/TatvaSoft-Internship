using BooksApi.Entities.Entities;

namespace BooksApi.Entities.Repositories.Interface
{
    public interface IBookRepository
    {
        Task InsertBook(BookDetails bookDetails);
        BookDetails GetById(int id);

        Task DeleteBookAsync(int id);

        Task UpdateBookAsync(BookDetails book);
    }
}
