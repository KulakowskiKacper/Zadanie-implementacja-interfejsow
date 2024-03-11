using System.ComponentModel;
using System.Data;

namespace ImplementacjaInterfejsow
{
    public class Pracownik
    {

        private string nazwisko;
        public string Nazwisko
        {
            get => nazwisko;
            set => nazwisko = value.Trim();
        }
        private DateTime dataZatrudnienia;
        public DateTime DataZatrudnienia
        {
            get => dataZatrudnienia;
            
            set {
                if (value > DateTime.Now)
                {
                    throw new ArgumentException("Data zatrudnienia nie może być z przyszłości");
                }
                dataZatrudnienia = value;
                }
            
        }
        private double wynagrodzenie;
        public double Wynagrodzenie
        {
            get => wynagrodzenie;
            set 
            {
                if (value < 0)
                {
                    value = 0;
                    
                }
                else
                {
                    wynagrodzenie = value;
                }
            }
        }
        public override string ToString()
        {
            return $"{nazwisko} {dataZatrudnienia:d MMM yyyy} {wynagrodzenie}";
        }

        public int CzasZatrudnienia => (DateTime.Now - dataZatrudnienia).Days / 30;
        public Pracownik(string nazwisko, DateTime dataZatrudnienia, double wynagrodzenie)
        {
            Nazwisko = nazwisko;
            DataZatrudnienia = dataZatrudnienia;
            Wynagrodzenie = wynagrodzenie;
        }
        public Pracownik()
        {
            Nazwisko = "Anonim";
            DataZatrudnienia = DateTime.Now;
            Wynagrodzenie = 0;
        }
    }
}