namespace BuilderWrong;

public class Program
{
    static void Main(string[] args)
    {
        new CarBuilder()
            .SetMake("lada")
            .SetColour("red")
            .SetManifactureDate("01/01/1980")
            .Build();
    }
}

public class Car
{
    public string Make { get; set; }
    public string Colour { get; set; }
    public string ManifacturerDate { get; set; }
}

public class CarBuilder
{
    private Car _car = new Car();

    public CarBuilder SetMake(string make)
    {
        _car.Make = make;
        return this;
    }

    public CarBuilder SetColour(string colour) 
    {
        _car.Colour = colour;
        return this;
    }

    public CarBuilder SetManifactureDate(string date)
    {
        _car.ManifacturerDate = date;
        return this;
    }

    public Car Build() => _car;
}