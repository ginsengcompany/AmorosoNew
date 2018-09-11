using System;
using System.Collections.Generic;
using System.Text;

namespace Concorsi.Model
{
    public class DatiUtenteLogin
    {
        public string username { get; set; }
        public string nome { get; set; }
        public string cognome { get; set; }
        public string password { get; set; }
        public string attivo { get; set; }
    }

    public class ResponseLogin
    {
        public bool status { get; set; }
        public DatiUtenteLogin message { get; set; }
    }

    public class ResponseLogout
    {
        public bool status { get; set; }
        public Object message { get; set; }
    }
}
