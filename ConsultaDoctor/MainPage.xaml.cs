using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsultaDoctor.Helpers;
using ConsultaDoctor.Models;
using ConsultaDoctor.ViewModels;
using Xamarin.Forms;

namespace ConsultaDoctor
{
    public partial class MainPage : ContentPage
    {


        DoctoresViewModel dvm = new DoctoresViewModel();
        public MainPage()
        {
            InitializeComponent();
            BindingContext = dvm;
        }

      

        void botonbuscar_Clicked(System.Object sender, System.EventArgs e)
        {

            dvm.GetDoctor(int.Parse(txtid.Text));
        }


    }
}
