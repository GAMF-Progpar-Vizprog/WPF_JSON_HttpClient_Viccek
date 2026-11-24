using System.Net.Http;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Net.Http.Headers;

namespace WPF_JSON_Viccek
{

	public partial class MainWindow : Window
	{
		string result;

		public MainWindow()
		{
			InitializeComponent();
			result = "";
			for (int i = 0; i < 10; i++)
				GetJoke();
		}

		private async void GetJoke()
		{
			try
			{
				var client = new HttpClient();
				var request = new HttpRequestMessage
				{
					Method = HttpMethod.Get,
					RequestUri = new Uri("https://official-joke-api.appspot.com/random_joke"),

				};
				using (var response = await client.SendAsync(request))
				{
					response.EnsureSuccessStatusCode();
					result += await response.Content.ReadAsStringAsync()+
						",\n";
					tbJokes.Text = result;
				}
			}
			catch (Exception ex)
			{
				// Handle exceptions (e.g., network issues)
				MessageBox.Show($"An error occurred: {ex.Message}");
			}
		}
	}
}
