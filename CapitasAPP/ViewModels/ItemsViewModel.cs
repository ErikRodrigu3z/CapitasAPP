using CapitasAPP.Models;
using CapitasAPP.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace CapitasAPP.ViewModels
{
    public class ItemsViewModel : INotifyPropertyChanged
    {        
        public ObservableCollection<Persona> Items { get; set; }
        public Command LoadItemsCommand { get; set; }
        bool isBusy = false;
        public bool IsBusy
        {
            get { return isBusy; }
            set { OnPropertyChanged(nameof(isBusy)); }
        }
        public ItemsViewModel()
        {
            Items = new ObservableCollection<Persona>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());


        }

        public event PropertyChangedEventHandler PropertyChanged;
        async Task ExecuteLoadItemsCommand()
        {
            Repository<Persona> repo = new Repository<Persona>();
            
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                Items.Clear();
                var items = await repo.GetAllAsync();
                foreach (var item in items)
                {
                    Items.Add(item);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }



        
        

        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            var changed = PropertyChanged;
            if (changed == null)
                return;

            changed.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

       
       


        
    }
}
