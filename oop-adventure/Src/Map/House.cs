
namespace OOPAdventure
{
    public partial class House
    {
        public Player Player { get; }   

        // readonly = automatically set the value of the field when compiling and can not be changed at runtime.
        private readonly Random _rnd = new(1234);

        // This way, since the Player properties does not have a setter
        // and the Player is set to the argument value that is passed inside
        // this constructor, no other class can change the reference to the player inside of the House.
        public House(Player player)
        {
            Player = player;
        }
    }
}
