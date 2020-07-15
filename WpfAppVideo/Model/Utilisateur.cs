using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfAppVideo.Model
{
    public class Utilisateur
    {
        [Key]

        public int Id { get; set; }
        public string Logname { get; set; }
        public string Passwd { get; set; }
        public string Nom { get; set; }

        List<Role> Roles { get; set; }
    }
}
