using System.Collections.Generic;

namespace Gestion_Compte_App.Models
{
    internal class Intervention
    {
        public List<Intervenant> Intervenants { get; set; }

        public Intervention(List<Intervenant> intervenants)
        {
            Intervenants = intervenants;
        }

        public double AjustementQualificationEuler(int nombreIterations, double pas, double seuil)
        {
            double coutTotal = 0;

            foreach (var intervenant in Intervenants)
            {
                double deltaQualification = pas;

                for (int i = 0; i < nombreIterations; i++)
                {
                    intervenant.AjusterQualification(deltaQualification);

                    double coutIntervenant = intervenant.CalculerCout();
                    coutTotal += coutIntervenant;

                    if (Math.Abs(deltaQualification * intervenant.QualificationIntervention) < seuil)
                        break;
                }
            }

            return coutTotal;
        }
    }
}
