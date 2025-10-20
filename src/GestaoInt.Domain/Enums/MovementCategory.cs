using System.ComponentModel;

namespace GestaoInt.Domain.Enums;

public enum MovementCategory
{
    [Description("Movimentações de Categoria de Entrada")]
    SALE = 0,
    CHANGED = 1,
    OTHER_IN = 2,

    [Description("Movimentações de Categoria de Saída")]
    EXPENSE = 3,
    WITHDRAWAL = 4,
    PAYMENT = 5,

}
