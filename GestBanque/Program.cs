using Models;
using Models.Autre;

namespace GestBanque;

class Program
{
    static void Main(string[] args)
    {
        #region Autre Celsius Vs Fahrenheit
        Celsius celsius = new Celsius() { Temperature = 30 };
        Fahrenheit fahrenheit = celsius; // Utilisation de la surcharge d'opérateur de conversion implicte
        Console.WriteLine($"{celsius.Temperature} °c = {fahrenheit.Temperature} °f");
        celsius = (Celsius)fahrenheit; // Utilisation de la surcharge d'opérateur de conversion explicite
        Console.WriteLine($"{fahrenheit.Temperature} °f = {celsius.Temperature} °c");
        #endregion



        Banque banque = new Banque("MyFavouriteBank");

        Personne doeJohn = new Personne("Doe", "John", new DateTime(1970, 1, 1));
        Compte courant = new Courant("0001", 500, doeJohn);
        Compte epargne = new Epargne("0002", doeJohn);

        banque.Ajouter(courant);
        banque.Ajouter(epargne);

        try
        {
            try
            {
                banque["0001"]?.Depot(-100);
                Console.WriteLine($"Depot de -100 sur le compte '0001' : {banque["0001"]?.Solde}");
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine(ex.Message);
            }

            banque["0001"]?.Depot(100);
            Console.WriteLine($"Depot de 100 sur le compte '0001' : {banque["0001"]?.Solde}");

            try
            {
                banque["0001"]?.Retrait(-100);
                Console.WriteLine($"Retrait de -100 sur le compte '0001' : {banque["0001"]?.Solde}");
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine(ex.Message);
            }

            banque["0001"]?.Retrait(200);
            Console.WriteLine($"Retrait de 200 sur le compte '0001' : {banque["0001"]?.Solde}");

            try
            {
                banque["0001"]?.Retrait(600);
                Console.WriteLine($"Retrait de 600 sur le compte '0001' : {banque["0001"]?.Solde}");
            }
            catch (SoldeInsuffisantException ex)
            {
                Console.WriteLine(ex.Message);
            }
                
            banque["0002"]?.Depot(300);
            Console.WriteLine($"Depot de 300 sur le compte '0002' : {banque["0002"]?.Solde}");
            banque["0002"]?.Retrait(100);
            Console.WriteLine($"Retrait de 100 sur le compte '0002' : {banque["0002"]?.Solde}");

            if (banque["0002"] is Epargne e)
            {
                Console.WriteLine($"Date de dernier retrait : {e.DernierRetrait}");
            }

            banque["0002"]?.AppliquerInteret();

            Console.WriteLine($"Avoir des comptes de Mr {doeJohn.Nom} {doeJohn.Prenom} : {banque.AvoirDesComptes(doeJohn)}");

            banque.Supprimer("0001");
            banque.Supprimer("0002");

            Console.WriteLine(banque["0001"] is null);
            Console.WriteLine(banque["0002"] is null);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
        }
    }
}