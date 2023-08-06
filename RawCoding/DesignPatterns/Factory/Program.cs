namespace Factory;

public class Program
{
    static void Main(string[] args)
    {
        new NavigationBar();
        new DropdownMenu();
    }
}

public class NavigationBar
{
    public NavigationBar() => ButtonFactory.CreateButton();
}

public class DropdownMenu
{
    public DropdownMenu() => ButtonFactory.CreateButton();
}

public class ButtonFactory
{
    public static Button CreateButton()
    {
        var typeText = "Default Button";
        var button = new Button { Type = typeText };
        Console.WriteLine(typeText);
        return button;
    }
}

public class Button
{
    public string Type { get; set; }
}