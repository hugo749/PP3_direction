using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelLayer.Business;
using CsvHelper.Configuration;
using CsvHelper.TypeConversion;
using System.Data;
using System.Runtime.CompilerServices;
using System.IO;
using CsvHelper;
using System.Globalization;

namespace ModelLayer.Data
{
    public class DaoHeure
    {
        private Dbal mydbal;
        private DaoHeure theDaoHeure;
        private DaoVille theDaoVille;

        public DaoHeure(Dbal dbal)
        {
            mydbal = dbal;
            
        }

        public List<Heure> SelectAll()
        {
            List<Heure> listheure = new List<Heure>();
            DataTable myTable = this.mydbal.SelectAll("Heure");

            foreach (DataRow t in myTable.Rows)
            {
                listheure.Add(new Heure((int)t["id"], (DateTime)t["heure"]));
            }
            return listheure;
        }

        public void Insert(Heure uneheure)
        {
            string query = "Heure (id, heure) VALUES ("
                + uneheure.Id + ",'"
                + uneheure.Heuree + ")";
            this.mydbal.Insert(query);
        }

        //public void Update(Heure uneheure)
        //{
        //    string query = "Ville Set id = " + uneVille.Id
        //        + ", nom = '" + uneVille.Nom.Replace("'", "''")
        //        + "Where id = " + uneVille.Id;
        //    this.mydbal.Update(query);
        //}

        public void Delete(Heure uneheure)
        {
            string query = " Heure Where id = " + uneheure.Id;
            this.mydbal.Delete(query);
        }



        //public List<Ville> SelectAll()
        //{
        //    List<Ville> listVille = new List<Ville>();
        //    DataTable myTable = this.mydbal.SelectAll("Ville");

        //    foreach (DataRow r in myTable.Rows)
        //    {
        //        listVille.Add(new Ville((int)r["id"], (string)r["nom"]));
        //    }
        //    return listVille;
        //}

        //public Ville SelectbyId(int id)
        //{
        //    DataRow rowVille = this.mydbal.SelectById("ville", id);
        //    return new Ville((int)rowVille["id"],(string)rowVille["nom"]);
        //}


    }
}
