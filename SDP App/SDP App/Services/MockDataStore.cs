using SDP_App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TPLinkSmartDevices;
using TPLinkSmartDevices.Devices;

namespace SDP_App.Services
{
	public class MockDataStore : IDataStore<Dev>
	{
		readonly List<Dev> devices;

		public MockDataStore()
		{
			devices = new List<Dev>()
			{
				new Dev { Id = Guid.NewGuid().ToString(), Text = "Smart Plug 1", Description="This is a smart plug description." },
				new Dev { Id = Guid.NewGuid().ToString(), Text = "Smart Plug 2", Description="This is a smart plug description." },
				new Dev { Id = Guid.NewGuid().ToString(), Text = "Smart Plug 3", Description="This is a smart plug description." },
				new Dev { Id = Guid.NewGuid().ToString(), Text = "Smart Plug 4", Description="This is a smart plug description." },
				new Dev { Id = Guid.NewGuid().ToString(), Text = "Smart Plug 5", Description="This is a smart plug description." },
				new Dev { Id = Guid.NewGuid().ToString(), Text = "Smart Plug 6", Description="This is a smart plug description." }
			};
		}

		/*public async Task<List<TPLinkSmartDevice>> DiscoverDeviceAsync()
		{
			var discoveredDevices = await new TPLinkDiscovery().Discover();

			foreach (var device in discoveredDevices)
			{
				if (device is TPLinkSmartPlug plug)
				{
					await plug.SetPoweredOn(true);
				}
			}
			return discoveredDevices;
		}*/

		public async Task<bool> AddDeviceAsync(Dev device)
		{
			devices.Add(device);

			return await Task.FromResult(true);
		}

		public async Task<bool> UpdateDeviceAsync(Dev device)
		{
			var oldDevice = devices.Where((Dev arg) => arg.Id == device.Id).FirstOrDefault();
			devices.Remove(oldDevice);
			devices.Add(device);

			return await Task.FromResult(true);
		}

		public async Task<bool> DeleteDeviceAsync(string id)
		{
			var oldDevice = devices.Where((Dev arg) => arg.Id == id).FirstOrDefault();
			devices.Remove(oldDevice);

			return await Task.FromResult(true);
		}

		public async Task<Dev> GetDeviceAsync(string id)
		{
			return await Task.FromResult(devices.FirstOrDefault(s => s.Id == id));
		}

		public async Task<IEnumerable<Dev>> GetDevicesAsync(bool forceRefresh = false)
		{
			return await Task.FromResult(devices);
		}
	}
}