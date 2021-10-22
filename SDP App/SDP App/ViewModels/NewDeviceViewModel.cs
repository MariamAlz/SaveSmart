using SDP_App.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace SDP_App.ViewModels
{
	public class NewDeviceViewModel : BaseViewModel
	{
		private string text;
		private string description;

		public NewDeviceViewModel()
		{
			SaveCommand = new Command(OnSave, ValidateSave);
			CancelCommand = new Command(OnCancel);
			this.PropertyChanged +=
				(_, __) => SaveCommand.ChangeCanExecute();
		}

		private bool ValidateSave()
		{
			return !String.IsNullOrWhiteSpace(text)
				&& !String.IsNullOrWhiteSpace(description);
		}

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

		public Command SaveCommand { get; }
		public Command CancelCommand { get; }

		private async void OnCancel()
		{
			// This will pop the current page off the navigation stack
			await Shell.Current.GoToAsync("..");
		}

		private async void OnSave()
		{
			Dev newDevice = new Dev()
			{
				Id = Guid.NewGuid().ToString(),
				Text = Text,
				Description = Description
			};

			await DataStore.AddDeviceAsync(newDevice);

			// This will pop the current page off the navigation stack
			await Shell.Current.GoToAsync("..");
		}
	}
}
