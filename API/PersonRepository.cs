using API.Context;
using API.Models;
using Microsoft.EntityFrameworkCore;

namespace API.Interface.Respositories
{
    public class PersonRepository : IPersonRepository
    {
        private readonly ApplicationDbContext _context;

        public PersonRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Person>> GetAllPeopleAsync()
        {
            return await _context.People.ToListAsync();
        }

        public async Task<Person> GetPersonByIdAsync(int id)
        {
            return await _context.People.FindAsync(id);
        }

        public async Task AddPersonAsync(Person person)
        {

            _context.People.Add(person);
            await _context.SaveChangesAsync();
        }

        public async Task UpdatePersonAsync(Person person)
        {
            _context.Entry(person).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeletePersonAsync(int id)
        {
            var person = await _context.People.FindAsync(id);
            if (person != null)
            {
                _context.People.Remove(person);
                await _context.SaveChangesAsync();
            }
        }
    }
}
