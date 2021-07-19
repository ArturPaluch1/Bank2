using Bank2.Model;
using System;
using System.Data.SqlClient;
using System.Windows;
using System.Windows.Input;

namespace Bank2.ViewModel
{
    internal class DodajCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        VMDodajPracownika _vm;
        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
        //    dodaj(parameter as VMDodajPracownika);
            MessageBox.Show(_vm.Imie .ToString() + _vm.Password.ToString());
        }
        public DodajCommand(VMDodajPracownika vm)
        {
            _vm = vm;
        }

        //private void dodaj(VMDodajPracownika vm)
        //{

        //    string Imie = "", nazwisko = "", wynagr1 = "", wynagr2 = "", pesel = "", telefon = "", telefon2 = "", haslo = "";

        //    decimal decimalParse1;
            
        //    if (!vm.Wynagrodzenie.GetType().Equals(typeof(decimal)))// || vm.Wynagrodzenie > 30)
        //    {

        //        wynagr1 = "Błędne dane wynagrodzenia. Musi być liczba. \n";
        //    //    textBoxWynagrodzenie.Text = "";
        //    }
        //    else
        //    {
        //        if (vm.Wynagrodzenie < 1800 )
        //        {
        //            wynagr2 = "Błędna kwota wynagrodzenia. Musi być większa od 1800. \n";
        //       //     textBoxWynagrodzenie.Text = "";
        //        }
        //    }

        //    int intParse1;
        //    if (!vm.Wynagrodzenie.GetType().Equals(typeof(int)))
        //    {
        //        telefon2 = "Błędny telefon. Musi być liczbą. \n";
        //     //   textBoxTelefon.Text = "";
        //    }
        //    //if (textBoxTelefon.Text.Length != 9)
        //    //{
        //    //    telefon = "Podaj 9 cyfr telefonu. \n";
        //    //    textBoxTelefon.Text = "";
        //    //}



        //    //if (sprawdzCzyCyfry(textBoxImie.Text) == true || textBoxImie.Text.Length > 30)
        //    //{
        //    //    Imie = "Popraw imię. \n";

        //    //    textBoxImie.Text = "";
        //    //}
        //    //if (sprawdzCzyCyfry(textBoxNazwisko.Text) == true || textBoxNazwisko.Text.Length > 30)
        //    //{
        //    //    nazwisko = "Popraw nazwisko. \n";

        //    //    textBoxNazwisko.Text = "";
        //    //}
        //    if (vm.Password.Length < 9 || vm.Password.Length > 30)
        //    {
        //        haslo = "Podaj dłuższe hasło. \n";
        //  //      PasswordBoxHaslo.Password = "";
        //    }

        //    for (int i = 0; i < vm.Pesel.Length; i++)
        //    {
        //        if (!char.IsNumber(vm.Pesel, i) || vm.Pesel.Length != 11)
        //        {
        //            pesel = "Błędny PESEL. \n";
        //      //      textBoxPESEL.Text = "";
        //        }
        //    }
        //    //  SqlConnection db = new SqlConnection(Bank2.pop

        //    Baza db = new Baza();
        //    //  db.Database.
        //    db.Pracownicy.Add(new Pracownicy()
        //    {
        //        Imię_pracownika = vm.Imie,
        //        Nazwisko_pracownika = vm.Nazwisko,
        //        PESEL = vm.Pesel,
        //        Password = vm.Password,
        //        Telefon = vm.Telefon,
        //        Wynagrodzenie = vm.Wynagrodzenie
        //    }
        //    );


        ///*    if (Imie == "" && nazwisko == "" && pesel == "" && haslo == "" && telefon == "" && telefon2 == "" && wynagr1 == "" && wynagr2 == "")
        //    {
        //        if (textBoxImie.Text != "" && textBoxNazwisko.Text != "" && textBoxImie.Text != "Musisz uzupełnić" && textBoxNazwisko.Text != "Musisz uzupełnić" && PasswordBoxHaslo.Password != "" && PasswordBoxHaslo.Password != "Musisz uzupełnić" && textBoxTelefon.Text != "" && textBoxTelefon.Text != "Musisz uzupełnić" && textBoxPESEL.Text != "" && textBoxPESEL.Text != "Musisz uzupełnić" && textBoxWynagrodzenie.Text != "" && textBoxWynagrodzenie.Text != "Musisz uzupełnić")
        //        {

        //            DateTime tempData = DateTime.Now;
        //            string data = tempData.ToShortDateString();

        //            LINQBazaBankDataContext dc = new LINQBazaBankDataContext(Bank.Properties.Settings.Default.BankConnectionString);

        //            Pracownicy bob = new Pracownicy();
        //            bob.Imię_pracownika = textBoxImie.Text.TrimEnd();
        //            bob.Nazwisko_pracownika = textBoxNazwisko.Text.TrimEnd();
        //            bob.Password = PasswordBoxHaslo.Password.ToString().TrimEnd();
        //            bob.PESEL = textBoxPESEL.Text;
        //            bob.Data_zatrudnienia = tempData;
        //            bob.Wynagrodzenie = decimalParse1;
        //            bob.Telefon = intParse1;
        //            bob.zaznaczony = false;
        //            bob.aktywny = true;

        //            dc.Pracownicy.InsertOnSubmit(bob);
        //            dc.SubmitChanges();

        //            MessageBox.Show("Dodawanie powiodło się.");

        //            this.Close();

        //        }

        //        else
        //        {
        //            if (textBoxImie.Text == "")
        //            {
        //                textBoxImie.Foreground = Brushes.Red;
        //                textBoxImie.FontWeight = FontWeights.Bold;
        //                textBoxImie.Text = "Musisz uzupełnić";
        //            }
        //            if (textBoxNazwisko.Text == "")
        //            {
        //                textBoxNazwisko.Foreground = Brushes.Red;
        //                textBoxNazwisko.FontWeight = FontWeights.Bold;
        //                textBoxNazwisko.Text = "Musisz uzupełnić";
        //            }
        //            if (PasswordBoxHaslo.Password == "")
        //            {
        //                PasswordBoxHaslo.Foreground = Brushes.Red;
        //                PasswordBoxHaslo.FontWeight = FontWeights.Bold;
        //                PasswordBoxHaslo.Password = "Musisz uzupełnić";
        //            }
        //            if (textBoxTelefon.Text == "")
        //            {
        //                textBoxTelefon.Foreground = Brushes.Red;
        //                textBoxTelefon.FontWeight = FontWeights.Bold;
        //                textBoxTelefon.Text = "Musisz uzupełnić";
        //            }
        //            if (textBoxPESEL.Text == "")
        //            {
        //                textBoxPESEL.Foreground = Brushes.Red;
        //                textBoxPESEL.FontWeight = FontWeights.Bold;
        //                textBoxPESEL.Text = "Musisz uzupełnić";
        //            }
        //            if (textBoxWynagrodzenie.Text == "")
        //            {
        //                textBoxWynagrodzenie.Foreground = Brushes.Red;
        //                textBoxWynagrodzenie.FontWeight = FontWeights.Bold;
        //                textBoxWynagrodzenie.Text = "Musisz uzupełnić";
        //            }

        //        }
        //    }
        //    else
        //    {
        //        MessageBox.Show("Podałeś błędne dane.  \n" + Imie + nazwisko + pesel + haslo + telefon + telefon2 + wynagr1 + wynagr2 + "");

        //    }
        //    */

        //}

       
    }
}