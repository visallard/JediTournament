﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JediTournamentEntities;

namespace StubDataAccessLayer
{
    public class DalManager
    {
        public List<Jedi> Jedis { get; set; }
        public List<Match> Matchs { get; set; }
        public List<Stade> Stades { get; set; }
        public List<EDefCaracteristique> Caracteristiques { get; set; }
        public List<Utilisateur> utilisateurs { get; set; }

        public DalManager()
        {
            InitJedis();
            InitStades();
            InitCaracteristiques();
            InitMatchs();
            InitUtilisateurs();
        }

        public Utilisateur GetUtilisateurByLogin(string login) {
            try
            {
                return utilisateurs.Where(u => u.Login == login).First();
            }catch(Exception)
            {
                return null;
            }
        }

        private void InitJedis()
        {
            Jedis = new List<Jedi>();
            Jedis.Add(new Jedi(1, "Anakin Skywalker", false));
            Jedis[0].Caracteristiques.Find(c => c.Definition == EDefCaracteristique.Force).Valeur=4;
            Jedis[0].Caracteristiques.Find(c => c.Definition == EDefCaracteristique.Sante).Valeur = 60;
            Jedis.Add(new Jedi(2, "Jawal Thabeet", false));
            Jedis[1].Caracteristiques.Find(c => c.Definition == EDefCaracteristique.Force).Valeur = 3;
            Jedis[1].Caracteristiques.Find(c => c.Definition == EDefCaracteristique.Sante).Valeur = 50;
            Jedis.Add(new Jedi(3, "Darth Vader", true));
            Jedis[2].Caracteristiques.Find(c => c.Definition == EDefCaracteristique.Force).Valeur = 4;
            Jedis[2].Caracteristiques.Find(c => c.Definition == EDefCaracteristique.Sante).Valeur = 30;
            Jedis.Add(new Jedi(4, "Jar Jar Binks", true));
            Jedis[3].Caracteristiques.Find(c => c.Definition == EDefCaracteristique.Force).Valeur = 2;
            Jedis[3].Caracteristiques.Find(c => c.Definition == EDefCaracteristique.Sante).Valeur = 60;
        }

        private void InitStades()
        {
            Stades = new List<Stade>();
            Stades.Add(new Stade(1, 500, "Mustafar"));
            Stades.Add(new Stade(2, 1500, "Tatooine"));
            Stades.Add(new Stade(3, 1000, "Coruscant"));
            Stades.Add(new Stade(4, 2000, "Jakku"));
        }

        private void InitMatchs()
        {
            Matchs = new List<Match>();
            Matchs.Add(new Match(1, Jedis[0], Jedis[0], Jedis[1], EPhaseTournoi.HuitiemeFinale, Stades[0]));
            Matchs.Add(new Match(2, Jedis[2], Jedis[2], Jedis[3], EPhaseTournoi.Finale, Stades[1]));
        }

        private void InitCaracteristiques(){
            Caracteristiques = new List<EDefCaracteristique>();
            Caracteristiques.Add(EDefCaracteristique.Chance);
            Caracteristiques.Add(EDefCaracteristique.Defense);
            Caracteristiques.Add(EDefCaracteristique.Force);
            Caracteristiques.Add(EDefCaracteristique.Sante);
        }

        private void InitUtilisateurs()
        {
            utilisateurs = new List<Utilisateur>();
            utilisateurs.Add(new Utilisateur(1, "login", "password"));
            utilisateurs.Add(new Utilisateur(2, "test", "test"));
        }
    }
}
