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
    }
}