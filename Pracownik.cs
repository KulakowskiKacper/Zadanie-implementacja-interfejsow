using System.ComponentModel;
using System.Data;

namespace ImplementacjaInterfejsow
{
    public class Pracownik
    {

        private string nazwisko;
        public string Nazwisko
        {
            get { return nazwisko; }
            set 
            { nazwisko = value.Trim(); }
        }
        private DateTime dataZatrudnienia;
        public DateTime DataZatrudnienia
        {
            get { return dataZatrudnienia; }
            set 
            {
                if (value > DateTime.Now)
                {
                    throw new DataException("Data zatrudnienia nie może być z przyszłości");
                }
                 dataZatrudnienia = value;
            }
        }
        private double wynagrodzenie;
        public double Wynagrodzenie
        {
            get { return wynagrodzenie; }
            set 
            {
                if (value < 0)
                {
                    value = 0;
                    
                }
                else{
                    wynagrodzenie = value;
                    }
            }
        }
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
        public override string ToString()
        {
            return $"{Nazwisko} {DataZatrudnienia} {Wynagrodzenie}";
        }
    }
}