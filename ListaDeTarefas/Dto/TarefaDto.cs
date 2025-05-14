using Newtonsoft.Json;

namespace ListaDeTarefas.Dto;

public class TarefaDto
{
    [JsonIgnore]
    public int Id { get; set; }
    public string Titulo { get; set; }
    public string Descricao { get; set; }
    public DateOnly Prazo { get; set; }
    public bool Concluido { get; set; }
}