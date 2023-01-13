using APPHanzaBebe.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APPHanzaBebe.SearchHandlers
{
    public class PacientSearchHandler : SearchHandler
    {
        public IList<PacientModel> Pacients { get; set; }
        public string NavigationRoute { get; set; }
        public Type NavigationType { get; set; }
        protected override void OnQueryChanged(string oldValue, string newValue)
        {
            base.OnQueryChanged(oldValue, newValue);

            if (string.IsNullOrWhiteSpace(newValue))
            {
                ItemsSource = null;
            }
            else
            {
                ItemsSource = Pacients.Where(pacient => pacient.FullName.ToLower().Contains(newValue.ToLower())).ToList();
            }
        }

        protected override async void OnItemSelected(object item)
        {
            base.OnItemSelected(item);
            var navParam = new Dictionary<string, object>();
            navParam.Add("PacientDetail", item);
            if (!string.IsNullOrWhiteSpace(NavigationRoute))
            {
                await Shell.Current.GoToAsync(NavigationRoute, navParam);
            }
        }
    }
}