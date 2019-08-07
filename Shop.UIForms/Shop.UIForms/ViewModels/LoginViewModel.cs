using GalaSoft.MvvmLight.Command;
using Shop.UIForms.Views;
using System;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Shop.UIForms.ViewModels
{
    public class LoginViewModel
    {
        public string Email { get; set; }

        public string Password { get; set; }

        public LoginViewModel()
        {
            this.Email = "marco.vinicio.ortiz@gmail.com";
            this.Password = "123458";
        }

        public ICommand LoginCommand => new RelayCommand(Login);

        private async void Login()
        {
            if(string.IsNullOrEmpty(this.Email))
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    "Please enter a valid email address",
                    "Ok"
                    );
                return;
            }

            if (string.IsNullOrEmpty(this.Password))
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    "Password cannot be empty",
                    "Ok"
                    );
                return;
            }

            if(!this.Email.Equals("marco.vinicio.ortiz@gmail.com") || !this.Password.Equals("123458"))
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    "Invalid Email/Password Combination",
                    "Ok"
                    );
                return;
            }

            MainViewModel.GetInstance().Products = new ProductsViewModel();
            await Application.Current.MainPage.Navigation.PushAsync(new ProductsPage());
            return;
        }
    }
}
