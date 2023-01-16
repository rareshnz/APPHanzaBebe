using APPHanzaBebe.Services;
using APPHanzaBebe.ViewModels;
using APPHanzaBebe.Views;
using Newtonsoft.Json;


namespace APPHanzaBebe
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Dashboard : ContentPage
    {
        private IPacientService pacientService;
        public Dashboard()
        {
             
            InitializeComponent();
           
            pacientService = new PacientService();
            MyButton.Clicked += MyButton_Clicked;
             async void MyButton_Clicked(object sender, EventArgs e)
            {
                await Navigation.PushAsync(new PacientListPage(new PacientListPageViewModel(pacientService)));
            }



        }
    }
}