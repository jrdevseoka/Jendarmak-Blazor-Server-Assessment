using Assembly.Site.Data.Models;
using Assembly.Site.Data.Response;

namespace Assembly.Site.Data.Services.Interfaces
{
    public interface IDeviceService { 
        BaseResponse Create(Device device);
        QueryItemsResponse<Device> GetDevices();
        IReadOnlyList<DeviceType> GetDeviceTypes();
        QueryItemResponse<Device> GetDeviceByName(string name);
        QueryItemResponse<Device> GetDeviceById(int id);
        string SplitNameConcat(string name);
    }
}
