using Jijon_EjemploApi.Model;
using Newtonsoft.Json;
using System.Text.Json.Serialization;
using static System.Net.WebRequestMethods;

namespace Jijon_EjemploApi.Views;

public partial class ClimaActual : ContentPage
{
	public ClimaActual()
	{
		InitializeComponent();
	}

    private async void Button_Clicked(object sender, EventArgs e)
    {
		String Latitud = LatMJ.Text;
		String Longuitud = LonMJ.Text;

		if (Connectivity.NetworkAccess == NetworkAccess.Internet)
		{
			using (var client = new HttpClient())
			{
				String url = $"https://api.openweathermap.org/data/2.5/weather?lat=" + Latitud + "&lon=" + Longuitud + "&appid=a4f1449392d96baafaced8b3efd1d9e8";

				var response = await client.GetAsync(url);
				if (response.IsSuccessStatusCode)
				{
					var json = await response.Content.ReadAsStringAsync();
					var clima = JsonConvert.DeserializeObject<Rootobject>(json);
					

                    MJWeatherLabel.Text = clima.weather[0].main;
					MJCityLabel.Text = clima.name;
					MJCountryLabel.Text = clima.sys.country;
				

                }

			}
		}
    }
}