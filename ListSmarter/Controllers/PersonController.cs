using ListSmarter.DTO;
using ListSmarter.Services.PersonService;

namespace ListSmarter.Controllers
{
    public class PersonController
    {
        private readonly IPersonService _personService;
        public PersonController(IPersonService personService) =>  _personService = personService;

        public List<PersonDto> Add(PersonDto user)
        {
            return _personService.Add(user).ToList();
        }
        public List<PersonDto> GetAll()
        {
            return _personService.GetAll().ToList();
        }

        public PersonDto GetById(int id)
        {
            return _personService.GetById(id);
        }

        public string Update(int id, PersonDto user)
        {
            return _personService.Update(id, user);
        }

        public string Delete(int id)
        {
            return _personService.Delete(id);
        }
    }
}
