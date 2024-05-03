using BLL.Interfaces;
using DAL.Interfaces;
using Domain.Models;

namespace BLL.Services
{
    public class PersonService : IPersonService
    {
        private readonly IPersonRepository _personRepository;

        public PersonService(IPersonRepository PersonRepository)
        {
            _personRepository = PersonRepository;
        }

        public async Task AddAsync(Person model)
        {
            ValidatePerson(model);

            await _personRepository.AddAsync(model);
            await _personRepository.SaveAsync();
        }

        public async Task DeleteAsync(int id)
        {
            await _personRepository.DeleteAsync(id);
            await _personRepository.SaveAsync();
        }

        public IQueryable<Person> GetAll()
        {
            return _personRepository.GetAll();
        }

        public Task<Person> GetByIdAsync(int id)
        {
            return _personRepository.GetAsync(id);
        }

        public async Task UpdateAsync(Person model)
        {
            ValidatePerson(model);

            _personRepository.Update(model);
            await _personRepository.SaveAsync();
        }

        protected void ValidatePerson(Person person)
        {
            ArgumentNullException.ThrowIfNull(person);

            if (string.IsNullOrWhiteSpace(person.FirstName))
            {
                throw new ArgumentException("Person first name must be valid.", nameof(person));
            }
            else if (string.IsNullOrWhiteSpace(person.LastName))
            {
                throw new ArgumentException("Person last name must be valid.", nameof(person));
            }
        }
    }
}
