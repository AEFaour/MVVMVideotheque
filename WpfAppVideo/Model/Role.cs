using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfAppVideo.Model
{
    public class Role
    {
        [Key]
        public int Id { get; set; }
        public string Nom { get; set; }
        public string Descriptif { get; set; }

        // Relation Many to Many avec les Utilisateurs
        List<Utilisateur> utilisateurs { get; set; }
    }
}
