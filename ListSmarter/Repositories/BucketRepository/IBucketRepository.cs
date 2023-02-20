namespace ListSmarter.Repositories.BucketRepository
{
    public interface IBucketRepository<T> : IRepository<T> where T : class
    {
        void GetBucketTasks(int bucketId);
    }
}
