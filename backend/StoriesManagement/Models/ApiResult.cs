namespace StoriesManagement.Models
{
    public class ApiResult<T>
    {
        public int StatusCode { get; set; }
        public string Error { get; set; }
        public T Response { get; set; }
    }
}
