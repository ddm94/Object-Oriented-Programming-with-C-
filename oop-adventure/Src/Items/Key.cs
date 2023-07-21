
namespace OOPAdventure
{
    public  class Key : Item
    {
        private readonly House _house;

        public Key(House house)
        {
            _house = house;

            // This ensure that the player is able to pick the key up
            // and that it disappears from the player inventory after
            // it has been used.
            CanTake = true;
            SingleUse = true;
        }

        public override string Name { get; set; } = Text.Language.Key;

        public override void Use(string source)
        {
            _house.CurrentRoom.Use(Text.Language.Key, Name);
        }
    }
}
