using System.Windows;
using OxyPlot;
using OxyPlot.Series;

namespace YourNamespace
{
    public partial class EulerPlotWindow : Window
    {
        public EulerPlotWindow()
        {
            InitializeComponent();

            // Conditions initiales
            double x0 = 0;
            double y0 = 1;

            // Pas de l'intervalle
            double h = 0.1;

            // Nombre de pas
            int n = 10;

            // Appel de la méthode d'Euler
            var results = EulerMethod(x0, y0, h, n);

            // Création du modèle de tracé
            var plotModel = new PlotModel { Title = "Méthode d'Euler" };

            // Création de la série de points
            var series = new LineSeries
            {
                Title = "Approximation",
                MarkerType = MarkerType.Circle,
                MarkerSize = 3,
                MarkerStroke = OxyColors.White
            };

            // Ajout des points à la série
            foreach (var point in results)
            {
                series.Points.Add(new DataPoint(point.X, point.Y));
            }

            plotModel.Series.Add(series);

            // Assignation du modèle au PlotView
            PlotView.Model = plotModel;
        }

        // Méthode qui représente l'équation différentielle dy/dx = f(x, y)
        static double Function(double x, double y)
        {
            // Exemple: dy/dx = x + y
            return x + y;
        }

        // Implémentation de la méthode d'Euler
        static (double X, double Y)[] EulerMethod(double x0, double y0, double h, int n)
        {
            double x = x0;
            double y = y0;

            // Liste pour stocker les résultats
            var results = new (double X, double Y)[n + 1];
            results[0] = (x, y);

            for (int i = 1; i <= n; i++)
            {
                y = y + h * Function(x, y);  // y(i+1) = y(i) + h * f(x, y)
                x = x + h;  // x(i+1) = x(i) + h
                results[i] = (x, y);
            }

            return results;
        }
    }
}
