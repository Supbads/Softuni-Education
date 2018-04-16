namespace Game
{
    public class Player
    {
        public string Name { get; private set; }

        public int Points { get; private set; }

        public Player(string name, int points)
        {
            this.Name = name;
            this.Points = points;
        }
    }
}
