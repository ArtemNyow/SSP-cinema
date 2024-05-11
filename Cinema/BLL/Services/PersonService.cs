using BLL.Interfaces;
using DAL.Interfaces;
using Domain.Models;
using System.Diagnostics.Metrics;

namespace BLL.Services
{
    public class PersonService : IPersonService
    {
        private readonly IPersonRepository _personRepository;

        public PersonService(IPersonRepository PersonRepository)
        {
            _personRepository = PersonRepository;
        }

        public async Task<Person> AddAsync(Person model)
        {
            ValidatePerson(model);

            Person entity = await _personRepository.AddAsync(model);
            await _personRepository.SaveAsync();

            return entity;
        }

        public async Task<Person> DeleteAsync(int id)
        {
            Person entity = await _personRepository.DeleteAsync(id);
            await _personRepository.SaveAsync();

            return entity;
        }

        public IQueryable<Person> GetAll()
        {
            return _personRepository.GetAll();
        }

        public async Task<Person> GetByIdAsync(int id)
        {
            return await _personRepository.GetAsync(id);
        }

        public async Task<Person> UpdateAsync(Person model)
        {
            ValidatePerson(model);

            Person entity = _personRepository.Update(model);
            await _personRepository.SaveAsync();

            return entity;
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
