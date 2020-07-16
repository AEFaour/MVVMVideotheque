using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfAppVideo.Model
{
    public class Info : INotifyPropertyChanged
    {
        private string status;
        public string Status
        {
            get { return status; }
            set
            {
                status = value;
                JaiChange("Status"); // le changement s'opère toujours au niveau du setter
            }
        }

        private void JaiChange(string v)
        {
            if (PropertyChanged != null) // y a t-il des abonnés (souscripteur -- Pat Observer)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(v));
            };
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
