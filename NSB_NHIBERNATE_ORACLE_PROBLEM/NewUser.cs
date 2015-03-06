using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NServiceBus;

namespace NSB_NHIBERNATE_ORACLE_PROBLEM
{
    public class NewUser : ICommand
    {
        public string Name { get; set; }
    }
}
