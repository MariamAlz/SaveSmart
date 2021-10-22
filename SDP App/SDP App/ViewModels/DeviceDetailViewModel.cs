using SDP_App.Models;
using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace SDP_App.ViewModels
{
	[QueryProperty(nameof(DeviceId), nameof(DeviceId))]
	public class DeviceDetailViewModel : BaseViewModel
	{
		private string deviceId;
		private string text;
		private string description;
		public string Id { get; set; }

		public string Text
		{
			get => text;
			set => SetProperty(ref text, value);
		}

		public string Description
		{
			get => description;
			set => SetProperty(ref description, value);
		}

		public string DeviceId
		{
			get
			{
				return deviceId;
			}
			set
			{
				deviceId = value;
				LoadDeviceId(value);
			}
		}

		public async void LoadDeviceId(string deviceId)
		{
			try
			{
				var device = await DataStore.GetDeviceAsync(deviceId);
				Id = device.Id;
				Text = device.Text;
				Description = device.Description;
			}
			catch (Exception)
			{
				Debug.WriteLine("Failed to Load Device");
			}
		}
	}
}
