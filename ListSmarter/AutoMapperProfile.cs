
using AutoMapper;
using ListSmarter.DTO;
using ListSmarter.Models;
using TaskModel = ListSmarter.Models.Task;

namespace ListSmarter
{
    public class AutoMapperProfile : Profile
    {

        public AutoMapperProfile()
        {
            CreateMap<Person, PersonDto>();
            CreateMap<PersonDto, Person>();
            CreateMap<BucketDto, Bucket>();
            CreateMap<Bucket, BucketDto>();
            CreateMap<TaskModel, TaskDto>();
            CreateMap<TaskDto, TaskModel>();
        }
    }
}
