namespace Models
{
    public interface IBanker
    {
        string Numero { get; set; }
        Personne Titulaire { get; set; }

        void AppliquerInteret();
    }
}