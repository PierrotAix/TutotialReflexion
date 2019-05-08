using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using TutoReflexion.Model;

namespace TutoReflexion
{
    /// <summary>
    /// Récupéré de https://www.lamoutarde.fr/la-reflexion-en-csharp-part-1/
    /// </summary>
    class Program
    {

        #region Attributs statiques

        /// <summary>
        /// Flags par défaut à utiliser pour la réflexion
        /// </summary>
        static BindingFlags FLAGS = BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic;

        /// <summary>
        /// Objets de test
        /// </summary>
        static Character sephiroth = new Character("Sephiroth", new Vector2(5000, 3700));
        static Character cloud = new Character("Cloud", new Vector2(200, 50), sephiroth);

        #endregion


        #region Scripts d'exemple

        /// <summary>
        /// Récupération d'une propriété public
        /// </summary>
        static void script1()
        {

            // On récupère la propriété nommée "FirstName" de la classe de cloud (Character)
            PropertyInfo pi = cloud.GetType().GetProperty("FirstName", FLAGS);

            // On récupère la valeur de la propriété
            object value = pi.GetValue(cloud);

            Console.WriteLine("Valeur récupérée : " + value);

            Console.WriteLine($" PDE essais {cloud.FirstName}");
            PropertyInfo pi1 = cloud.GetType().GetProperty("FirstName", FLAGS);
            object value1 = pi1.GetValue(cloud);
            Console.WriteLine($"Valur récuperée: {value1}");
        }

        /// <summary>
        /// Récupération d'un champ private
        /// </summary>
        static void script2()
        {
            // On récupère le champ nommé "firstName" de la classe de cloud (Character)
            FieldInfo fi = cloud.GetType().GetField("firstName", FLAGS);

            // On récupère la valeur de la propriété, et on constate que ça marche même avec des éléments private
            object value = fi.GetValue(cloud);

            Console.WriteLine("Valeur récupérée : " + value);
        }

        /// <summary>
        /// Set d'un élément
        /// </summary>
        static void script3()
        {
            Console.WriteLine("Valeur avant : " + cloud.FirstName);

            // On récupère la propriété nommée "FirstName" de la classe de cloud (Character)
            PropertyInfo pi = cloud.GetType().GetProperty("FirstName", FLAGS);

            // On set la nouvelle valeur
            pi.SetValue(cloud, "Zack");

            Console.WriteLine("Valeur après : " + cloud.FirstName);
        }


        /// <summary>
        /// Set d'un élément encapsulé
        /// </summary>
        static void script4()
        {
            Console.WriteLine("Valeur avant : " + sephiroth.FirstName); // Sephiroth

            // On récupère le chef de cloud
            PropertyInfo pi = cloud.GetType().GetProperty("Chief", FLAGS);
            object cloudChief = pi.GetValue(cloud);

            // On récupère le prénom du chef de cloud et on le change
            PropertyInfo pi2 = cloudChief.GetType().GetProperty("FirstName", FLAGS);
            pi2.SetValue(cloudChief, "Sephira");

            Console.WriteLine("Valeur après : " + sephiroth.FirstName); // Sephira

            /*
            Valeur avant : Sephiroth
            Valeur après : Sephira
            Appuyez sur une touche pour quitter...

             * */
        }

        /// <summary>
        /// Démo du problème avec le type valeur (structure)
        /// </summary>
        static void script5()
        {
            Console.WriteLine("Valeur avant : " + cloud.Position.X + "/" + cloud.Position.Y);

            // On récupère la position de cloud
            PropertyInfo pi = cloud.GetType().GetProperty("Position", FLAGS);
            object posDeCloud = pi.GetValue(cloud);

            // On récupère la valeur X de cette position et on la change
            PropertyInfo pi2 = posDeCloud.GetType().GetProperty("X", FLAGS);
            pi2.SetValue(posDeCloud, 5);

            Console.WriteLine("Valeur après : " + cloud.Position.X + "/" + cloud.Position.Y);
            // Valeur avant : 200 / 50
            // Valeur après : 200 / 50
            // Appuyez sur une touche pour quitter...

        }

        /// <summary>
        /// Démo du problème avec le type valeur
        /// </summary>
        static void script6()
        {
            Console.WriteLine("Valeur avant : " + cloud.Position.X + "/" + cloud.Position.Y);

            // On récupère la position de cloud
            PropertyInfo pi = cloud.GetType().GetProperty("Position", FLAGS);
            object cloudPos = pi.GetValue(cloud);

            // On récupère la valeur X de cette position et on la change
            PropertyInfo pi2 = cloudPos.GetType().GetProperty("X", FLAGS);
            pi2.SetValue(cloudPos, 5);

            // On remet cloudPos sur son père puisqu'il ne s'agit plus de la même instance
            pi.SetValue(cloud, cloudPos);

            Console.WriteLine("Valeur après : " + cloud.Position.X + "/" + cloud.Position.Y);
            /*
               Valeur avant : 200/50
               Valeur après : 5/50

             * */
        }

        // BEGIN test script8
        static void script8()
        {
            Vector2 pos = new Vector2(2, 5);

            myFunction(pos);

            Console.WriteLine(pos.X); // Cette ligne va afficher 2 et non 400
        }

        public static void myFunction(Vector2 ppos)
        {
            ppos.X = 400;
        }

        // END test script8

        #endregion


        static void Main(string[] args)
        {
            //script1();
            //script2(); // cas d'un champ private
            //script3(); // set
            //script4(); // set encapsulé
            //script5(); // set struct impossible
            //script8();
            script6();

            Console.WriteLine("Appuyez sur une touche pour quitter...");
            Console.ReadKey();
        }

    }
}
