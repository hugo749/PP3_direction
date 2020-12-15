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
        private ICommand barreCommande;
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
        private Client selectedClient = new Client();
        private Avis selectesAvis = new Avis();
        private Theme selectedTheme = new Theme();
        private Obstacle selectedObstacles = new Obstacle();

        public string Recherche { get; set; }

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




        //public Object Count
        //{

        //}

        //public Client nom
        //{
        //    get => Selectedclient.IdClient;
        //    set
        //    {
        //        if (Selectedclient.IdClient != value)
        //        {
        //            Selectedclient.IdClient = value;
        //            OnPropertyChanged("Listclient");
        //        }
        //    }
        //}





        //----------------------//
        //   Liste des clients  //
        //----------------------//

        public string PrenomClient
        {
            get => Selectedclient.Prenom;

            set
            {
                if (Selectedclient.Prenom != value)
                {
                    Selectedclient.Prenom = value;
                    OnPropertyChanged("PrenomClient");
                }
            }
        }

        public string AdressClient
        {
            get => Selectedclient.Mail;
            set
            {
                if (Selectedclient.Mail != value)
                {
                    Selectedclient.Mail = value;
                    OnPropertyChanged("AdressClient");
                }
            }
        }

        public string NomClient
        {
            get
            {
                if (Selectedclient.Nom != null)
                {
                    return Selectedclient.Nom;
                }
                else
                {
                    return null;
                }

            }
                set
            {
                if (Selectedclient.Nom != value)
                {
                    Selectedclient.Nom = value;
                    OnPropertyChanged("NomClient");
                }
            }
        }

        public int TelClient
        {
            get => Selectedclient.Telephone;

            set
            {
                if (Selectedclient.Telephone != value)
                {
                    Selectedclient.Telephone = value;
                    OnPropertyChanged("TelClient");
                }
            }
        }

        public DateTime DDNClient
        {
            get => Selectedclient.DateNaissance;

            set
            {
                if (Selectedclient.DateNaissance != value)
                {
                    Selectedclient.DateNaissance = value;
                    OnPropertyChanged("DDNClient");
                }
            }
        }

        public string AvisClients
        {
            get => Selectedavis.Commentaire;
            set
            {
                if (Selectedavis.Commentaire !=  value)
                {
                    selectesAvis.Commentaire = value;
                    OnPropertyChanged("");
                }
            }
        }

       public Avis Selectedavis
        {
            get => selectesAvis;
            set
            {
                if (selectesAvis != value)
                {
                    selectesAvis = value;
                    OnPropertyChanged("ListAvis");
                }
            }
        }

        public Client Selectedclient
        {
            get => selectedClient;
            set
            {
                if (selectedClient != value)
                {
                    selectedClient = value;

                    OnPropertyChanged("Listclient");
                    OnPropertyChanged("NomClient");
                    OnPropertyChanged("PrenomClient");
                    OnPropertyChanged("AdressClient");
                    OnPropertyChanged("TelClient");
                    OnPropertyChanged("DDNClient");
                    OnPropertyChanged("AvisClient");

                }
            }
        }







        //public List<Avis> LesAvisClients(DaoAvis thedaoavis, DaoClient thedaoclient)
        //{
        //    List<Avis> lesavisvide = new List<Avis>();
            
        //    List<Avis> lesavis = new List<Avis>(thedaoavis.SelectAll());
        //    foreach (Avis item in lesavis)
        //    {
        //        if (item.IdClient.Id == selectedClient.Id)
        //        {
        //            lesavisvide.Add(item);
        //        }
        //    }
        //    return lesavisvide;
        //}





        //----------------------//
        //   Liste des salles   //
        //----------------------//
        public string Nomville
        {
            get
            {
                if (Selectedsalle.Id != 0)
                {
                    return Selectedsalle.IdLieu.Nom;
                }
                else
                {
                    return null;
                }
            }
                

            set
            {
                if (Selectedsalle.IdLieu.Nom != value)
                {
                    Selectedsalle.IdLieu.Nom = value;
                    OnPropertyChanged("Nomville");
                }
            }
        }

        public Salle Selectedsalle
        {
            get => selectedSalle;
            set
            {
                if (selectedSalle != value)
                {
                    selectedSalle = value;

                    OnPropertyChanged("Listsalle");
                    OnPropertyChanged("Nomville");
                   
                    
                }
            }
        }



        //----------------------//
        //  Liste des infosalle //
        //----------------------//
        

        public string Themes
        {
            get
            {
                if (selectedTheme != null)
                {
                    return selectedTheme.Nom;
                }
                else
                {
                    return null;
                }

            }

            set
            {
                if (selectedTheme.Nom != value)
                {
                    selectedTheme.Nom = value;
                    OnPropertyChanged("Themes");
                }
            }
        }


        public Salle Selectedsalles
        {
            get => selectedSalle;
            set
            {
                if (selectedSalle != value)
                {
                    selectedSalle = value;

                    
                    OnPropertyChanged("Nomvilles");
                    OnPropertyChanged("Themes");

                }
            }
        }



        public Obstacle Selectedobstacles
        {
            get => selectedObstacles;
            set
            {
                if (selectedObstacles != value)
                {
                    selectedObstacles = value;

                    OnPropertyChanged("ListObstacles");
                }
            }
        }

        public string UnObstacle
        {
            get => Selectedobstacles.Nom;
            set
            {
                if (Selectedobstacles.Nom != value)
                {
                    Selectedobstacles.Nom = value;
                    OnPropertyChanged("ListObstacles");
                }
            }
        }

        public Theme Selectedtheme
        {
            get => selectedTheme;
            set
            {
                if (selectedTheme != value)
                {
                    selectedTheme = value;
                    OnPropertyChanged("Listtheme");
                }
            }
        }

        public string UnTheme
        {
            get =>Selectedtheme.Nom;
            set
            {
                if (Selectedtheme.Nom != value)
                {
                    Selectedtheme.Nom = value;
                    OnPropertyChanged("Listtheme");
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

            listAvis = new ObservableCollection<Avis>(thedaoavis.SelectAll());
            listClients = new ObservableCollection<Client>(thedaoclients.SelectAll());
            listObstacles = new ObservableCollection<Obstacle>(thedaoobstacles.SelectAll());
            listPlacement = new ObservableCollection<Placement_Obstacle>(thedaoplacement.SelectAll());
            listreservation = new ObservableCollection<Reservation>(theDaoReservation.SelectAll());
            listsalle = new ObservableCollection<Salle>(thedaosalles.SelectAll());
            listtheme = new ObservableCollection<Theme> (thedaotheme.SelectAll());
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


        private void Rechercher()
        {
            if (this.Recherche != "")
            {
                List<Client> listClienIndep = new List<Client>(_thedaoclients.SearchbyName("Clients","Nom Like '" + this.Recherche + "' or Prenom like '" + this.Recherche + "'"));
                ListClients.Clear();
                foreach (Client c in listClienIndep)
                {
                    ListClients.Add(c);
                }
            }
            else RefreshListCli();
        }


        public ICommand BarreCommande
        {
            get
            {
                if (this.barreCommande == null)
                {
                    this.barreCommande = new RelayCommand(() => Rechercher(), () => true);
                }
                return this.barreCommande;



            }
        }


        public void RefreshListCli()
        {
            ObservableCollection<Client> lalistClient = new ObservableCollection<Client>(_thedaoclients.SelectAll());
            listClients.Clear();
            foreach (Client c in lalistClient)
            {
                listClients.Add(c);
            }
        }


    }
}
