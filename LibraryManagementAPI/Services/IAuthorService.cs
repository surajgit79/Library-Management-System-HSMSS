using LibraryManagementAPI.Models;

namespace LibraryManagementAPI.Services
{
    public interface IAuthorService
    {
        List<Author> GetAuthors();
        Author? GetAuthorById(int id);
        void AddAuthor(Author author);
        void UpdateAuthor(Author author);
        void DeleteAuthor(int id);
    }
}