namespace ListSmarter.Services.BucketService
{
    public interface IBucketService<T> : IGenericService<T> where T : class
    {
        void GetBucketTasks(int bucketId);

    }
}
