using System;
using System.Collections.Generic;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using CapitasAPP.Models;
using CapitasAPP.Services;
using SQLite;

namespace CapitasAPP.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class NewItemPage : ContentPage
    {
        public NewItemPage()
        {
            InitializeComponent();
            
        }

        async void Save_Clicked(object sender, EventArgs e)
        {
            Repository<Persona> repo = new Repository<Persona>();
            Repository<Capitas> repo2 = new Repository<Capitas>();

            Persona per = new Persona();
            Capitas cap = new Capitas();
           
            using (var conn = new SQLiteConnection(Constants.DatabasePath, Constants.Flags))
            {
                conn.BusyTimeout = new TimeSpan(30000000); //espera 1 segundo en caso de que la BBDD esté ocupada por otro hilo
                conn.BeginTransaction();
                try
                {
                    per.Nombre = txtNombre.Text;
                    per.Apellido = txtApellido.Text;
                    per.Telfono = txtTelefono.Text;
                    per.Email = txtEmail.Text;

                    if (string.IsNullOrEmpty(per.Nombre) || string.IsNullOrEmpty(per.Apellido) || string.IsNullOrEmpty(per.Telfono) || string.IsNullOrEmpty(per.Email))
                    {
                        await DisplayAlert("Guardar", "Debe Llenar Todos Los Campos", "OK");
                    }
                    else
                    {
                        if (await repo.AddItem(per))
                        {

                            cap.IdPersona = per.ID;
                            cap.Enero = 0.00M;
                            cap.Febrero = 0.00M;
                            cap.Marzo = 0.00M;
                            cap.Abril = 0.00M;
                            cap.Mayo = 0.00M;
                            cap.Junio = 0.00M;
                            cap.Julio = 0.00M;
                            cap.Agosto = 0.00M;
                            cap.Septiembre = 0.00M;
                            cap.Octubre = 0.00M;
                            cap.Noviembre = 0.00M;
                            cap.Diciembre = 0.00M;


                            if (await repo2.AddItem(cap))
                            {
                                await DisplayAlert("Guardar", "Se Guardo Registro", "OK");
                                conn.Commit();
                            }
                            else
                            {
                                conn.Rollback();
                                await DisplayAlert("Guardar", "No Se Guardo Registro", "OK");
                            }
                        }
                        else
                        {
                            conn.Rollback();
                            await DisplayAlert("Guardar", "No Se Guardo Registro", "OK");
                        }
                    }

                    

                }
                catch (SQLiteException ex)
                {
                    SQLite3.Result result = ex.Result;
                    if (result == SQLite.SQLite3.Result.Busy || result == SQLite.SQLite3.Result.Locked)
                    {
                        
                    }
                    conn.Rollback();                       
                }
                catch (Exception ex)
                {
                    conn.Rollback();
                    await DisplayAlert("Error", ex.Message, "OK");
                }                                     
            }

            

            await Navigation.PopModalAsync();
        }

        async void Cancel_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }
    }
}