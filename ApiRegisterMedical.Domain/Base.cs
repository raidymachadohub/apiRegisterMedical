using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace ApiRegisterMedical.Domain
{
    public class Base
    {

        public string guid { get; set; }

        public Base()
        {
            this.guid = Guid.NewGuid().ToString();
        }
    }
}
