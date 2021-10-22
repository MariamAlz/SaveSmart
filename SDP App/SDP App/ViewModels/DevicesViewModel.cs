using SDP_App.Models;
using SDP_App.Views;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;
using TPLinkSmartDevices;

namespace SDP_App.ViewModels
{
	public class DevicesViewModel : BaseViewModel
	{
		private Dev _selectedDevice;
		public ObservableCollection<Dev> Devices { get; }
		public Command LoadDevicesCommand { get; }
		public Command AddDeviceCommand { get; }
		//public Command DiscoverDeviceCommand { get; }
		public Command<Dev> DeviceTapped { get; }

		public DevicesViewModel()
		{
			Title = "Devices";
			Devices = new ObservableCollection<Dev>();
			LoadDevicesCommand = new Command(async () => await ExecuteLoadDevicesCommand());

			DeviceTapped = new Command<Dev>(OnDeviceSelected);

			AddDeviceCommand = new Command(OnAddDevice);
		}

		async Task ExecuteLoadDevicesCommand()
		{
			IsBusy = true;

			try
			{
				Devices.Clear();
				var devices = await DataStore.GetDevicesAsync(true);

				foreach (var device in devices)
				{
					Devices.Add(device);
				}
			}
			catch (Exception ex)
			{
				Debug.WriteLine(ex);
			}
			finally
			{
				IsBusy = false;
			}
		}

		public void OnAppearing()
		{
			IsBusy = true;
			SelectedDevice = null;
		}

		public Dev SelectedDevice
		{
			get => _selectedDevice;
			set
			{
				SetProperty(ref _selectedDevice, value);
				OnDeviceSelected(value);
			}
		}

		private async void OnAddDevice(object obj)
		{
			//var list = await DataStore.DiscoverDeviceAsync();
			await Shell.Current.GoToAsync(nameof(NewDevicePage));
		}

		async void OnDeviceSelected(Dev device)
		{
			if (device == null)
				return;

			// This will push the DeviceDetailPage onto the navigation stack
			await Shell.Current.GoToAsync($"{nameof(DeviceDetailPage)}?{nameof(DeviceDetailViewModel.DeviceId)}={device.Id}");
		}
	}
}