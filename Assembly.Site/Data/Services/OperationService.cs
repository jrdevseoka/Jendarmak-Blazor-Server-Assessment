using Assembly.Site.Data.Context;
using Assembly.Site.Data.Models;
using Assembly.Site.Data.Response;
using Assembly.Site.Data.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Assembly.Site.Data.Services
{
    public class OperationService : IOperationService
    {
        private readonly ILoggerService Logger;
        private readonly JAADBContext DataContext;
        private string Message { get; set; }

        public OperationService(ILoggerService logger, JAADBContext dataContext)
        {
            Logger = logger;
            DataContext = dataContext;
        }

        public BaseResponse Create(Operation operation)
        {
            try
            {
                int rows = DataContext.Database.ExecuteSql($"INSERT INTO dbo.OPERATIONS(NAME, IMAGE, PIORITY, DeviceID)VALUES({operation.Name}, {operation.ImageData}, {operation.OrderInWhichToPerform},{operation.Device.DeviceID})");
                Message = $"Operation - {operation.Name} was added to the assembly inventory";
                return new BaseResponse { Message = Message, Succeeded = rows > 0 };
            }
            catch (Exception ex)
            {
                Message =
                    "An error occured while adding operation. Try again, if the problem persist contact administrator.";
                string message = $"{Message} Error: {ex.Message}";
                Logger.Error(message, ex);
                return new BaseResponse { Succeeded = false, Message = Message };
            }
        }

        public BaseResponse Delete(Operation operation)
        {
            try
            {
                DataContext.Operations.Remove(operation);
                int rowAffected = DataContext.SaveChanges();
                Message =  $"Operation - {operation.Name} was removed from the assembly inventory";
                Logger.Info(Message);
                return new BaseResponse { Succeeded = rowAffected >0, Message = Message };
            }
            catch (Exception ex)
            {
                Message =
                    "An error occured while deleting operation. Try again, if the problem persist contact administrator.";
                string message = $"{Message} Error: {ex.Message}";
                Logger.Error(message, ex);
                return new BaseResponse { Message = Message, Succeeded = false };
            }
        }

        public QueryItemResponse<Operation> GetOperationById(int id)
        {
            try
            {
                Operation operation = DataContext.Operations.AsNoTracking().Include(d => d.Device).FirstOrDefault(x => x.OperationID == id);
                Message =  $"Operation - {operation?.Name} was successfully retrieved.";
                var response = new QueryItemResponse<Operation> { Succeeded = operation != null, Message = Message };
                if(operation != null)
                {
                    response.Item = operation;
                }
                Logger.Info(Message);
                return response;
            }
            catch (Exception ex)
            {
                string Message =
                    $"An error occured while retrieving operation with an id: {id}. Try again, if the problem persist contact administrator.";
                string message = $"{Message} Error: {ex.Message}";
                Logger.Error(message, ex);
                return new();
            }
        }

        public QueryItemsResponse<Operation> GetOperations()
        {
            try
            {
                var operations = DataContext.Operations.Include(o => o.Device).ToList();
                Message =  $"{operations.Count} operations were successfully retrieved.";
                Logger.Info(Message);
                return new QueryItemsResponse<Operation> { Succeeded = operations.Count > 0, Message = Message, Collections = operations };
            }
            catch (Exception ex)
            {
                string Message =
                    $"An error occured while retrieving operations. Try again, if the problem persist contact administrator.";
                string message = $"{Message}  Error:{ex.Message}";
                Logger.Error(message, ex);
                return new QueryItemsResponse<Operation> { Message = Message, Succeeded = false };
            }
        }

        public BaseResponse Update(Operation operation)
        {
            try
            {
                DataContext.Operations.Update(operation);
                int rows = DataContext.SaveChanges();
                Message =  $"Operation - {operation.Name} was successfully updated.";
                Logger.Info(Message);
                return new BaseResponse { Succeeded = rows > 0, Message = Message };
            }
            catch (Exception ex)
            {
                string Message =
                    $"An error occured while updating operation. Try again, if the problem persist contact administrator.";
                string message = $"{Message} Error: {ex.Message}";
                Logger.Error(message, ex);
                return new BaseResponse { Message = Message, Succeeded = false };
            }
        }
    }
}
