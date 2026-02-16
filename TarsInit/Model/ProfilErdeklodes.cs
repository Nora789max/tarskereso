using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TarsInit.Model
{
    public class ProfilErdeklodes
    {
        public ProfilErdeklodes()
        {
        }

        public ProfilErdeklodes(string line)
        {
            var adatok = line.Split(";");
            ProfilId=Convert.ToInt32(adatok[1]);
            ErdeklodesId=Convert.ToInt32(adatok[2]);
            Intenzitas=Convert.ToInt32(adatok[3]);

        }

        public int Id { get; set; }
        public int ProfilId { get; set; }
        public int ErdeklodesId { get; set; }
        public int Intenzitas {  get; set; }
        public Profil? Profil { get; set; }
        public Erdeklodes? Erdeklodes { get; set; }
    }
}
