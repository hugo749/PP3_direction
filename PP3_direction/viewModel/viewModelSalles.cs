using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
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
        private ICommand suprimerHeure;
        private ICommand suprimerSalle;
        private ICommand Ajouterdansliste;

        private ICommand decaleruneheure;
        private ICommand Ajouterheure;

        private DaoHeure _thedaoheure;
        private ObservableCollection<Client> listClients;
        private ObservableCollection<Avis> listAvis;
        private ObservableCollection<Obstacle> listObstacles;
        private ObservableCollection<Placement_Obstacle> listPlacement;
        private ObservableCollection<Reservation> listreservation;
        private ObservableCollection<Salle> listsalle;
        private ObservableCollection<Theme> listtheme;
        private ObservableCollection<Utilisateur> listutilisateur;
        private ObservableCollection<Ville> listville;
        private ObservableCollection<Heure> listheure;

        private Salle selectedSalle = new Salle();
        private Client selectedClient = new Client();
        private Avis selectesAvis = new Avis();
        private Theme selectedTheme = new Theme();
        private Obstacle selectedObstacles = new Obstacle();
        private Heure selectedHeure = new Heure();
        private Ville selectedVille = new Ville();

        public string Recherche { get; set; }
        public string Heure { get; set; }

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
        public ObservableCollection<Heure> Listheure { get => listheure; set => listheure = value; }
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
                if (Selectedavis.Commentaire != value)
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

                    List<Avis> unsliste;
                    ListAvis.Clear();
                    unsliste = _thedaoavis.Listedesclients(selectedClient);
                    foreach (Avis item in unsliste)
                    {
                        ListAvis.Add(item);
                    }

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



        //----------------------//
        //   Liste des salles   //
        //----------------------//




        public Salle Selectedsalles
        {
            get => selectedSalle;
            set
            {
                if (selectedSalle != value)
                {
                    selectedSalle = value;

                    OnPropertyChanged("Theme");
                    OnPropertyChanged("Nomville");
                    //OnPropertyChanged("Selectedsalle");


                }
            }
        }






























        //------------------------//
       //   Fenêtre Obstacles    //
      //------------------------//



        public Ville Selectesvilles
        {
            get => selectedVille;
            set
            {
                if (selectedVille != value)
                {
                    selectedVille = value;
                    OnPropertyChanged("Listville");
                }
            }
        }

        public string nom
        {
            get => Selectesvilles.Nom;
            set
            {
                if (Selectesvilles.Nom != value)
                {
                    Selectesvilles.Nom = value;
                    OnPropertyChanged("Listville");
                }
            }
        }


        






































        public Heure Selectedheure
        {
            get => selectedHeure;
            set
            {

                if (selectedHeure != value)
                {

                    selectedHeure = value;



                    OnPropertyChanged("Listheure");


                }
            }
        }

        public DateTime heure
        {
            get => Selectedheure.Heuree;

            set
            {
                if (Selectedheure.Heuree != value)
                {
                    Selectedheure.Heuree = value;
                    OnPropertyChanged("Listheure");
                }
            }
        }


        public string Theme
        {
            get
            {
                if (selectedSalle.IdTheme != null)
                {
                    return selectedSalle.IdTheme.Nom;
                }
                else
                {
                    return null;
                }
            }
            set 
            {
                if (selectedSalle.IdTheme.Nom != value)
                {
                    selectedSalle.IdTheme.Nom = value;
                    OnPropertyChanged("Theme");
                }
            }
        }

        public string Nomville
        {
            get
            {
                if (selectedSalle.IdLieu != null)
                {
                    return selectedSalle.IdLieu.Nom;
                }
                else
                {
                    return null;
                }

            }
            set
            {
                if (selectedSalle.IdLieu.Nom != value)
                {
                    selectedSalle.IdLieu.Nom = value;
                    OnPropertyChanged("Nomville");
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
            DaoVille thedaoville,
            DaoHeure thedaoheure)
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
            _thedaoheure = thedaoheure;

            listAvis = new ObservableCollection<Avis>(thedaoavis.Listedesclients(Selectedclient));
            listClients = new ObservableCollection<Client>(thedaoclients.SelectAll());
            listObstacles = new ObservableCollection<Obstacle>(thedaoobstacles.SelectAll());
            listPlacement = new ObservableCollection<Placement_Obstacle>(thedaoplacement.SelectAll());
            listreservation = new ObservableCollection<Reservation>(theDaoReservation.SelectAll());
            listsalle = new ObservableCollection<Salle>(thedaosalles.SelectAll());
            listtheme = new ObservableCollection<Theme>(thedaotheme.SelectAll());
            listutilisateur = new ObservableCollection<Utilisateur>(thedaoutilisateurs.SelectAll());
            listville = new ObservableCollection<Ville>(thedaoville.SelectAll());
            listheure = new ObservableCollection<Heure>(thedaoheure.SelectAll());

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
                List<Client> listClienIndep = new List<Client>(_thedaoclients.SearchbyName("Clients", "Nom Like '" + this.Recherche + "' or Prenom like '" + this.Recherche + "'"));
                ListClients.Clear();
                foreach (Client c in listClienIndep)
                {
                    ListClients.Add(c);
                }
            }
            //else RefreshListCli();
        }








        private void Heurees()
        {
            
            
                List<Heure> Listheure = new List<Heure>();

                foreach (Heure c in Listheure)
                {
                    Listheure.Add(c);
                }
            

        }



        public ICommand ajouterheures
        {
            get
            {
                if (this.decaleruneheure == null)
                {
                    this.decaleruneheure = new RelayCommand(() => Heurees(), () => true);
                }
                return this.decaleruneheure;



            }
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
        private void SuprimerHeurelist()
        {
            this._thedaoheure.Delete(this.selectedHeure);
            int a = listheure.IndexOf(selectedHeure);
            listheure.RemoveAt(a);
            MessageBox.Show("Heure supprimé !");
        }
        public ICommand SuprimerHeure
        {
            get
            {
                if (this.suprimerHeure == null)
                {
                    this.suprimerHeure = new RelayCommand(() => SuprimerHeurelist(), () => true);
                }
                return this.suprimerHeure;



            }
        }

        //private void Ajouteruneheurealamain()
        //{

        //}



        private void Suprimersallelist()

        {
            if (Selectedsalles != null)
            {
                Salle lessalles = new Salle();
                List<Salle> lesalles = new List<Salle>();
                lessalles = Selectedsalles;
                _thedaosalles.Delete(lessalles);
                lesalles = _thedaosalles.SelectAll();
                Listsalle.Clear();
                foreach (Salle item in lesalles)
                {
                    Listsalle.Add(item);
                }
                //this._thedaosalles.Delete(this.selectedSalle);
                ////int a = listsalle.IndexOf(selectedSalle);
                //listsalle.Remove(selectedSalle);
                MessageBox.Show("Salle supprimé !");
            }

        }
        public ICommand Suprimersalle
        {
            get
            {
                if (this.suprimerSalle == null)
                {
                    this.suprimerSalle = new RelayCommand(() => Suprimersallelist(), () => true);
                }
                return this.suprimerSalle;



            }
        }



        public void RefreshListCli()

        {
            if (Selectedsalles != null)
            {
                Salle lessalles = new Salle();
                List<Salle> lesalles = new List<Salle>();
                lessalles = Selectedsalles;
                _thedaosalles.Delete(lessalles);
                lesalles = _thedaosalles.SelectAll();
                Listsalle.Clear();
                foreach (Salle item in lesalles)
                {
                    Listsalle.Add(item);
                }
                this._thedaosalles.Delete(this.selectedSalle);
                int a = listsalle.IndexOf(selectedSalle);
                listsalle.Remove(selectedSalle);
                MessageBox.Show("Salle supprimé !");
            }

        }
        //public ICommand Suprimersalle
        //{
        //    get
        //    {
        //        if (this.suprimerSalle == null)
        //        {
        //            this.suprimerSalle = new RelayCommand(() => Suprimersallelist(), () => true);
        //        }
        //        return this.suprimerSalle;



        //    }
        //}



                //public void RefreshListCli()
                //{
                //    ObservableCollection<Client> lalistClient = new ObservableCollection<Client>(_thedaoclients.SelectAll());
                //    listClients.Clear();
                //    foreach (Client c in lalistClient)
                //    {
                //        listClients.Add(c);
                //    }
                //}


            }
        }
    
