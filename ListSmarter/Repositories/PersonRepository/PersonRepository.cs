using AutoMapper;
using ListSmarter.Models;
using ListSmarter.DTO;
using ListSmarter.Common;

namespace ListSmarter.Repositories.PersonRepository;

public class PersonRepository : IPersonRepository
{
    private readonly IMapper _mapper;
    public List<Person> _persons = TemporaryDatabase.People;
    public PersonRepository(IMapper mapper)
    {
        _mapper = mapper;
    }

    public IList<PersonDto> Add(PersonDto user)
    {
        _persons.Add(_mapper.Map<Person>(user));
        return _mapper.Map<List<PersonDto>>(_persons);
    }
    public IList<PersonDto> GetAll()
    {
        return _mapper.Map<List<PersonDto>>(_persons);
    }

    public PersonDto GetById(int id)
    {
        return _mapper.Map<PersonDto>(_persons.Where(x => x.Id == id).SingleOrDefault());
    }

    public void Update(int id, PersonDto data)
    {
        Person existingUser = _persons.First(x => x.Id == id);
        existingUser.FirstName = data?.FirstName;
        existingUser.LastName = data?.LastName;
    }

    public void Delete(int id)
    {
        Person existingUser = _persons.First(x => x.Id == id);
        _persons.Remove(existingUser);
    }
}
