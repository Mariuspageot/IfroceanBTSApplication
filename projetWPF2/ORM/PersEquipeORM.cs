using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projetWPF2
{
    class PersEquipeORM
    {
        public static void ajouter(PersonneViewModel personne, EquipeViewModel equipe)
        {
            DAOPersEquipe.insertPersEquipe(personne, equipe);
        }
        public static void supprimerPersonne(PersonneViewModel personne)
        {
            DAOPersEquipe.supprimerPersonne(personne);
        }
        public static void supprimerEquipe(EquipeViewModel equipe)
        {
            DAOPersEquipe.supprimerEquipe(equipe);
        }

        public static List<PersonneViewModel> getPersonnes(EquipeViewModel equipe)
        {
            List<PersonneViewModel> lp =
                DAOPersEquipe.listePersEquipes()
                .Where(e => e.idEquipeDAOPersEquipe == equipe.idEquipeProperty)
                .Select(e => PersonneORM.getPersonne(e.idPersonneDAOPersEquipe)).ToList();
            return lp;
        }
    }
}
