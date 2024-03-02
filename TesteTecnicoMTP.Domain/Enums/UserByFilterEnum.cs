using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TesteTecnicoMTP.Domain.Enums
{
    public enum UserByFilterEnum : int
    {
        [Description("Name")]
        Name = 1,

        [Description("Email")]
        Email = 2,

        [Description("CPF")]
        CPFCNPJ = 3,

        [Description("Role")]
        Role = 4,

        [Description("Active")]
        Active = 5,

        [Description("Inactive")]
        Inactive = 6,

        [Description("Incomplete")]
        Incomplete = 7,



    }
}
