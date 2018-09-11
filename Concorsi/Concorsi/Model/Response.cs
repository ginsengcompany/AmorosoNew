using System;
using System.Collections.Generic;
using System.Text;

namespace Concorsi.Model
{
    public class Response<E>
    {
        public bool status { get; set; }
        public E message { get; set; }
    }
}
