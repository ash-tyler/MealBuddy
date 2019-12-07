using UnityEngine;
using static Ingredient;
using static Unit;

public class Measurement
{
    public double Amount { get; private set; } = 0;                 //The amount of units
    public Unit Unit { get; private set; } = new Solid.Gram();      //The unit (e.g. grams, mililitres, etc) of the item
    public State State { get => Unit.GetState(); }                  //The state (solid or liquid) of the item

    public bool IsSolid { get => Unit.GetState() == State.SOLID; }
    public bool IsLiquid { get => Unit.GetState() == State.LIQUID; }

    public Measurement(double amount, Unit unit)
    {
        Amount = amount;
        Unit = unit;
    }

    //Converts the amount of this to a new unit
    public void ConvertUnitTo(Unit newUnit)
    {
        Debug.Log("Before: " + GetShortMeasurement());

        Amount = Unit.Convert(newUnit, Amount);
        Unit = newUnit;

        Debug.Log("After: " + GetShortMeasurement());
    }

    //Returns 
    public Measurement GetConvertedMeasurement(Unit newUnit) => new Measurement(Unit.Convert(newUnit, Amount), newUnit);

    //Returns the amount and unit type abbreviation as a string (e.g. 500g)
    public string GetShortMeasurement()
    {
        return Amount.ToString("n2") + Unit.GetAbbreviation();
    }

    //Returns the amount and unit type name as a string (e.g. 500 gram)
    public string GetLongMeasurement()
    {
        return Amount.ToString("n2") + " " + Unit.GetName();
    }
}