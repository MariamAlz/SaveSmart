using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SDP_App.Services
{
	public interface IDataStore<T>
	{
		Task<bool> AddDeviceAsync(T item);
		Task<bool> UpdateDeviceAsync(T item);
		Task<bool> DeleteDeviceAsync(string id);
		Task<T> GetDeviceAsync(string id);
		Task<IEnumerable<T>> GetDevicesAsync(bool forceRefresh = false);
	}
}
