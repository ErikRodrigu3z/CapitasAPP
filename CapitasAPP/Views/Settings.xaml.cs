using CapitasAPP.Models;
using CapitasAPP.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CapitasAPP.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Settings : ContentPage
    {
        public Settings()
        {
            InitializeComponent();
        }

        private async void btnGuardarBD_Clicked(object sender, EventArgs e)
        {
            try
            {
                

                File.Copy(Constants.DatabasePath, Constants.DatabaseBackUpPath, true);
                await DisplayAlert("Back Up DB", "Guardado en: " + Constants.DatabaseBackUpPath, "OK");
            }
            catch (Exception ex)
            {

                await DisplayAlert("Back Up DB", "Error: " + ex.Message, "OK");
            }
        }

        private async void btnBorrarBD_Clicked(object sender, EventArgs e)
        {
            try
            {
                Repository<Persona> repo = new Repository<Persona>(true);
                await DisplayAlert("Borrar DB", "Base De Datos Borrada", "OK");
                System.Environment.Exit(0);

            }
            catch (Exception ex)
            {

                await DisplayAlert("Borrar DB", "Error: " + ex.Message, "OK");
            }
            
        }
    }
}