using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using CapitasAPP.Models;
using CapitasAPP.Views;
using CapitasAPP.Services;
using System.Windows.Input;
using System.Collections.ObjectModel;

namespace CapitasAPP.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class ItemsPage : ContentPage
    {
        Repository<Persona> repo = new Repository<Persona>();
        public IList<Persona> ListPersonas { get; set; }
        
        public ItemsPage()
        {
           InitializeComponent();
                       

            lvPersonas.RefreshCommand = new Command(async () =>
           {
               lvPersonas.IsRefreshing = true;
               ListPersonas = await repo.GetAllAsync();
               lvPersonas.ItemsSource = ListPersonas;
               lvPersonas.IsRefreshing = false;
           });
        }
        public async Task Refresh()
        {            
            lvPersonas.IsRefreshing = true;
            ListPersonas = await repo.GetAllAsync();
            lvPersonas.ItemsSource = ListPersonas;
            lvPersonas.IsRefreshing = false;           
        }
        async void OnItemSelected(object sender, SelectedItemChangedEventArgs args)        
        {
            var item = args.SelectedItem as Persona;
            if (item == null)
                return;

            await Navigation.PushAsync(new ItemDetailPage(item));
           
        }

        async void AddItem_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new NavigationPage(new NewItemPage()));
        }
        
        protected async override void OnAppearing()
        {
            base.OnAppearing();
            try
            {               
                ListPersonas = await repo.GetAllAsync();
                lvPersonas.ItemsSource = ListPersonas;
            }
            catch (Exception ex)
            {

                await DisplayAlert("Guardar",ex.Message, "OK");
            }
        }

       


      

    }
}