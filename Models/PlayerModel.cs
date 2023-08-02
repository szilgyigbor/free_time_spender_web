namespace FreeTimeSpenderWeb.Models
{
    public class PlayerModel
    {
        public string? Name { get; set; }
        public int PositionX { get; set; }
        public int PositionY { get; set; }
        public int Health { get; set; }
        public bool IsReversed { get; set; }
        public string? Shooter { get; set; }
    }
}
