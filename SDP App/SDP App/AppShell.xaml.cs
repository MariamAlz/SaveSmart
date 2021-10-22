using SDP_App.ViewModels;
using SDP_App.Views;
using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace SDP_App
{
	public partial class AppShell : Xamarin.Forms.Shell
	{
		public AppShell()
		{
			InitializeComponent();
			Routing.RegisterRoute(nameof(DeviceDetailPage), typeof(DeviceDetailPage));
			Routing.RegisterRoute(nameof(NewDevicePage), typeof(NewDevicePage));
		}

	}
}
