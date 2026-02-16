using Microsoft.EntityFrameworkCore;
using System;
using TarsInit.Data;
using TarsInit.Model;


namespace MyApp
{
    public class Program
    {
        static void Main(string[] args)
        {
            string conn = "Server=172.16.16.136; User ID=szoft; Password=alma; Database=tarskereso";
            var serverVersion = new MariaDbServerVersion(ServerVersion.AutoDetect(conn));

            var options = new DbContextOptionsBuilder<TarskeresoContext>()
                .UseMySql(conn, serverVersion)
                .Options;

            using var db = new TarskeresoContext(options);

            if (!db.Erdeklodesek.Any())
            {

                var sorok = File.ReadAllLines("erdeklodesek.txt").Skip(1);
                foreach (var sor in sorok)
                {
                    db.Erdeklodesek.Add(new Erdeklodes(sor));
                }
                db.SaveChanges();
            }
            if (!db.Profilok.Any())
            {

                var sorok = File.ReadAllLines("profilok.txt").Skip(1);
                foreach (var sor in sorok)
                {
                    db.Profilok.Add(new Profil(sor));
                }
                db.SaveChanges();
            }
            if (!db.ProfilErdeklodesek.Any())
            {

                var sorok = File.ReadAllLines("profilerdeklodesek.txt").Skip(1);
                foreach (var sor in sorok)
                {
                    db.ProfilErdeklodesek.Add(new ProfilErdeklodes(sor));
                }
                db.SaveChanges();
            }

            Console.WriteLine("1.feladat");
            foreach (var item in db.Profilok)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("2-3.feladat");

            var q2 = db.Profilok.Where(x => x.Varos.Equals("Budapest")).Select(p=> new {p.Nev, p.Varos, p.Cel});
            foreach (var item in q2)
            { Console.WriteLine(item); }
            //{ Console.WriteLine(item.nev, item.varos, item.cel); }
            Console.WriteLine("4.feladat");
            var q4 = db.Profilok.Where(z => z.Eletkor >= 25 && z.Eletkor <= 35 && z.Cel.Equals("komoly kapcsolat"));
            foreach (var item in q4)
            { Console.WriteLine(item); }

            Console.WriteLine("5.feladat");
            foreach (var item in db.Profilok.OrderBy(x => x.Nev))
            { Console.WriteLine(item); }

            Console.WriteLine("6.feladat");
            var q6 = db.Profilok.OrderByDescending(x => x.MagassagCm).Take(10);
            foreach (var item in q6)
            { Console.WriteLine(item+" - " + item.MagassagCm + " cm"); }

            Console.WriteLine("7.feladat");
            var q71 = db.Profilok.Select(x => x.Varos).Distinct();
            var q72 = db.Profilok.Select(x => x.Varos);
            Console.WriteLine(q71.Count());
            Console.WriteLine(q72.Count());

            Console.WriteLine("8.feladat");

        }
    }
}