using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TutoReflexion.Model
{
    class Character
    {

        // Champs
        private string firstName;
        private Vector2 position;
        private Character chief;

        // Propriétés        
        public string FirstName { get { return firstName; } set { firstName = value; } }
        public Vector2 Position { get { return position; } set { position = value; } }
        public Character Chief { get { return chief; } set { chief = value; } }

        // Constructeur
        public Character(string firstName, Vector2 position, Character chief = null)
        {
            this.firstName = firstName;
            this.position = position;
            this.chief = chief;
        }

    }
}
