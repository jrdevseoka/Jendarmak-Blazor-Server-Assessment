using Assembly.Site.Data.Models;
using Assembly.Site.Data.Response;

namespace Assembly.Site.Data.Services.Interfaces
{
    public interface IOperationService
    {
        BaseResponse Create(Operation operation);
        BaseResponse Update(Operation operation);
        BaseResponse Delete(Operation operation);
        QueryItemsResponse<Operation> GetOperations();
        QueryItemResponse<Operation> GetOperationById(int id);
    }
}