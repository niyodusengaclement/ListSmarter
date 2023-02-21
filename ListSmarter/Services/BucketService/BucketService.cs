using ListSmarter.DTO;
using ListSmarter.Repositories.BucketRepository;
using FluentValidation;
using System.Data;

namespace ListSmarter.Services.BucketService
{
    public class BucketService : IBucketService
    {
        private readonly IBucketRepository _bucketRepository;
        private readonly IValidator<BucketDto> _bucketValidator;
        public BucketService(IBucketRepository bucketRepository, IValidator<BucketDto> bucketValidator)
        {
            _bucketRepository = bucketRepository;
            _bucketValidator = bucketValidator ?? throw new ArgumentException("Error has occured");
        }

        public IList<BucketDto> Add(BucketDto bucket)
        {
            var validationResult = _bucketValidator.Validate(bucket);
            BucketDto? ExistingBucket = _bucketRepository.GetAll().ToList()?.Find((x) => x.Title == bucket.Title);
            if(ExistingBucket != null)
            {
                throw new DuplicateNameException($"Failed. Bucket with title: `{bucket.Title}` already exists");
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
                return "Bucket has been updated successfully";
            } else
            {
                return "Bad input. Bucket validation failed";
            }
        }

        public string Delete(int id)
        {
            if (GetById(id)?.Tasks?.Count > 0)
            {
                return "Failed. Bucket has assigned tasks";
            }
            else
            {
                _bucketRepository.Delete(id);
                return "Bucket has been deleted successfully";

            }
        }
    }
}
