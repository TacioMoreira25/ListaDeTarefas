namespace ListaDeTarefas.Models
{
    public record class Tarefa
    { 
        public int Id { get; set; }  
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public DateOnly Prazo { get; set; }
        public bool Concluido { get; set; }

        public Tarefa() { }

        public Tarefa(int id, string titulo, string descricao, DateOnly prazo, bool concluido)
        {
            Id = id;
            Titulo = titulo;
            Descricao = descricao;
            Prazo = prazo;
            Concluido = concluido;
        }
    }
}