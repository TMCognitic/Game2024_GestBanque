namespace Models
{
    public interface IBanker
    {
        string Numero { get; }
        Personne Titulaire { get; }
        void AppliquerInteret();
    }
}