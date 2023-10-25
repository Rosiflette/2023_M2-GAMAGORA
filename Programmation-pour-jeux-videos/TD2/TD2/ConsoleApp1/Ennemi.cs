using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TD
{
    public class Ennemi
    {
        public int pointsAttaque;
        public double vitesse;
        private int id;
        public int vie;
        public Ennemi()
        {
            vie = 100;
            vitesse = 5;
            pointsAttaque = 20;
        }
        public void attaque()
        { //méthode
            Console.WriteLine("J’attaque: - " +pointsAttaque);
        }
        public void defend()
        { //méthode
            Console.WriteLine("Je me défend");
        }
        public void incrementerPointAttaque()
        { //méthode
            Console.WriteLine("Je prépare mon attaque!");
            pointsAttaque++;
        }

        // GETTER

        public int getPointsAttaque()
        {
            return pointsAttaque;
        }

        public double getVitesse()
        {
            return vitesse;
        }

        public int getID()
        {
            return id;
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

        public void setVitesse(double vit)
        {
            vitesse = vit;
        }

        public void setID(int ident)
        {
            id = ident;
        }

        public void setVie(int vi)
        {
            vie = vi;
        }
    }
}
