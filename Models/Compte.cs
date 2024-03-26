namespace Models
{
    public abstract class Compte : ICustomer, IBanker
    {
        public static double operator +(double montant, Compte compte)
        {
            return (montant < 0 ? 0 : montant) + (compte.Solde < 0 ? 0 : compte.Solde);
        }

        private Personne _titulaire;
        private string _numero;
        private double _solde;

        public string Numero
        {
            get
            {
                return _numero;
            }

            set
            {
                _numero = value;
            }
        }

        public double Solde
        {
            get
            {
                return _solde;
            }

            private set
            {
                _solde = value;
            }
        }

        public Personne Titulaire
        {
            get
            {
                return _titulaire;
            }

            set
            {
                _titulaire = value;
            }
        }

        public virtual double LigneDeCredit
        {
            get
            {
                return 0D;
            }
            set
            {
                Console.WriteLine("Erreur, on ne peut pas modifier la ligne de crédit d'un compte");
                return;
            }
        }

        public void Depot(double montant)
        {
            if (montant <= 0)
            {
                Console.WriteLine("Dépot d'un montant négatif impossible"); // => Erreur : Exception
                return;
            }

            Solde += montant;
        }

        public virtual void Retrait(double montant)
        {
            if (montant <= 0)
            {
                Console.WriteLine("Retrait d'un montant négatif impossible"); // => Erreur : Exception
                return;
            }

            if (Solde - montant < -LigneDeCredit)
            {
                Console.WriteLine("Solde insuffisant"); // => Erreur : Exception
                return;
            }

            Solde -= montant;
        }

        protected abstract double CalculInteret();

        public void AppliquerInteret()
        {
            Solde += CalculInteret();
        }
    }
}