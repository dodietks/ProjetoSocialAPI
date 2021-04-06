using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoSocialAPI.Models.Enums
{
    public enum Genders
    {
        [Description("Masculino")]
        MALE = 10,
        [Description("Feminino")]
        FEMALE = 20,
    }
}
