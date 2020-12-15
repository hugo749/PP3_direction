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
using ModelLayer.Business;
using ModelLayer.Data;
using PP3_direction.viewModel;


namespace PP3_direction
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class directeur : Window
    {
        public directeur(DaoAvis thedaoavis, DaoClient thedaoclient, DaoObstacle thedaoobstacle, DaoPlacement_Obst thedaoPlacement_Obst, DaoReservation theDaoReservation, DaoSalle thedaosalle, DaoTheme thedaotheme,DaoUtilisateur thedaoutilisateur,DaoVille thedaoville )
        {
            InitializeComponent();
            Globale.DataContext = new viewModel.viewModelSalles(thedaoavis, thedaoclient ,thedaoobstacle, thedaoPlacement_Obst, theDaoReservation, thedaosalle,thedaotheme,thedaoutilisateur,thedaoville);
            grid1.Visibility = Visibility.Hidden;
            grid2.Visibility = Visibility.Hidden;
            grid3.Visibility = Visibility.Hidden;
            grid4.Visibility = Visibility.Hidden;
            HOME.Visibility = Visibility.Visible;
            
        }

        private void ButtonPOPUPlog_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void ListViewItem_Selected(object sender, RoutedEventArgs e)
        {
            grid1.Visibility = Visibility.Visible;
            grid2.Visibility = Visibility.Hidden;
            grid3.Visibility = Visibility.Hidden;
            grid4.Visibility = Visibility.Hidden;
            HOME.Visibility = Visibility.Hidden;
            
        }

        private void ListViewItem_Selected_1(object sender, RoutedEventArgs e)
        {
            grid2.Visibility = Visibility.Visible;
            grid1.Visibility = Visibility.Hidden;
            grid3.Visibility = Visibility.Hidden;
            grid4.Visibility = Visibility.Hidden;
            HOME.Visibility = Visibility.Hidden;
            
        }

        private void ListViewItem_Selected_2(object sender, RoutedEventArgs e)
        {
            grid3.Visibility = Visibility.Visible;
            grid1.Visibility = Visibility.Hidden;
            grid2.Visibility = Visibility.Hidden;
            grid4.Visibility = Visibility.Hidden;
            HOME.Visibility = Visibility.Hidden;
            
        }

        private void ListViewItem_Selected_3(object sender, RoutedEventArgs e)
        {
            grid4.Visibility = Visibility.Visible;
            grid1.Visibility = Visibility.Hidden;
            grid2.Visibility = Visibility.Hidden;
            grid3.Visibility = Visibility.Hidden;
            HOME.Visibility = Visibility.Hidden;
            
        }

        

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Window fenetre = new Window();
            fenetre.ShowDialog();
        }

        private void ListViewItem_Selected_4(object sender, RoutedEventArgs e)
        {
            grid4.Visibility = Visibility.Hidden;
            grid1.Visibility = Visibility.Hidden;
            grid2.Visibility = Visibility.Hidden;
            grid3.Visibility = Visibility.Hidden;
            HOME.Visibility = Visibility.Hidden;
            
        }

       
    }

}
