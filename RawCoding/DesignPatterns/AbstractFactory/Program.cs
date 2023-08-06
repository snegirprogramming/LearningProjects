namespace AbstractFactory;

public class Program
{
    static void Main(string[] args)
    {
        new NavigationBar(new Apple());
        new DropdownMenu(new Android());
    }
}

public class NavigationBar
{
    public NavigationBar(IUIFactory factory) => factory.CreateButton();
}

public class DropdownMenu
{
    public DropdownMenu(IUIFactory factory) => factory.CreateButton();
}

public interface IUIFactory
{
    public Button CreateButton();
}

public class Apple : IUIFactory 
{
    public Button CreateButton()
    {
        var typeText = "Apple Button";
        var button = new Button { Type = typeText };
        Console.WriteLine(typeText);
        return button;
    }
}

public class Android : IUIFactory
{
    public Button CreateButton()
    {
        var typeText = "Android Button";
        var button = new Button { Type = typeText };
        Console.WriteLine(typeText);
        return button;
    }
}

public class Button
{
    public string Type { get; set; }
}