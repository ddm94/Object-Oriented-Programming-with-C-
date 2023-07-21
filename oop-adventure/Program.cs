using OOPAdventure;

Text.LoadLanguage(new English());

Console.WriteLine(Text.Language.ChooseYourName);

var name = Console.ReadLine();

if (name == String.Empty)
{
    name = Text.Language.DefaultName;
}    

var player = new Player(name);

// {0} - Here name will automatically replace the 0 token
Console.WriteLine(Text.Language.Welcome,  player.Name);

var house = new House(player);