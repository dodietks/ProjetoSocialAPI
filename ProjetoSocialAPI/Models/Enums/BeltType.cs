using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoSocialAPI.Models
{
    public enum BeltType
    {
        [Description("Faixa branca.")]
        WHITE = 10,
        [Description("Faixa cinza com branco")]
        GRAY_WHITE = 20,
        [Description("Faixa cinza")]
        GRAY = 21, 
        [Description("Faixa cinza com preto")]
        GRAY_BLACK = 22,
        [Description("Faixa amarela com branco")]
        YELLOW_WHITE = 30,
        [Description("Faixa amarela")]
        YELLOW = 31,
        [Description("Faixa amarela com preto")]
        YELLOW_BLACK = 32,
        [Description("Faixa laranja com branco")]
        ORANGE_WHITE = 40,
        [Description("Faixa laranja")]
        ORANGE = 41,
        [Description("Faixa laranja com preto")]
        ORANGE_BLACK = 42,
        [Description("Faixa verde com branco")]
        GREEN_WHITE = 50,
        [Description("Faixa verde")]
        GREEN = 51,
        [Description("Faixa verde com preto")]
        GREEN_BLACK = 52,
        [Description("Faixa azul")]
        BLUE = 60,
        [Description("Faixa roxa")]
        PURPLE = 70,
        [Description("Faixa marrom")]
        BROWN = 80,
        [Description("Faixa preta")]
        BLACK = 90,
        [Description("Faixa vermelha e preta")]
        RED_BLACK = 100,
        [Description("Faixa vermelha e branca")]
        RED_WHITE = 101,
        [Description("Faixa vermelha")]
        RED = 102,
    }
}
