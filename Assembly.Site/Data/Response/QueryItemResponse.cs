namespace Assembly.Site.Data.Response
{
    public class QueryItemResponse<T> : BaseResponse where T : class
    {
        public T Item { get; set; } 
    }
}
