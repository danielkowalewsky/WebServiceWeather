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

namespace Dziennik
{
    /// <summary>
    /// Interaction logic for LogowanieUC.xaml
    /// </summary>
    public partial class LogowanieUC : UserControl
    {
        public LogowanieUC() //domyślny konstruktor, nie potrzebuje argumentów
        {
            InitializeComponent();
        }

        private void loginTextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            loginTextBox.Text = ""; //czyszczenie loginTextBox po kliknięciu
        }

        private void loginTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (loginTextBox.Text == "")
            { //jezeli nie zostało nic wpisane ponownie zostanie wpisany tekst "Login" w loginTextBox
                loginTextBox.Text = "Login"; 
            }
        }

        private void logujButton_Click(object sender, RoutedEventArgs e)
        {
            bazaPolaczenieDataContext db = new bazaPolaczenieDataContext(); //otwieranie połączenia do bazy
            string login = loginTextBox.Text; //przypisanie do zmiennych lokalnych loginu i hasła
            string haslo = passwordBox.Password.ToString();

            if (login == "") //sprawdzenie czy uzytkownik uzupełnił pole login i hasło
            {
                MessageBox.Show("Pole login musi być wypełnione!", "Błąd!");
            }
            else if (haslo == "")
            {
                MessageBox.Show("Pole haslo musi być wypełnione!", "Błąd!");
            }
            else //weryfikacja danych podanych do logowania
            {
                var sprawdzUzytkownika = (from x in db.osobies where x.login == login select x); //sprawdzanie czy istnieje login wpisany przez uzytkownika
                var sprawdzHaslo = (from x in db.osobies where x.haslo == haslo && x.login == login select x); //szukanie uzytkownika o podanym loginie i haśle

                if (sprawdzUzytkownika.Count() != 1) //jeżeli nie znalazło loginu podanego przez uzytkownika
                {
                    MessageBox.Show("Użytkownik z takim loginem nie istnieje!", "Błąd!"); //wyświetlenie błędu, że nie ma w bazie takiego loginu
                    loginTextBox.Clear(); //czyszczenie textbox'ów
                    passwordBox.Clear();

                }

                else if (sprawdzHaslo.Count() != 1) //jezeli nie znalazło jednej unikatowej osoby o podanym loginie i haśle
                {
                    MessageBox.Show("Błędne hasło", "Błąd"); //wyświetlenie komunikatu o błędnym haśle
                    passwordBox.Clear();
                }

                else
                {
                    osoby zalogowanaOsoba = (from osoby in db.osobies where osoby.login == login && osoby.haslo == haslo select osoby).Single();
                    UserControl zalogowany = new PulpitUzytkownikaUC(zalogowanaOsoba as osoby); 
                    Content = zalogowany; //otwieramy pulpit użytkownika
                }
            }
        }        
    }
}
