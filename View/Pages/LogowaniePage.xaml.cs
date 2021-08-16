using Bank2.Navigators;
using Bank2.ViewModel;
using System.Windows;
using System.Windows.Controls;

namespace Bank2.View.Pages
{
    /// <summary>
    /// Interaction logic for LogowaniePage.xaml
    /// </summary>
    public partial class LogowaniePage : Page
    {
        private INavigator _navigator;
        public LogowaniePage()
        {
            InitializeComponent();
            //  DataContext = new VMLogowanie();

        }
        public LogowaniePage(INavigator navigator)
        {
            _navigator = navigator;

        }
        private void OnClickZaloguj(object sender, RoutedEventArgs e)
        {
            /*  bool zalogowany = false;

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
              }*/
            _navigator.CurrentViewModel = new VMPracownikKlienci(_navigator);
            //_navigator.CurrentViewModelChanged+=
            // Zaloguj = new UpdateCurrentViewModelCommand<VMPracownikLayout>(_navigator, () => new VMPracownikLayout(_navigator));

        }






    }
}
