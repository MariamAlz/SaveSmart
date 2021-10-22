using SDP_App.Models;
using SDP_App.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SDP_App.Views
{
	public partial class NewDevicePage : ContentPage
	{
		public Dev Device { get; set; }

		public NewDevicePage()
		{
			InitializeComponent();
			BindingContext = new NewDeviceViewModel();
		}
	}
}