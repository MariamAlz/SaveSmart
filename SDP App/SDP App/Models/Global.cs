using System.IO;
using Xamarin.Essentials;

namespace SDP_App.Models
{
	using Database;

	internal static class Global
	{
		public static Database Database { get; private set; }

		public static void Init()
		{
			var root = FileSystem.AppDataDirectory;
			var path = Path.Combine(root, "DB.db3");

			Database = new Database(path);
		}
	}
}
