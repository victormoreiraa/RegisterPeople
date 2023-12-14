using API.Interface.Respositories;
using API.Interface.Service;
using API.Models;

namespace API
{
    public class PersonService : IPersonService
    {
        private readonly IPersonRepository _personRepository;

        public PersonService(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }

        public async Task<IEnumerable<Person>> GetAllPeople()
        {
            return await _personRepository.GetAllPeopleAsync();
        }

        public async Task<Person> GetPersonById(int id)
        {
            return await _personRepository.GetPersonByIdAsync(id);
        }

        public async Task AddPerson(Person person)
        {
            await _personRepository.AddPersonAsync(person);
        }

        public async Task UpdatePerson(Person person)
        {
            await _personRepository.UpdatePersonAsync(person);
        }

        public async Task DeletePerson(int id)
        {
            await _personRepository.DeletePersonAsync(id);
        }
    }
}
