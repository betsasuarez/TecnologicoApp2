using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using TecnologicoApp.Models;
using TecnologicoApp.Services.Interfaces;
using TecnologicoApp.Views;

namespace TecnologicoApp.ViewModels
{
    public class LoginPageViewModel : INotifyPropertyChanged
    {
        private readonly ISignupSignninService signupSignninService;
        #region "Properties"

        public UsuarioRegistro Usuario { get; set; }

        public Command LoginCommand { get; set; }

        public Command RegisterCommand { get; set; }

        #endregion

        public LoginPageViewModel(ISignupSignninService signupSignninService)
        {
            Usuario = new UsuarioRegistro();
            LoginCommand = new Command(LoginAsync);
            this.signupSignninService = signupSignninService;
            //RegisterCommand= new Command (Go toSSignupSignninServicePageAsync);
        }

        #region "Logic"

        private async void SingUpAsync()
        {

            var result = await singupSigninService.SingUpAsync(Usuario);
            if (!result)
            {
                await Util.ShowToastAsync("NO SE REGISTRO EL USUARIO");
                return;
            }
        }

        private async void LoginAsync()
        {
            if (string.IsNullOrEmpty(Usuario.Email) || !IsAValidEmail(Usuario.Email.ToLower()))
            {
                await Util.ShowToastAsync("Ingrese un Email Válido");
                return;
            }

            if (string.IsNullOrEmpty(Usuario.Password))
            {
                await Util.ShowToastAsync("Ingrese una Contraseña Válida");
                return;
            }

            var loginData = GetLoginData();

            if (loginData != null && !loginData.Any())
            {
                await Util.ShowToastAsync("Configure usuarios");
                return;
            }

            var loginDataEmail = loginData.FirstOrDefault(x => x.Key  == Usuario.Email);

            if (loginDataEmail.Equals(default(KeyValuePair<string, string>)))
            {
                await Util.ShowToastAsync($"El correo {Usuario.Email} no existe");
                return;
            }

            if (loginDataEmail.Value != Usuario.Password)
            {
                await Util.ShowToastAsync($"Contraseña Incorrecta");
                return;
            }

            Settings.IsAuthenticated = true;
            Settings.Email = Usuario.Email;

            await Shell.Current.GoToAsync($"///{nameof(WelcomePage)}");
        }

        private List<KeyValuePair<string, string>> GetLoginData()
        {

            var result = new List<KeyValuePair<string, string>>();
            {
                new KeyValuePair<string, string>("gustavo@itsl.com", "Mama1234");
                new KeyValuePair<string, string>("betsabe@mail.com", "Papa1234");
            }
            return result;
        }

        private bool IsAValidEmail(string email)
        {
            return Regex.IsMatch(email, @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z", RegexOptions.IgnoreCase);
        }

        public void OnPropertyChanged([CallerMemberName] string name = "") =>
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));

        #endregion

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
