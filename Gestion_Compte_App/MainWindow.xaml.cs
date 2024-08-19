using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Gestion_Compte_App.Models;

namespace Gestion_Compte_App
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<Intervenant> intervenants;
        public MainWindow()
        {
            InitializeComponent();
            intervenants = new List<Intervenant>();
        }
        private void AjouterIntervenant_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string nom = NomTextBox.Text;
                string qualificationBase = QualificationBaseTextBox.Text;
                double qualificationIntervention = double.Parse(QualificationInterventionTextBox.Text);
                double tarifJournalier = double.Parse(TarifJournalierTextBox.Text);
                int joursHommes = int.Parse(JoursHommesTextBox.Text);

                var intervenant = new Intervenant(nom, qualificationBase, qualificationIntervention, tarifJournalier, joursHommes);
                intervenants.Add(intervenant);

                ResultatTextBlock.Text += $"Intervenant {nom} ajouté.\n";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur: {ex.Message}");
            }
        }

        private void CalculerCoutTotal_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var intervention = new Intervention(intervenants);
                double coutTotal = intervention.AjustementQualificationEuler(nombreIterations: 100, pas: 0.01, seuil: 0.001);

                ResultatTextBlock.Text += $"Coût total final de l'intervention: {coutTotal}\n";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur: {ex.Message}");
            }
        }
    }
}