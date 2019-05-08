using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TutoReflexion.Model
{
    struct Vector2
    {

        // Champs
        private float x, y;

        // Propriétés
        public float X { get { return x; } set { x = value; } }
        public float Y { get { return y; } set { y = value; } }

        // Constructeur
        public Vector2(float x, float y)
        {
            this.x = x;
            this.y = y;
        }

    }
}
