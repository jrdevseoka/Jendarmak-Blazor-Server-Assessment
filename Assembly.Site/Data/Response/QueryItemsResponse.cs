namespace Assembly.Site.Data.Response
{
    public class QueryItemsResponse<TEntity> : BaseResponse
        where TEntity : class
    {
        public List<TEntity> Collections { get; set; }
    }
}
