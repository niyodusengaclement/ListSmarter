using ListSmarter.DTO;
using ListSmarter.Repositories.BucketRepository;
using FluentValidation;

namespace ListSmarter.Services.BucketService
{
    public class BucketService : IGenericService<BucketDto>, IBucketService<BucketDto>
    {
        private readonly IBucketRepository<BucketDto> _bucketRepository;
        private readonly IValidator<BucketDto> _bucketValidator;
        public BucketService(IBucketRepository<BucketDto> bucketRepository, IValidator<BucketDto> bucketValidator)
        {
            _bucketRepository = bucketRepository;
            _bucketValidator = bucketValidator ?? throw new ArgumentException(); ;

            for (int i = 0; i < 3; i ++)
            {
                BucketDto bucket = new ()
                {
                    Id = i,
                    Title = $"Baquetti{i+1}",
                };
                Add(bucket);
            }
        }

        public IList<BucketDto> Add(BucketDto bucket)
        {
            var validationResult = _bucketValidator.Validate(bucket);
            BucketDto ExistingBucket = _bucketRepository.GetAll().ToList()?.Find((x) => x.Title == bucket.Title);
            if(ExistingBucket != null)
            {
                Console.WriteLine($"Failed. Bucket with title: `{bucket.Title}` already exists");
            }
            if (validationResult.IsValid)
            {
                _bucketRepository.Add(bucket);
            }
            return _bucketRepository.GetAll();

        }
        public IList<BucketDto> GetAll()
        {
            return _bucketRepository.GetAll();
        }

        public BucketDto GetById(int id)
        {
            return _bucketRepository.GetById(id);
        }

        public string Update(int id, BucketDto bucket)
        {
            var validationResult = _bucketValidator.Validate(bucket);

            if (validationResult.IsValid)
            {
                _bucketRepository.Update(id, bucket);
            }
            return "Bad input. Bucket validation failed";
        }

        public string Delete(int id)
        {
            _bucketRepository.Delete(id);
            return "Bucket has been deleted successfully";
        }

        public void GetBucketTasks(int bucketId)
        {
            throw new NotImplementedException();
        }
    }
}
