using API.Models;

namespace API.Interface.Respositories
{
    public interface IPersonRepository
    {
        Task<IEnumerable<Person>> GetAllPeopleAsync();
        Task<Person> GetPersonByIdAsync(int id);
        Task AddPersonAsync(Person person);
        Task UpdatePersonAsync(Person person);
        Task DeletePersonAsync(int id);
    }
}
