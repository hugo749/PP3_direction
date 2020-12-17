using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLayer.Business
{
    public class Heure
    {
        private int id;
        private DateTime heure;

        public int Id { get => id; set => id = value; }
        public DateTime Heuree { get => heure; set => heure = value; }

        public Heure(int id, DateTime heure)
        {
            Id = id;
            Heuree=heure;
        }
        
        public Heure(){}

        public override string ToString()
        {
            return this.Heuree.ToString("t");
        }
    }
}
