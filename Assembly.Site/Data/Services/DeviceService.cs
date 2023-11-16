using Assembly.Site.Data.Context;
using Assembly.Site.Data.Models;
using Assembly.Site.Data.Response;
using Assembly.Site.Data.Services.Interfaces;
using Assembly.Site.Pages;
using Microsoft.EntityFrameworkCore;

namespace Assembly.Site.Data.Services
{
    public class DeviceService : IDeviceService
    {
        private readonly ILoggerService Logger;
        private readonly IDbContextFactory<JAADBContext> DataContextFactory;
        public string Message { get; set; }
        private int RowAfftected {get; set; }
        public DeviceService(ILoggerService logger, IDbContextFactory<JAADBContext> dataContext)
        {
            Logger = logger;
            DataContextFactory = dataContext;
        }
        public BaseResponse Create(Device device)
        {
            try
            {
                using(var context = DataContextFactory.CreateDbContext())
                {
                    context.Devices.Add(device);
                    RowAfftected = context.SaveChanges();
                    context.Dispose();
                    Message = $"Device: {device.Name} was added to the inventory";
                    Logger.Info(Message);
                }
                return new BaseResponse { Succeeded = RowAfftected > 0, Message = Message };
            }
            catch (Exception ex)
            {
                Logger.Error($"An error occured while adding device.Error: {ex.Message}.", ex);
                Message =$"An unexpected error occured from our side while adding device. Please try again, if the issue persist contact us on support@jendamark.co.za. Error: {ex.Message}";
                return new BaseResponse { Message = Message, Succeeded = false };
            }
        }

        public QueryItemResponse<Device> GetDeviceById(int id)
        {
            try
            {

                using var context = DataContextFactory.CreateDbContext();
                Device device = context.Devices.FirstOrDefault(x => x.DeviceID == id);
                var response = new QueryItemResponse<Device> { Succeeded = device != null };
                if(device != null)
                {
                    response.Item = device;
                }
                context.Dispose();
                return response;
            }
            catch (Exception exception)
            {
                Message = $"An error occured while retrieving this device with an id: {id}.";
                Logger.Error($"{Message} {exception.Message}", exception);
                return new();
            }
        }

        public QueryItemResponse<Device> GetDeviceByName(string name)
        {
            try
            {
                using var context = DataContextFactory.CreateDbContext();
                Device device = context.Devices?.FirstOrDefault(x => x.Name == name);
                var response = new QueryItemResponse<Device> { Succeeded = device != null };
                if(device != null)
                {
                    response.Item = device;
                }
                context.Dispose();
                return  response;
            }
            catch (Exception ex)
            {
                Message = $"An error occured while retrieving this device: {name}.";
                Logger.Error($"{Message} {ex.Message}", ex);
                return new();
            }
        }

        public QueryItemsResponse<Device> GetDevices()
        {
            try
            {
                using var context = DataContextFactory.CreateDbContext();
                var devices = context.Devices.ToList();
                Message = $"{devices.Count} devices were retrieved";
                context.Dispose();
                return new QueryItemsResponse<Device> { Collections = devices, Message = Message, Succeeded = devices != null };

            }
            catch (Exception ex)
            {
                Message = $"Unexpected error occcured while retrieving devices.";
                string message = $"{Message} Error: {ex.Message}";
                Logger.Error(message, ex);
                return new QueryItemsResponse<Device> { Message = message, Succeeded = false };
            }
        }

        public IReadOnlyList<DeviceType> GetDeviceTypes()
        {
            List<DeviceType> types = new();
            foreach (var type in Enum.GetValues(typeof(EDeviceType)))
            {
                int key = (int)type;
                string name = SplitNameConcat(type.ToString());
                types.Add(new DeviceType { Key = key, Name = name });
            }
            return types.AsReadOnly();
        }

        public string SplitNameConcat(string name)
        {
            if (name == EDeviceType.BarcodeScanner.ToString())
            {
                return "Barcode Scanner";
            }
            if (name == EDeviceType.SocketTray.ToString())
            {
                return "Socket Tray";
            }
            return name;
        }
    }
}
