using Bank2.Model;
using Bank2.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Bank2.View.Pages
{
    /// <summary>
    /// Interaction logic for LogowaniePage.xaml
    /// </summary>
    public partial class LogowaniePage: Page
    {
        public LogowaniePage()
        {
            InitializeComponent();
          //  DataContext = new VMLogowanie();
            
        }
        private void OnClickZaloguj(object sender, RoutedEventArgs e)
        {
            bool zalogowany = false;

            if (textBoxImie.Text.Length > 0 && textBoxNazwisko.Text.Length > 0 && PasswordBox.Password.Length > 0)
            {

                try
                {
                    Baza db = new Baza();


                    foreach (var item in db.Pracownicy)
                    {
                        if (
                            textBoxImie.Text == item.Imię_pracownika.TrimEnd()
                            && textBoxNazwisko.Text == item.Nazwisko_pracownika.TrimEnd()
                            && PasswordBox.Password == item.Password.TrimEnd())
                        {
                            zalogowany = true;
                            break;
                        }


                    }
                    if (zalogowany == true)
                    {
                        MessageBox.Show("Dobre dane logowania");
                    }
                    else
                    {
                        MessageBox.Show("Złe dane logowania");
                    }



                }
                catch
                {
                    MessageBox.Show("Błąd logowania do bazy danych.");
                }



            }
            else
            {
                MessageBox.Show("Uzupełnij wszystkie pola");
            }
        }
        PracownikPage page = new PracownikPage();

       
    }
}
