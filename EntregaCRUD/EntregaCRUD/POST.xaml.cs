using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using EntregaCRUD.Models;
using System.Net.Http;
using System.Net;

namespace EntregaCRUD
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class POST : ContentPage
	{
		public POST ()
		{
			InitializeComponent ();
		}

		private async void btnInfo_Clicked(object sender, EventArgs e)
		{
            Membership mem = new Membership
            {
                idMembership = txtIdMembership.Text,
                Email = txtEmail.Text,
                PhoneNumber = txtPhoneNumber.Text,
                Old_Pin = txtOldPin.Text,
                New_Pin = txtNewPin.Text
            };
            var request = new HttpRequestMessage();
            Uri RequestUri = new Uri("http://www.###.com");

            var client = new HttpClient();
            var json = JsonConvert.SerializeObject(mem);
            var contentJSON = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await client.PostAsync(RequestUri, contentJSON);
            if (response.StatusCode == HttpStatusCode.OK)
            {
                await DisplayAlert("Info", "Informacion Updated Succesfully", "OK");
                txtIdMembership.Text = "";
                txtEmail.Text = "";
                txtPhoneNumber.Text = "";
                txtOldPin.Text = "";
                txtNewPin.Text = "";
            }

        }
	}
}