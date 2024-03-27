using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Banque
    {
        private Dictionary<string, Compte> _comptes;

        public Banque(string nom)
        {
            _comptes = new Dictionary<string, Compte>();
            Nom = nom;
        }

        public string Nom { get; init; }

        public Compte? this[string numero]
        {
            get
            {
                if(!_comptes.ContainsKey(numero))
                    return null;

                return _comptes[numero];
            }
        }

        public void Ajouter(Compte compte)
        {
            _comptes.Add(compte.Numero, compte);
        }

        public void Supprimer(string numero)
        {
            if (!_comptes.ContainsKey(numero))
                return;

            _comptes.Remove(numero);
        }

        public double AvoirDesComptes(Personne titulaire)
        {
            double total = 0D;

            //foreach(KeyValuePair<string, Courant> kvp in _comptes)
            //{
            //    if(kvp.Value.Titulaire == titulaire)
            //    {
            //        total += kvp.Value;
            //    }
            //}

            foreach (Compte compte in _comptes.Values)
            {
                if (compte.Titulaire == titulaire)
                {
                    total += compte;
                }
            }

            return total;
        }
    }
}
