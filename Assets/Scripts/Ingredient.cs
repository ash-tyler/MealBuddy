using static Unit;

public class Ingredient
{
    public string Name { get; set; } = "Name";
    public string Brand { get; set; } = "Brand";
    public Measurement Measure { get; set; } = new Measurement(900, solidTemplate[0]);

    public enum State { NULL = 0, SOLID, LIQUID }
}