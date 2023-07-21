Console.WriteLine("Hello, what is your name?");

var name = Console.ReadLine();

if (name == String.Empty)
{
    name = "No Name";
}    

// {0} - Here name will automatically replace the 0 token
Console.WriteLine("Welcome {0} to your OOP Adventure!",  name);