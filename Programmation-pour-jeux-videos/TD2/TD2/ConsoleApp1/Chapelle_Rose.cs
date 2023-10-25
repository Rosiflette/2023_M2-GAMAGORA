using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;

namespace TD
{
    class Program
    {
        /// <summary>
        /// Point d'entrée principal de l'application.
        /// </summary>

        static void Main(string[] args)
        {
            /*Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());*/

            int nbTours = 5;


            Personnage monPerso = new Personnage();
            Ennemi ennemi1 = new Ennemi();
            while (nbTours-- > 0)
            {



                Console.WriteLine("Touche \"H\" = soigner le personnage mais subit les dégats de l'attaque \n " +
                    "Touche \"Z\" = soigne l'allié et subis les dégats \n " +
                    "Touche \"D\" = demande à l’allié de faire le bouclier et de prendre les dommages causés par l’ennemi à la place du personnage.Le personnage se soigne en même temps \n " +
                    "Touche \"A\" = : demande à l’allié d’attaquer l’ennemi. Le personnage subit les dommages infligés par l’ennemi \n " +
                    "Que veux tu faire ?");


                string line = Console.ReadLine();
/*                line = line.ToUpper();
*/
                switch (line[0])
                {
                    case 'H':
                        Console.WriteLine("HHHHHH");
                        break;
                    default:
                        Console.WriteLine("Autre");
                        break;
                }

/*                monPerso.marche();
                ennemi1.attaque();
                Console.WriteLine("Vie personnage :" + monPerso.getVie());
                Console.WriteLine("Vie ennemi :" + ennemi1.vie);
                Console.WriteLine("L’ennemi attaque :" + ennemi1.pointsAttaque);
                monPerso.setVie(monPerso.getVie() - ennemi1.getPointsAttaque());
                ennemi1.incrementerPointAttaque();*/
            }
            Console.WriteLine("C'est fini. Game Over!");
        }
    }
}
