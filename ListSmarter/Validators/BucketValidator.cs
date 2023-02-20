using FluentValidation;
using ListSmarter.DTO;

namespace ListSmarter.Validators
{
    public class BucketValidator : AbstractValidator<BucketDto>
    {

        public BucketValidator()
        {
            RuleFor(bucket => bucket.Title).NotEmpty();
        }

    }
}
