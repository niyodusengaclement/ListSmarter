using AutoMapper;
using ListSmarter.Models;
using ListSmarter.DTO;
using ListSmarter.Common;

namespace ListSmarter.Repositories.BucketRepository
{
    public class BucketRepository : IBucketRepository
    {
        private readonly IMapper _mapper;
        public List<Bucket> _buckets = TemporaryDatabase.Buckets;
        public BucketRepository(IMapper mapper)
        {
            _mapper = mapper;
        }

        public IList<BucketDto> Add(BucketDto bucket)
        {
            _buckets.Add(_mapper.Map<Bucket>(bucket));
            return _mapper.Map<List<BucketDto>>(_buckets);
        }
        public IList<BucketDto> GetAll()
        {
            return _mapper.Map<List<BucketDto>>(_buckets);
        }

        public BucketDto GetById(int id)
        {
            return _mapper.Map<BucketDto>(_buckets.Where(x => x.Id == id).SingleOrDefault());
        }

        public void Update(int id, BucketDto data)
        {
            Bucket existingBucket = _buckets.First(x => x.Id == id);
            existingBucket.Title = data?.Title;
        }

        public void Delete(int id)
        {
            Bucket existingBucket = _buckets.First(x => x.Id == id);
            _buckets.Remove(existingBucket);
        }
    }
}
