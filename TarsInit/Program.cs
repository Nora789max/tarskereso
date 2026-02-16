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
            string conn = "Server=localhost; User ID=root; Password=; Database=";
            var serverVersion = new MariaDbServerVersion(ServerVersion.AutoDetect(conn));

            var options = new DbContextOptionsBuilder<TarskeresoContext>()
                .UseMySql(conn, serverVersion)
                .Options;

            using var db = new TarskeresoContext(options);

        }
    }
}