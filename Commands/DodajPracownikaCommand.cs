using Bank2.Commands;
using Bank2.Model;
using Bank2.Navigators;
using System;
using System.Data.SqlClient;
using System.Windows;
using System.Windows.Input;

namespace Bank2.ViewModel
{
    internal class DodajPracownikaCommand<TViewModel> : ICommand
    where TViewModel : ViewModelBase
    {
        public event EventHandler CanExecuteChanged;

        VMDodajPracownika _vm;
        private INavigator _navigator;
        private Func<TViewModel> _createViewModel;

        //   VMDodajPracownika _navigator;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            if(parameter is VMDodajPracownika)
            {
                dodaj((parameter as VMDodajPracownika));
              
            }
        //    MessageBox.Show(_vm.Imie.ToString() + _vm.Password.ToString());
            //     dodaj(parameter);

        }
        public DodajPracownikaCommand(VMDodajPracownika vm ,INavigator navigator,  Func<TViewModel> createViewModel)
        {
          //  _vm = vm;
            _vm = vm;
            _navigator = navigator;
            _createViewModel = createViewModel;

          //  _vm = _navigator;
        }

        private void dodaj(VMDodajPracownika  nv)
        {


            if (_vm.Imie != null && _vm.Nazwisko != null && _vm.Password != null && _vm.Pesel != null && _vm.Wynagrodzenie != null && _vm.Telefon != null)
            {
                string Imie = "", nazwisko = "", wynagr1 = "", wynagr2 = "", pesel = "", telefon = "", telefon2 = "", haslo = "";

          //  decimal decimalParse1;

                
                    if (!_vm.Wynagrodzenie.GetType().Equals(typeof(decimal)))// || vm.Wynagrodzenie > 30)
                    {

                        wynagr1 = "Błędne dane wynagrodzenia. Musi być liczba. \n";
                        //    textBoxWynagrodzenie.Text = "";
                    }
                    else
                    {
                        if (_vm.Wynagrodzenie < 2500)
                        {
                            wynagr2 = "Błędna kwota wynagrodzenia. Musi być większa od 2500. \n";
                            //     textBoxWynagrodzenie.Text = "";
                        }
                    }

                   // int intParse1;
                    if (!_vm.Telefon.GetType().Equals(typeof(int)))
                    {
                        telefon2 = "Błędny telefon. Musi być liczbą. \n";
                        //   textBoxTelefon.Text = "";
                    }
                    if (_vm.Telefon.ToString().Length != 9)
                    {
                        telefon = "Podaj 9 cyfr telefonu. \n";
                        //   textBoxTelefon.Text = "";
                    }



                    if (sprawdzCzyCyfry(_vm.Imie) == true || _vm.Imie.Length > 30)
                    {
                        Imie = "Popraw imię. \n";

                        //  textBoxImie.Text = "";
                    }
                    if (sprawdzCzyCyfry(_vm.Nazwisko) == true || _vm.Nazwisko.Length > 30)
                    {
                        nazwisko = "Popraw nazwisko. \n";

                        //textBoxNazwisko.Text = "";
                    }
                    if (_vm.Password.Length < 9 || _vm.Password.Length > 30)
                    {
                        haslo = "Podaj dłuższe hasło. \n";
                        //      PasswordBoxHaslo.Password = "";
                    }

                    for (int i = 0; i < _vm.Pesel.Length; i++)
                    {
                        if (!char.IsNumber(_vm.Pesel, i) || _vm.Pesel.Length != 11)
                        {
                            pesel = "Błędny PESEL. \n";
                            //      textBoxPESEL.Text = "";
                        }
                    }
                if (Imie == "" && nazwisko == "" && pesel == "" && haslo == "" && telefon == "" && telefon2 == "" && wynagr1 == "" && wynagr2 == "")
                {
                    Baza db = new Baza();
                    //  db.Database.
                    db.Pracownicy.Add(new Pracownicy()
                    {
                        Data_zatrudnienia = DateTime.Now,
                        Imię_pracownika = _vm.Imie,
                        Nazwisko_pracownika = _vm.Nazwisko,
                        PESEL = _vm.Pesel,
                        Password = _vm.Password,
                        Telefon = _vm.Telefon,
                        Wynagrodzenie = _vm.Wynagrodzenie


                    }
                    );
                    
                    db.SaveChanges();
          
                    MessageBoxResult result = MessageBox.Show("Dodawanie powiodło się.", "", MessageBoxButton.OK);
                    if (result == MessageBoxResult.OK)
                    {
                        _navigator.CurrentViewModel = _createViewModel();
                    }
                }


                else
                {
                    MessageBox.Show("Podałeś błędne dane.  \n" + Imie + nazwisko + pesel + haslo + telefon + telefon2 + wynagr1 + wynagr2 + "");
                }
                
            }
            else
            {
                MessageBox.Show("Uzupełnij wszystko");
            }


            //if (Imie == "" && nazwisko == "" && pesel == "" && haslo == "" && telefon == "" && telefon2 == "" && wynagr1 == "" && wynagr2 == "")
            //{
            //    if (textBoxImie.Text != "" && textBoxNazwisko.Text != "" && textBoxImie.Text != "Musisz uzupełnić" && textBoxNazwisko.Text != "Musisz uzupełnić" && PasswordBoxHaslo.Password != "" && PasswordBoxHaslo.Password != "Musisz uzupełnić" && textBoxTelefon.Text != "" && textBoxTelefon.Text != "Musisz uzupełnić" && textBoxPESEL.Text != "" && textBoxPESEL.Text != "Musisz uzupełnić" && textBoxWynagrodzenie.Text != "" && textBoxWynagrodzenie.Text != "Musisz uzupełnić")
            //    {

            //        DateTime tempData = DateTime.Now;
            //        string data = tempData.ToShortDateString();

            //        LINQBazaBankDataContext dc = new LINQBazaBankDataContext(Bank.Properties.Settings.Default.BankConnectionString);

            //        Pracownicy bob = new Pracownicy();
            //        bob.Imię_pracownika = textBoxImie.Text.TrimEnd();
            //        bob.Nazwisko_pracownika = textBoxNazwisko.Text.TrimEnd();
            //        bob.Password = PasswordBoxHaslo.Password.ToString().TrimEnd();
            //        bob.PESEL = textBoxPESEL.Text;
            //        bob.Data_zatrudnienia = tempData;
            //        bob.Wynagrodzenie = decimalParse1;
            //        bob.Telefon = intParse1;
            //        bob.zaznaczony = false;
            //        bob.aktywny = true;

            //        dc.Pracownicy.InsertOnSubmit(bob);
            //        dc.SubmitChanges();

            //        MessageBox.Show("Dodawanie powiodło się.");

            //        this.Close();

            //    }

            //    else
            //    {
            //        if (textBoxImie.Text == "")
            //        {
            //            textBoxImie.Foreground = Brushes.Red;
            //            textBoxImie.FontWeight = FontWeights.Bold;
            //            textBoxImie.Text = "Musisz uzupełnić";
            //        }
            //        if (textBoxNazwisko.Text == "")
            //        {
            //            textBoxNazwisko.Foreground = Brushes.Red;
            //            textBoxNazwisko.FontWeight = FontWeights.Bold;
            //            textBoxNazwisko.Text = "Musisz uzupełnić";
            //        }
            //        if (PasswordBoxHaslo.Password == "")
            //        {
            //            PasswordBoxHaslo.Foreground = Brushes.Red;
            //            PasswordBoxHaslo.FontWeight = FontWeights.Bold;
            //            PasswordBoxHaslo.Password = "Musisz uzupełnić";
            //        }
            //        if (textBoxTelefon.Text == "")
            //        {
            //            textBoxTelefon.Foreground = Brushes.Red;
            //            textBoxTelefon.FontWeight = FontWeights.Bold;
            //            textBoxTelefon.Text = "Musisz uzupełnić";
            //        }
            //        if (textBoxPESEL.Text == "")
            //        {
            //            textBoxPESEL.Foreground = Brushes.Red;
            //            textBoxPESEL.FontWeight = FontWeights.Bold;
            //            textBoxPESEL.Text = "Musisz uzupełnić";
            //        }
            //        if (textBoxWynagrodzenie.Text == "")
            //        {
            //            textBoxWynagrodzenie.Foreground = Brushes.Red;
            //            textBoxWynagrodzenie.FontWeight = FontWeights.Bold;
            //            textBoxWynagrodzenie.Text = "Musisz uzupełnić";
            //        }

            //    }
            //}
            //else
            //{
            //    MessageBox.Show("Podałeś błędne dane.  \n" + Imie + nazwisko + pesel + haslo + telefon + telefon2 + wynagr1 + wynagr2 + "");

            //}




            bool sprawdzCzyCyfry(string textboxText)
            {
                for (int i = 0; i < textboxText.Length; i++)
                {
                    if (char.IsNumber(textboxText, i))
                    {
                        return true;
                    }
                }
                return false;
            }
        }


    }
}