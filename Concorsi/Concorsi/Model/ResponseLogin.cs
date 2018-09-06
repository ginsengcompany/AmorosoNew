using System;
using System.Collections.Generic;
using System.Text;

namespace Concorsi.Model
{
    public class ResponseLogin
    {
        public string username { get; set; }
        public string nome { get; set; }
        public string cognome { get; set; }
        public string password { get; set; }
        public string attivo { get; set; }
    }
}
