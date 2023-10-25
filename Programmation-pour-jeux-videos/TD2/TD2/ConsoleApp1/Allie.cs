using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TD
{
    class Allie
    {

        public int pointsAttaque;
        public int vie;
        private int id;
        
        public Allie()
        {
            pointsAttaque = 20;
            vie = 100;
        }
        public void attaque()
        { //méthode
            Console.WriteLine("J’attaque: - " + pointsAttaque);
        }
        public void defendPersonnage()
        { //méthode
            Console.WriteLine("Je me défend");
        }


        // GETTER

        public int getPointsAttaque()
        {
            return pointsAttaque;
        }


        public int getVie()
        {
            return vie;
        }

        // SETTER

        public void setPointsAttaque(int pa)
        {
            pointsAttaque = pa;
        }

        public void setVie(int vi)
        {
            vie = vi;
        }
    }
}
