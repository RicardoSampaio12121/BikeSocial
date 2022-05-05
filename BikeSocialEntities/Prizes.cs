namespace BikeSocialEntities
{
    public class Prizes
    {
        public int Id { get; set; }
        public string Name { get; set; }
        
        //A corrida associada
        public int raceId { get; set; }
        public Races race { get; set; }
        //Atletas que ganharam o premio.
        public List<Athletes> Athletes { get; set; } // Quem tem este prémio fica nesta lista. Chave estrangeira.
    }
}