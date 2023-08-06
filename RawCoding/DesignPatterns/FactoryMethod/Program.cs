namespace FactoryMethod;

public class Program
{
    static void Main(string[] args)
    {
        new NavigationBar();
        new DropdownMenu();
        new AndroidNavigationBar();
        new AndroidDropdownMenu();
    }
}

public abstract class Element
{
    protected abstract Button CreateButton();

    public Element() => CreateButton();
}

public class NavigationBar : Element
{
    protected override Button CreateButton()
    {
        var typeText = "Default Button";
        var button = new Button { Type = typeText };
        Console.WriteLine(typeText);
        return button;
    }
}

public class DropdownMenu : Element
{
    protected override Button CreateButton()
    {
        var typeText = "Default Button";
        var button = new Button { Type = typeText };
        Console.WriteLine(typeText);
        return button;
    }
}

public class AndroidNavigationBar : Element
{
    protected override Button CreateButton()
    {
        var typeText = "Android Button";
        var button = new Button { Type = typeText };
        Console.WriteLine(typeText);
        return button;
    }
}

public class AndroidDropdownMenu : Element
{
    protected override Button CreateButton()
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