using System;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using CapitasAPP.Models;
using CapitasAPP.Services;
using System.Globalization;
using System.Collections.Generic;
using System.Reflection;

namespace CapitasAPP.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public  partial class ItemDetailPage : ContentPage
    {
        int personId = 0;
        decimal pagado = 0;
        decimal totalPagar = 180 * 12;

        public  ItemDetailPage(Persona model )
        {
            InitializeComponent();
            personId = model.ID;
            LlenaCapitas(personId);

        }

        private async void Save_Clicked(object sender, EventArgs e)
        {
            try
            {
                Repository<Capitas> repo = new Repository<Capitas>();
                Capitas model = await repo.GetItem(x => x.IdPersona == personId); 

                //textBox
                model.Enero = Convert.ToDecimal(txtEnero.Text == "" ? "0" : txtEnero.Text);
                model.Febrero = Convert.ToDecimal(txtFebrero.Text == "" ? "0" : txtFebrero.Text);
                model.Marzo = Convert.ToDecimal(txtMarzo.Text == "" ? "0" : txtMarzo.Text);
                model.Abril = Convert.ToDecimal(txtAbril.Text == "" ? "0" : txtAbril.Text);
                model.Mayo = Convert.ToDecimal(txtMayo.Text == "" ? "0" : txtMayo.Text);
                model.Junio = Convert.ToDecimal(txtJunio.Text == "" ? "0" : txtJunio.Text);
                model.Julio = Convert.ToDecimal(txtJulio.Text == "" ? "0" : txtJulio.Text);
                model.Agosto = Convert.ToDecimal(txtAgosto.Text == "" ? "0" : txtAgosto.Text);
                model.Septiembre = Convert.ToDecimal(txtSeptiembre.Text == "" ? "0" : txtSeptiembre.Text);
                model.Octubre = Convert.ToDecimal(txtOctubre.Text == "" ? "0" : txtOctubre.Text);
                model.Noviembre = Convert.ToDecimal(txtNoviembre.Text == "" ? "0" : txtNoviembre.Text);
                model.Diciembre = Convert.ToDecimal(txtDiciembre.Text == "" ? "0" : txtDiciembre.Text);

                if (await repo.UpdateItem(model))
                {
                    await DisplayAlert("Guardar Capita", "Guardado Exitoso", "OK");

                    pagado = model.Enero + model.Febrero + model.Marzo + model.Abril + model.Mayo + model.Junio + model.Julio
                           + model.Agosto + model.Septiembre + model.Octubre + model.Noviembre + model.Diciembre;

                    txtTotalPagar.Text = "Total A Pagar: " + totalPagar.ToString("C2", CultureInfo.CreateSpecificCulture("es-MX"));
                    txtPagado.Text = "Pagado: " + pagado.ToString("C2", CultureInfo.CreateSpecificCulture("es-MX"));
                    txtDebe.Text = "Debe: " + (totalPagar - pagado).ToString("C2", CultureInfo.CreateSpecificCulture("es-MX"));
                }
                else
                {
                    await DisplayAlert("Guardar Capita", "No Se Guardo Registro", "OK");
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", ex.Message, "OK");
            }           

        }

        


        public async void LlenaCapitas(int personId)
        {
            try
            {
                Repository<Capitas> repo = new Repository<Capitas>();
                Capitas model = await repo.GetItem(x => x.IdPersona == personId);

                //textBox
                txtEnero.Text = model.Enero.ToString();
                txtFebrero.Text = model.Febrero.ToString();
                txtMarzo.Text = model.Marzo.ToString();
                txtAbril.Text = model.Abril.ToString();
                txtMayo.Text = model.Mayo.ToString();
                txtJunio.Text = model.Junio.ToString();
                txtJulio.Text = model.Junio.ToString();
                txtAgosto.Text = model.Agosto.ToString();
                txtSeptiembre.Text = model.Septiembre.ToString();
                txtOctubre.Text = model.Octubre.ToString();
                txtNoviembre.Text = model.Noviembre.ToString();
                txtDiciembre.Text = model.Diciembre.ToString();

                

                PropertyInfo[] properties = typeof(Capitas).GetProperties();
                foreach (PropertyInfo item in properties) 
                {
                    string type = item.PropertyType.Name;
                    if (type.Equals("Decimal"))
                    {
                        decimal val = Convert.ToDecimal(item.GetValue(model));
                        string propName = item.Name;
                        switch (propName)
                        {
                            case "Enero":
                                if (val == 180)
                                {                                    
                                    txtEnero.TextColor = Color.Green;                                    
                                }
                                else if (val > 0)
                                {
                                    txtEnero.TextColor = Color.Orange;
                                }                                
                                break;
                            case "Febrero":
                                if (val == 180)
                                {
                                    txtFebrero.TextColor = Color.Green;
                                }
                                else if (val > 0)
                                {
                                    txtFebrero.TextColor = Color.Orange;
                                }
                                break;
                            case "Marzo":
                                if (val == 180)
                                {
                                    txtMarzo.TextColor = Color.Green;
                                }
                                else if (val > 0)
                                {
                                    txtMarzo.TextColor = Color.Yellow;
                                }
                                break;
                            case "Abril":
                                if (val == 180)
                                {
                                    txtAbril.TextColor = Color.Green;
                                }
                                else if (val > 0)
                                {
                                    txtAbril.TextColor = Color.Yellow;
                                }
                                break;
                            case "Mayo":
                                if (val == 180)
                                {
                                    txtMayo.TextColor = Color.Green;
                                }
                                else if (val > 0)
                                {
                                    txtMayo.TextColor = Color.Yellow;
                                }
                                break;
                            case "Junio":
                                if (val == 180)
                                {
                                    txtJunio.TextColor = Color.Green;
                                }
                                else if (val > 0)
                                {
                                    txtJunio.TextColor = Color.Yellow;
                                }
                                break;
                            case "Julio":
                                if (val == 180)
                                {
                                    txtJulio.TextColor = Color.Green;
                                }
                                else if (val > 0)
                                {
                                    txtJulio.TextColor = Color.Yellow;
                                }
                                break;
                            case "Agosto":
                                if (val == 180)
                                {
                                    txtAgosto.TextColor = Color.Green;
                                }
                                else if (val > 0)
                                {
                                    txtAgosto.TextColor = Color.Yellow;
                                }
                                break;
                            case "Septiembre":
                                if (val == 180)
                                {
                                    txtSeptiembre.TextColor = Color.Green;
                                }
                                else if (val > 0)
                                {
                                    txtSeptiembre.TextColor = Color.Yellow;
                                }
                                break;
                            case "Octubre":
                                if (val == 180)
                                {
                                    txtOctubre.TextColor = Color.Green;
                                }
                                else if (val > 0)
                                {
                                    txtOctubre.TextColor = Color.Yellow;
                                }
                                break;
                            case "Noviembre":
                                if (val == 180)
                                {
                                    txtNoviembre.TextColor = Color.Green;
                                }
                                else if (val > 0)
                                {
                                    txtNoviembre.TextColor = Color.Yellow;
                                }
                                break;
                            case "Diciembre":
                                if (val == 180)
                                {
                                    txtDiciembre.TextColor = Color.Green;
                                }
                                else if (val > 0)
                                {
                                    txtDiciembre.TextColor = Color.Yellow;
                                }
                                break;
                        }

                        
                    }
                    


                   
                }

                pagado = model.Enero + model.Febrero + model.Marzo + model.Abril + model.Mayo + model.Junio + model.Julio
                          + model.Agosto + model.Septiembre + model.Octubre + model.Noviembre + model.Diciembre;

                txtTotalPagar.Text = "Total A Pagar: " + totalPagar.ToString("C2", CultureInfo.CreateSpecificCulture("es-MX"));
                txtPagado.Text = "Pagado: " + pagado.ToString("C2", CultureInfo.CreateSpecificCulture("es-MX"));
                txtDebe.Text = "Debe: " + (totalPagar - pagado).ToString("C2", CultureInfo.CreateSpecificCulture("es-MX"));
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", ex.Message, "OK");
            }
            

        }

    }
}