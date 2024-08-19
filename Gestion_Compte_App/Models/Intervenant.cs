using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion_Compte_App.Models
{
    internal class Intervenant
    {
        [Key]
        public int Id { get; set; }
        public string Nom { get; set; }
        public string QualificationBase { get; set; }
        public double QualificationIntervention { get; set; }
        public double TarifJournalier { get; set; }
        public int JoursHommes { get; set; }

        public Intervenant() { }
        public Intervenant(string nom, string qualificationBase, double qualificationIntervention, double tarifJournalier, int joursHommes)
        {
            Nom = nom;
            QualificationBase = qualificationBase;
            QualificationIntervention = qualificationIntervention;
            TarifJournalier = tarifJournalier;
            JoursHommes = joursHommes;
        }

        public double CalculerCout()
        {
            return TarifJournalier * JoursHommes;
        }

        public void AjusterQualification(double deltaQualification)
        {
            QualificationIntervention += deltaQualification * F(QualificationIntervention);
        }

        private double F(double qualification)
        {
            return 1.0;  // Simple fonction linéaire, peut être adaptée selon vos besoins.
        }
    }
}
