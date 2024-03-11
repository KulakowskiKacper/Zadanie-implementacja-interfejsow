using System.ComponentModel;
using System.Data;

namespace ImplementacjaInterfejsow
{
    public class Pracownik : IEquatable<Pracownik>
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
        public override string ToString() => $"{nazwisko} {dataZatrudnienia:d MMM yyyy} ({CzasZatrudnienia}) {wynagrodzenie} PLN";

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

        #region implementacja IEquatable<Pracownik>

        public bool Equals(Pracownik other)
        {
            if (other is null) return false;
            if (Object.ReferenceEquals(this, other))return true;

            return nazwisko == other.nazwisko && dataZatrudnienia == other.dataZatrudnienia && wynagrodzenie == other.wynagrodzenie;
        }

        public override bool Equals(object obj)
        {
            if (obj is Pracownik) return Equals((Pracownik) obj);
            else return false;
        }

        public override int GetHashCode() => (Nazwisko, DataZatrudnienia, Wynagrodzenie).GetHashCode();

        public static bool Equals(Pracownik p1, Pracownik p2)
        {
            if (p1 is null & p2 is null) return true;
            if (p1 is null) return false;
            return p1.Equals(p2);
        }

        public static bool operator ==(Pracownik p1, Pracownik p2) => Equals(p1, p2);
        public static bool operator !=(Pracownik p1, Pracownik p2) => !Equals(p1, p2);
        
        #endregion implementacja IEquatable<Pracownik>
    }
}