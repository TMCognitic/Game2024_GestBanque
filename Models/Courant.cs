namespace Models;

public class Courant : Compte
{
    private double _ligneDeCredit;

    public double LigneDeCredit
    {
        get
        {
            return _ligneDeCredit;
        }

        set
        {
            if(value < 0)
            {
                Console.WriteLine("La ligne de crédit est strictement positive..."); // => Erreur : Exception
                return;
            }
            _ligneDeCredit = value;
        }
    }

    public override void Retrait(double montant)
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
}
