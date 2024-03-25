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

        set
        {
            _dernierRetrait = value;
        }
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
}
