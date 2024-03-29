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

            private set
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

            private set
            {
                _titulaire = value;
            }
        }

        protected Compte(string numero, Personne titulaire)
        {
            Numero = numero;
            Titulaire = titulaire;
        }

        protected Compte(string numero, Personne titulaire, double solde) : this(numero, titulaire)
        {
            Solde = solde;
        }

        public void Depot(double montant)
        {
            if (montant <= 0)
            {
                throw new ArgumentOutOfRangeException("Dépot d'un montant négatif impossible");                
            }

            Solde += montant;
        }

        public virtual void Retrait(double montant)
        {
            Retrait(montant, 0D);
        }

        protected void Retrait(double montant, double ligneDeCredit)
        {
            if (montant <= 0)
            {
                throw new ArgumentOutOfRangeException("Retrait d'un montant négatif impossible");
            }

            if (Solde - montant < -ligneDeCredit)
            {
                throw new SoldeInsuffisantException("Le solde est insuffisant!");
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