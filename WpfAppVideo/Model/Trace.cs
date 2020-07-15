using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfAppVideo.Model
{
    public class Trace
    {
        [Key]
        public int Id { get; set; }
        //En fonction de la granularité des logs on
        // peut créer plusieurs champs
        // Sin non on peut créer un seul champs Info pour stocker les données
        public int MyProperty { get; set; }
    }
}
