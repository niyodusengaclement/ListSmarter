
using AutoMapper;
using ListSmarter.DTO;
using ListSmarter.Models;

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
            CreateMap<Models.Task, TaskDto>();
            CreateMap<TaskDto, Models.Task>();
        }
    }
}
