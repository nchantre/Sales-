using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Sales
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            Inicializar();
        }

        private void Inicializar()
        {
            buttonTexto.Clicked += ButtonTexto_Clicked;
            btnSiguiente.Clicked += BtnSiguiente_Clicked;
            //throw new NotImplementedException();
        }

        private void BtnSiguiente_Clicked(object sender, EventArgs e)
        {
          //  Navigation.PushAsync(new OtraPagina());
        }

        private void ButtonTexto_Clicked(object sender, EventArgs e)
        {
            labelTexto.Text = entryTexto.Text;
         
        }
    }
}
