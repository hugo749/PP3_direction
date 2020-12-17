using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using ModelLayer.Data;
using ModelLayer.Business;

namespace PP3_direction
{
    /// <summary>
    /// Logique d'interaction pour App.xaml
    /// </summary>
    public partial class App : Application
    {
        private Dbal mydbal;
        private DaoAvis thedaoavis;
        private DaoClient thedaoclients;
        private DaoObstacle thedaoobstacles;
        private DaoPlacement_Obst thedaoplacement;
        private DaoReservation thedaoreservation;
        private DaoSalle thedaosalles;
        private DaoTheme thedaotheme;
        private DaoUtilisateur thedaoutilisateurs;
        private DaoVille thedaoville;
        private DaoHeure thedaoheure;


        public void Application_Startup(object sender, StartupEventArgs e)
        {
            //C'est ici, dans la méthode Application_Startup, qu'on instancie nos objets Dbal et Dao

            mydbal = new Dbal("Escp_Game");
            thedaoclients = new DaoClient(mydbal);
            thedaotheme = new DaoTheme(mydbal);
            thedaoavis = new DaoAvis(mydbal, thedaoclients, thedaotheme);
            thedaoobstacles = new DaoObstacle(mydbal, thedaotheme);
            thedaoville = new DaoVille(mydbal);
            thedaosalles = new DaoSalle(mydbal, thedaoville, thedaotheme);
            thedaoutilisateurs = new DaoUtilisateur(mydbal, thedaoville);
            thedaoreservation = new DaoReservation(mydbal, thedaoclients, thedaosalles, thedaoutilisateurs, thedaotheme);
            thedaoplacement = new DaoPlacement_Obst(mydbal, thedaoreservation, thedaoobstacles);
            thedaoheure = new DaoHeure(mydbal);




            // Create the startup window
            //là, on lance la fenêtre souhaitée en instanciant la classe de notre fenêtre
            directeur wnd = new directeur(thedaoavis,thedaoclients,thedaoobstacles,thedaoplacement,thedaoreservation,thedaosalles,thedaotheme,thedaoutilisateurs,thedaoville, thedaoheure);            //et on utilise la méthode Show() de notre objet fenêtre pour afficher la fenêtre
            //exemple: MainWindow lafenetre = new MainWindow(); (et on y passe en paramètre Dbal et Dao au besoin)
            wnd.Show();

        }

        //Méthode permettant d'afficher les exceptions non gérées (voir wpftutorial.com)
        public void Application_DispatcherUnhandledException(object sender, System.Windows.Threading.DispatcherUnhandledExceptionEventArgs e)
        {
            MessageBox.Show("An unhandled exception just occurred: " + e.Exception.Message, "Exception Sample", MessageBoxButton.OK, MessageBoxImage.Warning);
            e.Handled = true;
        }
    }
}
