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
using LiveCharts;
using LiveCharts.Wpf;
using System.Linq;

namespace Gestion_Compte_App
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<Intervenant> intervenants;
        public SeriesCollection CoutValues { get; set; }
        public MainWindow()
        {
            InitializeComponent();
            intervenants = new List<Intervenant>();
            CoutValues = new SeriesCollection();
            DataContext = this;
        }

        private void AjouterIntervenant_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                using (var context = new AppDbContext())
                {
                    string nom = NomTextBox.Text;
                    string qualificationBase = QualificationBaseTextBox.Text;

                    if (double.TryParse(QualificationInterventionTextBox.Text, out double qualificationIntervention) &&
                        double.TryParse(TarifJournalierTextBox.Text, out double tarifJournalier) &&
                        int.TryParse(JoursHommesTextBox.Text, out int joursHommes))
                    {
                        var intervenant = new Intervenant(nom, qualificationBase, qualificationIntervention, tarifJournalier, joursHommes);
                        context.Intervenants.Add(intervenant);
                        context.SaveChanges();

                        intervenants.Add(intervenant);
                        ResultatTextBlock.Text += $"Intervenant {nom} ajouté et enregistré dans la base de données.\n";
                    }
                    else
                    {
                        MessageBox.Show("Erreur: Veuillez entrer des valeurs numériques valides.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur: {ex.Message}\nDétails: {ex.InnerException?.Message}");
            }

        }

        private void CalculerCoutTotal_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                using (var context = new AppDbContext())
                {
                    // Charge les intervenants depuis la base de données
                    intervenants = context.Intervenants.ToList();

                    var intervention = new Intervention(intervenants);
                    double coutTotal = intervention.AjustementQualificationEuler(nombreIterations: 100, pas: 0.01, seuil: 0.001);

                    ResultatTextBlock.Text += $"Coût total final de l'intervention: {coutTotal}\n";

                    // Ajouter les données au graphique
                    var valeurs = new ChartValues<double>(intervenants.Select(i => i.CalculerCout()));
                    CoutValues.Clear();
                    CoutValues.Add(new LineSeries { Values = valeurs });

                    // Informer LiveCharts que les données ont changé
                    CoutChart.Series.Clear();
                    CoutChart.Series.Add(new LineSeries { Values = valeurs });
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur: {ex.Message}");
            }
        }


    }
}