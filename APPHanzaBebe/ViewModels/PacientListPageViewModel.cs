using APPHanzaBebe;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using APPHanzaBebe.Models;
using APPHanzaBebe.Services;
using APPHanzaBebe.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APPHanzaBebe.ViewModels
{
    public partial class PacientListPageViewModel : ObservableObject
    {
        public static List<PacientModel> PacientsListForSearch { get; private set; } = new List<PacientModel>();
        public ObservableCollection<PacientModel> Pacients { get; set; } = new ObservableCollection<PacientModel>();

        private readonly IPacientService _pacientService;
        public PacientListPageViewModel(IPacientService pacientService)
        {
            _pacientService = pacientService;
        }



        [ICommand]
        public async void GetPacientList()
        {
            Pacients.Clear();
            var pacientList = await _pacientService.GetPacientList();
            if (pacientList?.Count > 0)
            {
                pacientList = pacientList.OrderBy(f => f.FullName).ToList();
                foreach (var pacient in pacientList)
                {
                    Pacients.Add(pacient);
                }
                PacientsListForSearch.Clear();
                PacientsListForSearch.AddRange(pacientList);
            }
        }


        [ICommand]
        public async void AddUpdatePacient()
        {
            await AppShell.Current.GoToAsync(nameof(AddUpdatePacientDetail));
        }


        [ICommand]
        public async void DisplayAction(PacientModel pacientModel)
        {
            var response = await AppShell.Current.DisplayActionSheet("Select Option", "OK", null, "Edit", "Delete");
            if (response == "Edit")
            {
                var navParam = new Dictionary<string, object>();
                navParam.Add("PacientDetail", pacientModel);
                await AppShell.Current.GoToAsync(nameof(AddUpdatePacientDetail), navParam);
            }
            else if (response == "Delete")
            {
                var delResponse = await _pacientService.DeletePacient(pacientModel);
                if (delResponse > 0)
                {
                    GetPacientList();
                }
            }
        }
    }
}