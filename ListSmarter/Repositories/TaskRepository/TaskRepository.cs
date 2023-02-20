using AutoMapper;
using ListSmarter.DTO;
using ListSmarter.Enums;
using TaskModel = ListSmarter.Models.Task;

namespace ListSmarter.Repositories.TaskRepository
{
    public class TaskRepository : IRepository<TaskDto>, ITaskRepository<TaskDto>
    {
        private readonly IMapper _mapper;
        public TaskRepository(IMapper mapper)
        {
            _mapper = mapper;
        }

        List<TaskModel> _tasks = new();

        public IList<TaskDto> Add(TaskDto user)
        {
            _tasks.Add(_mapper.Map<TaskModel>(user));
            return _mapper.Map<List<TaskDto>>(_tasks);
        }
        public IList<TaskDto> GetAll()
        {
            return _mapper.Map<List<TaskDto>>(_tasks);
        }

        public TaskDto GetById(int id)
        {
            return _mapper.Map<TaskDto>(_tasks.Where(x => x.Id == id).SingleOrDefault());
        }

        public void Update(int id, TaskDto data)
        {
            TaskModel existingTask = _tasks.First(x => x.Id == id);
            existingTask.Title = data?.Title;
            existingTask.Description = data?.Description;
        }

        public void Delete(int id)
        {
            TaskModel existingTask = _tasks.First(x => x.Id == id);
            _tasks.Remove(existingTask);
        }

        public void ChgangeTaskStatus(int taskId, TaskEnum status)
        {
            TaskModel existingTask = _tasks.First(x => x.Id == taskId);
            existingTask.Status = status;
        }
    }

}