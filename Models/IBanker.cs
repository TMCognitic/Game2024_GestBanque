namespace Models
{
    public interface IBanker
    {
        string Numero { get; }
        Personne Titulaire { get; }
        double LigneDeCredit { get; set; }

        void AppliquerInteret();
    }
}