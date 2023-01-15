using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using APPHanzaBebe.Models;
using APPHanzaBebe.Services;
using APPHanzaBebe.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APPHanzaBebe.ViewModels
{
    [QueryProperty(nameof(PacientDetail), "PacientDetail")]
    public partial class AddUpdatePacientDetailViewModel : ObservableObject
    {
        [ObservableProperty]
        private PacientModel _pacientDetail = new PacientModel();

        private readonly IPacientService _pacientService;
        public AddUpdatePacientDetailViewModel(IPacientService pacientService)
        {
            _pacientService = pacientService;
        }
           

        [ICommand]
        public async void AddUpdatePacient()
        {
            int response = -1;

            if (PacientDetail.PacientID > 0)
            {
                response = await _pacientService.UpdatePacient(PacientDetail);
            }
            else
            {
                response = await _pacientService.AddPacient(new Models.PacientModel
                {
                    Email = PacientDetail.Email,
                    FirstName = PacientDetail.FirstName,
                    LastName = PacientDetail.LastName,
                });
            }



            if (response > 0)
            {
                await Shell.Current.DisplayAlert("Informatii despre Pacient adaugate!", "Inregistrare salvata", "OK");
            }
            else
            {
                await Shell.Current.DisplayAlert("Eroare", "Inregistrarea nu a putut fif adaugata", "OK");
            }
        }

    }
}