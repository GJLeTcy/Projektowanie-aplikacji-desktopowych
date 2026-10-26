using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elektro_Bud.Models
{
    public class Produkt
    {
        public int Id { get; set; }
        public string Nazwa { get; set; }
        public string Kategoria { get; set; }
        public int Ilosc { get; set; }
        public double Cena { get; set; }
        public string Dostawca { get; set; }

        public Produkt()
        {
        }

        public Produkt(int id, string nazwa, string kategoria, int ilosc, double cena, string dostawca)
        {
            this.Id = id;
            this.Nazwa = nazwa;
            this.Kategoria = kategoria;
            this.Ilosc = ilosc;
            this.Cena = cena;
            this.Dostawca = dostawca;
        }
    }
}
