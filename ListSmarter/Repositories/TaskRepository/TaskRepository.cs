using AutoMapper;
using ListSmarter.Common;
using ListSmarter.DTO;
using ListSmarter.Enums;
using ListSmarter.Models;
using TaskModel = ListSmarter.Models.Task;

namespace ListSmarter.Repositories.TaskRepository
{
    public class TaskRepository : ITaskRepository
    {
        private readonly IMapper _mapper;
        public List<TaskModel> _tasks = TemporaryDatabase.Tasks;
        public List<Person> _persons = TemporaryDatabase.People;
        public List<Bucket> _buckets = TemporaryDatabase.Buckets;
        public TaskRepository(IMapper mapper)
        {
            _mapper = mapper;
        }


        public IList<TaskDto> Add(TaskDto user)
        {
            TemporaryDatabase.Tasks.Add(_mapper.Map<TaskModel>(user));
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

        public void ChangeTaskStatus(int taskId, TaskStatusEnum status)
        {
            TaskModel existingTask = _tasks.First(x => x.Id == taskId);
            existingTask.Status = status;
        }

        public void AssignTaskToUser(int taskId, int userId)
        {
            TaskModel existingTask = _tasks.First(x => x.Id == taskId);
            var person = _persons.Find((x) => x.Id == userId);
            if (existingTask != null && person != null)
            {
                existingTask.Assignee = person;
                existingTask.AssigneeId = userId;
                person?.Tasks?.Add(existingTask);
            }
        }

        public void AssignTaskToBucket(int taskId, int bucketId)
        {
            TaskModel existingTask = _tasks.First(x => x.Id == taskId);
            Bucket existingBucket = _buckets.First(x => x.Id == bucketId);
            existingBucket?.Tasks?.Add(existingTask);
            existingTask.BucketId = bucketId;
            existingTask.Bucket = existingBucket;
        }
        public List<TaskDto> GetTasksByBucketId(int bucketId)
        {
            return _mapper.Map<List<TaskDto>>(_tasks.FindAll(x => x.BucketId == bucketId));
        }
    }

}