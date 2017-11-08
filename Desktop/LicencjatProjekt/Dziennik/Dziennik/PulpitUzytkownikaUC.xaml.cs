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
    /// Interaction logic for PulpitUzytkownikaUC.xaml
    /// </summary>
    public partial class PulpitUzytkownikaUC : UserControl
    {
        private osoby osoby;

        public PulpitUzytkownikaUC()
        {
            InitializeComponent();
        }

        public PulpitUzytkownikaUC(osoby osoby)
        {
            this.osoby = osoby;
        }
    }
}
