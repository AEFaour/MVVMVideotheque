namespace WpfAppVideo.Model
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class EF_TP_MVVM : DbContext
    {
        // Votre contexte a été configuré pour utiliser une chaîne de connexion « EF_TP_MVVM » du fichier 
        // de configuration de votre application (App.config ou Web.config). Par défaut, cette chaîne de connexion cible 
        // la base de données « WpfAppVideo.Model.EF_TP_MVVM » sur votre instance LocalDb. 
        // 
        // Pour cibler une autre base de données et/ou un autre fournisseur de base de données, modifiez 
        // la chaîne de connexion « EF_TP_MVVM » dans le fichier de configuration de l'application.
        public EF_TP_MVVM()
            : base("name=EF_TP_MVVM")
        {
        }

        // Ajoutez un DbSet pour chaque type d'entité à inclure dans votre modèle. Pour plus d'informations 
        // sur la configuration et l'utilisation du modèle Code First, consultez http://go.microsoft.com/fwlink/?LinkId=390109.

        public virtual DbSet<Utilisateur> utilisateurs { get; set; }
        public virtual DbSet<Role> roles { get; set; }
        public virtual DbSet<Trace> traces { get; set; }
    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}