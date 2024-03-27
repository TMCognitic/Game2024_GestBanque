namespace Models;

public class Epargne : Compte
{
    private DateTime _dernierRetrait;

    public DateTime DernierRetrait
    {
        get
        {
            return _dernierRetrait;
        }

        private set
        {
            _dernierRetrait = value;
        }
    }

    public Epargne(string numero, Personne titulaire) : base(numero, titulaire)
    {
    }

    public Epargne(string numero, Personne titulaire, double solde, DateTime dernierRetrait) 
        : base(numero, titulaire, solde)
    {
        DernierRetrait = dernierRetrait;
    }

    public override void Retrait(double montant)
    {
        double ancienSolde = Solde;
        base.Retrait(montant);
        
        if(Solde != ancienSolde)
        {
            DernierRetrait = DateTime.Now;
        }
    }

    protected override double CalculInteret()
    {
        return Solde * 0.045;
    }
}
