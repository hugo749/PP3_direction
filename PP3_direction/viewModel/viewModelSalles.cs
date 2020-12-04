using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using ModelLayer.Business;
using ModelLayer.Data;

namespace PP3_direction.viewModel
{
    class viewModelSalles : viewModelBase
    {
        //déclaration des attributs ...à compléter
        private DaoAvis _thedaoavis;
        private DaoClient _thedaoclients;
        private DaoObstacle _thedaoobstacles;
        private DaoPlacement_Obst _thedaoplacement;
        private DaoReservation _thedaoreservation;
        private DaoSalle _thedaosalles;
        private DaoTheme _thedaotheme;
        private DaoUtilisateur _thedaoutilisateurs;
        private DaoVille _thedaoville;
        private ICommand updateCommand;
        private ObservableCollection<Client> listClients; 
        private ObservableCollection<Avis> listAvis;
        private ObservableCollection<Obstacle> listObstacles;
        private ObservableCollection<Placement_Obstacle> listPlacement;
        private ObservableCollection<Reservation> listreservation;
        private ObservableCollection<Salle> listsalle;
        private ObservableCollection<Theme> listtheme;
        private ObservableCollection<Utilisateur> listutilisateur;
        private ObservableCollection<Ville> listville;

        private Salle selectedSalle = new Salle();


        //déclaration des listes...à compléter avec les fromages
        public ObservableCollection<Avis> ListAvis { get => listAvis; set => listAvis = value; }
        public ObservableCollection<Client> ListClients { get => listClients; set => listClients = value; }
        public ObservableCollection<Obstacle> ListObstacles { get => listObstacles; set => listObstacles = value; }
        public ObservableCollection<Placement_Obstacle> ListPlacement { get => listPlacement; set => listPlacement = value; }
        public ObservableCollection<Reservation> Listreservation { get => listreservation; set => listreservation = value; }
        public ObservableCollection<Salle> Listsalle { get => listsalle; set => listsalle = value; }
        public ObservableCollection<Theme> Listtheme { get => listtheme; set => listtheme = value; }
        public ObservableCollection<Utilisateur> Listutilisateur { get => listutilisateur; set => listutilisateur = value; }
        public ObservableCollection<Ville> Listville { get => listville; set => listville = value; }

        //déclaration des propriétés avec OnPropertyChanged("nom_propriété_bindée")
        //par exemple...


        public Ville Nom
        {
            get => Selectedsalle.IdLieu;
            set
            {
                if (Selectedsalle.IdLieu != value)
                {
                    Selectedsalle.IdLieu = value;
                    OnPropertyChanged("Nom");
                }
            }
        }

        //public Object Id
        //{

        //}



        public Salle Selectedsalle
        {
            get => selectedSalle;
            set
            {
                if (selectedSalle != value)
                {
                    selectedSalle = value;

                    OnPropertyChanged("Listsalle");
                    OnPropertyChanged("Nom");
                    OnPropertyChanged("Nombre");


                }
            }
        }

        public viewModelSalles(DaoAvis thedaoavis,
            DaoClient thedaoclients,
            DaoObstacle thedaoobstacles,
            DaoPlacement_Obst thedaoplacement,
            DaoReservation theDaoReservation,
            DaoSalle thedaosalles,
            DaoTheme thedaotheme,
            DaoUtilisateur thedaoutilisateurs,
            DaoVille thedaoville)
        {
            _thedaoavis = thedaoavis;
            _thedaoclients = thedaoclients;
            _thedaoobstacles = thedaoobstacles;
            _thedaoplacement = thedaoplacement;
            _thedaoreservation = theDaoReservation;
            _thedaosalles = thedaosalles;
            _thedaotheme = thedaotheme;
            _thedaoutilisateurs = thedaoutilisateurs;
            _thedaoville = thedaoville;

            ListAvis = new ObservableCollection<Avis>(thedaoavis.SelectAll());
            ListClients = new ObservableCollection<Client>(thedaoclients.SelectAll());
            ListObstacles = new ObservableCollection<Obstacle>(thedaoobstacles.SelectAll());
            ListPlacement = new ObservableCollection<Placement_Obstacle>(thedaoplacement.SelectAll());
            Listreservation = new ObservableCollection<Reservation>(theDaoReservation.SelectAll());
            Listsalle = new ObservableCollection<Salle>(thedaosalles.SelectAll());
            Listtheme = new ObservableCollection<Theme> (thedaotheme.SelectAll());
            listutilisateur = new ObservableCollection<Utilisateur> (thedaoutilisateurs.SelectAll());
            listville = new ObservableCollection<Ville>(thedaoville.SelectAll());

            //foreach (Fromage lefromage in ListFromages)
            //{
            //    foreach (Pays lepays in ListPays)
            //    {
            //        if (lefromage.Origin.Id == lepays.Id)
            //        {
            //            lefromage.Origin = lepays;

            //        }
            //    }
            //}

            //foreach (joueur unjoueur in listjoueur)//elle va chercher dans la fromage (liste de droite du wpf)
            //{
            //   int i = 0;//i est à 0 ce qui va nous permettrent de chercher les id
            //   while (unjoueur.Unpays != listpays[i].Id)//le while nous permet de faire une boucle qui ne va pas s'arreter tant que l'id de fromage ne sera pas = à l'id de la liste pays à gauche 
            //    {
            //        i++;//va faire le tour de tous les id de la liste pays (gauche)
            //    }
            //    unjoueur.Unpays = listpays[i];//sors de la boucle quand les id sont les mêmes puis affiche dans origin le puis souhaité
            //}

        }

        //Méthode appelée au click du bouton UpdateCommand
        //public ICommand UpdateCommand
        //{
        //    get
        //    {
        //        if (this.updateCommand == null)
        //        {
        //            this.updateCommand = new RelayCommand(() => Updatejoueur(), () => true);
        //        }
        //        return this.updateCommand;

        //    }

        //}

        //private void Updatejoueur()
        //{
        //    //code du bouton - à coder
        //    this.vmDAOjoueur.update(this.selectedjoueur);
        //    MessageBox.Show("MAJ à été accepté avec succés", "MISE A JOUR");
        //    //listFromages = (ObservableCollection<Fromage>)vmDAOfromage.SelectAll();
        //    int place = Listjoueur.IndexOf(selectedjoueur);
        //    Listjoueur.Remove(selectedjoueur);
        //    listjoueur.Insert(index: place, selectedjoueur);

        //}




    }
}
