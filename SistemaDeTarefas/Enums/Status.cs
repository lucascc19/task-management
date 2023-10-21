using System.ComponentModel;

namespace SistemaDeTarefas.Enums
{
    public enum Status
    {
        [Description("A Fazer")]
        ToDo = 1,
        [Description("Em Andamento")]
        Doing = 2,
        [Description("Concluído")]
        Done = 3
    }
}
