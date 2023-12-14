using API.Models;

namespace API.Interface.Service
{
    public interface IPersonService
    {
        Task<IEnumerable<Person>> GetAllPeople();
        Task<Person> GetPersonById(int id);
        Task AddPerson(Person person);
        Task UpdatePerson(Person person);
        Task DeletePerson(int id);
    }
}

