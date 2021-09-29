using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using ConsultaDoctor.Helpers;
using ConsultaDoctor.Models;
using ConsultaDoctor.ViewModels.Base;

namespace ConsultaDoctor.ViewModels
{
  

    public class DoctoresViewModel: ViewModelBase 
    {
        HelperDoctorAzure helper;
        public DoctoresViewModel()
        {
            helper = new HelperDoctorAzure();
            Task.Run(async () => {
               
                Doctor data = await helper.GetDoctor(DoctId);
                this.Doctores = new Doctor();
                this.Doctores = data;
            });
        }

        private Doctor _Doctores;
        private int _DoctId;


        public Doctor Doctores
        {
            get { return this._Doctores; }
            set
            {
                this._Doctores = value;
                OnPropertyChanged("Doctores");
            }
        }

        public int DoctId
        {
        
            get { return this._DoctId; }
            set
            {
                this._DoctId = value;
                OnPropertyChanged("DoctId");
              
            }    
        }

        public void GetDoctor(int DoctId)
        {
            Task.Run(async () => {
                Doctor data = await helper.GetDoctor(DoctId);
                this.Doctores = new Doctor();
                this.Doctores = data;
            });

        }
    }
}
