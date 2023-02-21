namespace ListSmarter.Common
{
    public class Response<T> where T : class
    {
        public T Data { get; set; }
        public string Error { get; set; }
    }
}
