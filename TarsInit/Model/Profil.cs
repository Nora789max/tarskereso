using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TarsInit.Model
{
    public class Profil
    {
        public int Id { get; set; }

        public string? Nev { get; set; }
        public string? Nem { get; set; }          // varchar(1) a DB-ben
        public int? Eletkor { get; set; }
        public string? Varos { get; set; }
        public int? MagassagCm { get; set; }
        public int? TestsulyKg { get; set; }
        public string? Szemszin { get; set; }
        public string? Hajszin { get; set; }
        public int? EvesBevetelHuf { get; set; }
        public string? Vegzettseg { get; set; }
        public string? Foglalkozas { get; set; }
        public string? Dohanyzas { get; set; }
        public string? Alkohol { get; set; }
        public string? Cel { get; set; }
        public string? Csillagjegy { get; set; }
        public int? PrefMinEletkor { get; set; }
        public int? PrefMaxEletkor { get; set; }
        public int? PrefMinMagassagCm { get; set; }
        public int? PrefMaxMagassagCm { get; set; }
        public string? Bio { get; set; }

        //public ICollection<ProfilErdeklodes> ProfilErdeklodes { get; set; } = new List<ProfilErdeklodes>();



        public Profil(string line)
        {
            var c = line.Split(";");

            Nev = NullIfEmpty(c[1]);
            Nem = NullIfEmpty(c[2]);
            Eletkor = ToNullableInt(c[3]);
            Varos = NullIfEmpty(c[4]);
            MagassagCm = ToNullableInt(c[5]);
            TestsulyKg = ToNullableInt(c[6]);
            Szemszin = NullIfEmpty(c[7]);
            Hajszin = NullIfEmpty(c[8]);
            EvesBevetelHuf = ToNullableInt(c[9]);
            Vegzettseg = NullIfEmpty(c[10]);
            Foglalkozas = NullIfEmpty(c[11]);
            Dohanyzas = NullIfEmpty(c[12]);
            Alkohol = NullIfEmpty(c[13]);
            Cel = NullIfEmpty(c[14]);
            Csillagjegy = NullIfEmpty(c[15]);
            PrefMinEletkor = ToNullableInt(c[16]);
            PrefMaxEletkor = ToNullableInt(c[17]);
            PrefMinMagassagCm = ToNullableInt(c[18]);
            PrefMaxMagassagCm = ToNullableInt(c[19]);
            Bio = NullIfEmpty(c[20]);
        }

        public Profil()
        {
        }

        private static string? NullIfEmpty(string s)
            => string.IsNullOrWhiteSpace(s) ? null : s.Trim();

        private static int? ToNullableInt(string s)
            => string.IsNullOrWhiteSpace(s) ? null : int.Parse(s.Trim());

        public override string? ToString()
        {
            return $"{Nev} ({Eletkor}) - {EvesBevetelHuf} Ft";
        }
    }

}
