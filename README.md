Version Desktop du programme de Gestion de Compte Client

- N.B \*: Veuillez installer les packages et bibliothèque suivants pour pouvoir s'assurer du bon fonctionnement du projet :
  -Microsoft.EntityFrameworkCore via la commande :Install-Package Microsoft.EntityFrameworkCore
  -Microsoft.EntityFrameworkCore.Sqlite via la commande : Install-Package Microsoft.EntityFrameworkCore.Sqlite
  -Microsoft.EntityFrameworkCore.Tools via la commande : Install-Package Microsoft.EntityFrameworkCore.Tools
  -LiveCharts.wpf : à rechercher et installer dans l'onglet gérer les packages NuGet

_Veuillez changer le target du fichier intervenant.db de votre propre target dans le fichier Application_Gestion_Compte\Gestion_Compte_App\Models\AppDbContext.cs_

_Par exemple_:
optionsBuilder.UseSqlite("Data Source=D:\\ISPM\\L3 (2023-2024)\\IS\\Projet\\Application_Gestion_Compte\\Gestion_Compte_App\\intervenant.db");
