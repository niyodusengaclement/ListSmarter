using ListSmarter.DTO;
using ListSmarter.Repositories.PersonRepository;
using FluentValidation;

namespace ListSmarter.Services.PersonService
{
    public class PersonService : IGenericService<PersonDto>, IPersonService<PersonDto>
    {
        private readonly IPersonRepository<PersonDto> _personRepository;
        private readonly IValidator<PersonDto> _personValidator;
        public PersonService(IPersonRepository<PersonDto> personRepository, IValidator<PersonDto> personValidator)
        {
            _personRepository = personRepository;
            _personValidator = personValidator ?? throw new ArgumentException(); ;

            for (int i = 0; i < 5; i ++)
            {
                PersonDto person = new PersonDto()
                {
                    Id = i,
                    FirstName = $"John{i+1}",
                    LastName = $"Doe{i+1}",
                };
                Add(person);
            }
        }

        public IList<PersonDto> Add(PersonDto user)
        {
            var validationResult = _personValidator.Validate(user);

            if (validationResult.IsValid)
            {
                _personRepository.Add(user);
            }
            return _personRepository.GetAll();
        }
        public IList<PersonDto> GetAll()
        {
            return _personRepository.GetAll();
        }

        public PersonDto GetById(int id)
        {
            return _personRepository.GetById(id);
        }

        public string Update(int id, PersonDto user)
        {
            var validationResult = _personValidator.Validate(user);

            if (validationResult.IsValid)
            {
                _personRepository.Update(id, user);
            }
            return "Bad input. User validation failed";
        }

        public string Delete(int id)
        {
            if(GetById(id)?.Tasks?.Count() > 0)
            {
                return "Failed. User has assigned tasks";
            } else
            {
                _personRepository.Delete(id);
                return "User has been deleted successfully";

            }
        }

        public void AssignUserTask(int userId, int taskId)
        {
            throw new NotImplementedException();
        }
    }
}
