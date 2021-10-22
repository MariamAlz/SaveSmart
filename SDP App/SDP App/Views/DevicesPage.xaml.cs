using SDP_App.Models;
using SDP_App.ViewModels;
using SDP_App.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SDP_App.Views
{
	public partial class DevicesPage : ContentPage
	{
		DevicesViewModel _viewModel;

		public DevicesPage()
		{
			InitializeComponent();

			BindingContext = _viewModel = new DevicesViewModel();
		}

		protected override void OnAppearing()
		{
			base.OnAppearing();
			_viewModel.OnAppearing();
		}
	}
}