using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TD
{
    class Personnage
    {

        public int vie;
        public double vitesse;
        private int id;
        public Personnage()
        {
            vie = 100;
            vitesse = 5;
        }

        public void marche()
        { //méthode
            Console.WriteLine("Je marche");
        }

        public void arrette()
        { //méthode
            Console.WriteLine("Je m'arrete");
        }

        // GETTER

        public int getVie()
        {
            return vie;
        }

        // SETTER

        public void setVie(int vi)
        {
            vie = vi;
        }
    }
}
