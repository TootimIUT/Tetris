using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projet_tetris.view
{
    public class CJoueurs
    {
        public int Identifiant { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public List<CScores> scores { get; set; }
        public string Password { get; set; }
        public string Mail { get; set; }

    }
}
