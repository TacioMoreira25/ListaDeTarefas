namespace ListaDeTarefas.Models
{
    public record class Tarefa
    { 
        public int Id { get; set; }  
        public string Titulo { get; set; }
        public DateOnly Prazo { get; set; }
        public bool Concluido { get; set; }

        public Tarefa() { }

        public Tarefa(int id, string titulo, DateOnly prazo, bool concluido)
        {
            Id = id;
            Titulo = titulo;
            Prazo = prazo;
            Concluido = concluido;
        }
    }
}