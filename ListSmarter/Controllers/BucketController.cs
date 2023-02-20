using ListSmarter.DTO;
using ListSmarter.Services.BucketService;

namespace ListSmarter.Controllers
{
    public class BucketController
    {
        private readonly IBucketService<BucketDto> _bucketService;
        public BucketController(IBucketService<BucketDto> bucketService) =>  _bucketService = bucketService;

        public List<BucketDto> Add(BucketDto user)
        {
            return _bucketService.Add(user).ToList();
        }
        public List<BucketDto> GetAll()
        {
            return _bucketService.GetAll().ToList();
        }

        public BucketDto GetById(int id)
        {
            return _bucketService.GetById(id);
        }

        public string Update(int id, BucketDto user)
        {
            return _bucketService.Update(id, user);
        }

        public string Delete(int id)
        {
            return _bucketService.Delete(id);
        }

        public void GetBucketTasks(int bucketId)
        {
            //throw new NotImplementedException();
        }
    }
}
