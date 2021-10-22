using SDP_App.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace SDP_App.Views
{
	public partial class DeviceDetailPage : ContentPage
	{
		public DeviceDetailPage()
		{
			InitializeComponent();
			BindingContext = new DeviceDetailViewModel();
		}
	}
}