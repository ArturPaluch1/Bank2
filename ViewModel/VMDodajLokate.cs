using Bank2.Components;
using Bank2.Model;
using Bank2.Navigators;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Bank2.ViewModel
{
    class VMDodajLokate
    {
private Window _window;
private INavigator _navigator;
private UserControl _TablicaDanych;
public UserControl TablicaDanych
{
    get { return _TablicaDanych; }
    set
    {
        _TablicaDanych = value;
        OnPropertyChanged("TablicaDanych");
    }
}
private UserControl _TablicaDanych2;
private int _kwota;

public UserControl TablicaDanych2
{
    get { return _TablicaDanych2; }
    set
    {
        _TablicaDanych2 = value;
        OnPropertyChanged("TablicaDanych2");
    }
}

private void OnPropertyChanged(string v)
{
    // throw new NotImplementedException();
}


public ObservableCollection<KlienciDataModel> ListaKlientow { get; set; } = new ObservableCollection<KlienciDataModel>();
public ObservableCollection<RodzajeLokatDataModel> ListaRodzajowLokat { get; set; } = new ObservableCollection<RodzajeLokatDataModel>();

public ICommand Dodaj { get; set; }
public ICommand Anuluj { get; set; }

public int Kwota
{
    get { return _kwota; }
    set
    {
        _kwota = value;
        OnPropertyChanged("Kwota");
    }
}











public VMDodajLokate(Window window, INavigator navigator)
{
    _window = window;
    _navigator = navigator;
    ListaKlientow = new ListyZasobow().PobierzAktywniKlienci();
    ListaRodzajowLokat= new ListyZasobow().PobierzAktywneRodzajeLokat();
    _TablicaDanych = new KlienciTabela(_navigator);
    _TablicaDanych2 = new RodzajeLokatTabela(_navigator);

    Dodaj = new RelayCommand(DodajLokate);
    Anuluj = new RelayCommand(WyjdzZokna);
}

private void WyjdzZokna()
{
    _window.Close();
}

private void DodajLokate()
{
    Baza db = new Baza();
    Lokaty nowaLokata = new Lokaty();

    string bladKlienta = "";
    string bladRodzajuLokaty = "";
    string bladKwoty = "";
    int licznik = 0;
    KlienciDataModel temp1 = new KlienciDataModel();

    foreach (KlienciDataModel item in ListaKlientow)
    {
        if (item.IsSelected == true)
        {
            temp1 = item;
            licznik++;

        }

    }
    if (licznik == 1)
    {
        nowaLokata.Klient = temp1.Id_klienta;
        licznik = 0;
    }
    else
    {

        bladKlienta = "Musisz zaznaczyć dokładnie jednego klienta.\n";
    }

    //////////
    ///
    RodzajeLokatDataModel temp2 = new RodzajeLokatDataModel();

    foreach (RodzajeLokatDataModel item in ListaRodzajowLokat)
    {
        if (item.IsSelected == true)
        {
            temp2 = item;
            licznik++;

        }

    }
    if (licznik == 1)
    {
        nowaLokata.Id_Rodzaju_lokaty = temp2.Id_rodzaju_Lokaty;
        licznik = 0;
    }
    else
    {

                bladRodzajuLokaty = "Musisz zaznaczyć dokładnie jeden rodzaj lokaty.\n";
    }

    nowaLokata.aktywny = true;
    nowaLokata.Data_założenia = DateTime.Now;
    nowaLokata.Lokaty_udzielił = _navigator.zalogowanyPracownik.Id_Pracownika;


    nowaLokata.Wysokość_lokaty = this.Kwota;
    if (this.Kwota == 0 || this.Kwota == null)
    { bladKwoty = "Kwota lokaty nie może być zerowa"; }

    string tempString = bladKlienta + bladRodzajuLokaty + bladKwoty;
    if (tempString == "")
    {
        db.Lokaty.Add(nowaLokata);
        db.SaveChanges();
        MessageBoxResult result = MessageBox.Show("Lokata dodana", "", MessageBoxButton.OK);
        if (result == MessageBoxResult.OK)
        {
            _window.Close();
        }
    }
    else
        MessageBox.Show(tempString);


}
    }
}
