namespace BikeSocialEntities
{
    public class Prizes
    {
        public int Id { get; set; }
        public string Name { get; set; }
        
        public List<Athletes> Athletes { get; set; } // Quem tem este prémio fica nesta lista. Chave estrangeira.
    }
}