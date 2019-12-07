using System.Collections.Generic;
using static Ingredient;
using static Unit.Liquid;
using static Unit.Solid;

public class Unit
{
    private const double METRIC = 1000f;

    public virtual double Convert(Unit toUnit, double amount)   { return 0; }
    public virtual double Convert(Solid toUnit, double amount)  { return toUnit.ConvertFrom(this, amount); }
    public virtual double Convert(Liquid toUnit, double amount) { return toUnit.ConvertFrom(this, amount); }

    public virtual double ConvertFrom(Unit fromUnit, double amount) { return 0; }
    public virtual double ConvertFrom(Solid fromUnit, double amount) { return fromUnit.ConvertFrom(this, amount); }
    public virtual double ConvertFrom(Liquid fromUnit, double amount) { return fromUnit.ConvertFrom(this, amount); }

    public virtual string GetName()         { return "NULL"; }
    public virtual string GetAbbreviation() { return "NULL"; }
    public virtual State GetState()         { return State.NULL; }


    public static Dictionary<int, Solid> solidTemplate = new Dictionary<int, Solid>()
    { { 0, new Gram() }, { 1, new Ounce() } };

    public static Dictionary<int, Liquid> liquidTemplate = new Dictionary<int, Liquid>()
    { { 0, new Millilitre() }, { 1, new FlozImperial() }, { 2, new FlozUS() } };


    public class Solid : Unit
    {
        private const double G_OZ = 28.35f, G_LB = 453.592f, KG_OZ = 35.274f, KG_LB = 2.205f, OZ_LB = 16f;


        public override double Convert(Unit toUnit, double amount) { return toUnit.ConvertFrom(this, amount); }
        public override double ConvertFrom(Unit fromUnit, double amount) { return fromUnit.Convert(this, amount); }

        public virtual double ConvertFrom(Gram fromUnit, double amount)             { return 0; }
        public virtual double ConvertFrom(Kilogram fromUnit, double amount)         { return 0; }
        public virtual double ConvertFrom(Ounce fromUnit, double amount)            { return 0; }
        public virtual double ConvertFrom(Pound fromUnit, double amount)            { return 0; }

        public override State GetState() { return State.SOLID; }


        public class Gram : Solid
        {
            public override double Convert(Solid toUnit, double amount)             { return toUnit.ConvertFrom(this, amount); }
            public override double ConvertFrom(Solid fromUnit, double amount)       { return fromUnit.Convert(this, amount); }

            #region Convert From
            public override double ConvertFrom(Gram fromUnit, double amount)        { return amount; }
            public override double ConvertFrom(Kilogram fromUnit, double amount)    { return amount * METRIC; }
            public override double ConvertFrom(Ounce fromUnit, double amount)       { return amount * G_OZ; }
            public override double ConvertFrom(Pound fromUnit, double amount)       { return amount * G_LB; }
            #endregion

            public override string GetName() { return "gram"; }
            public override string GetAbbreviation() { return "g"; }
        }

        public class Kilogram : Solid
        {
            public override double Convert(Solid toUnit, double amount) { return toUnit.ConvertFrom(this, amount); }
            public override double ConvertFrom(Solid fromUnit, double amount) { return fromUnit.Convert(this, amount); }

            #region Convert From
            public override double ConvertFrom(Gram fromUnit, double amount)        { return amount / METRIC; }
            public override double ConvertFrom(Kilogram fromUnit, double amount)    { return amount; }
            public override double ConvertFrom(Ounce fromUnit, double amount)       { return amount / KG_OZ; }
            public override double ConvertFrom(Pound fromUnit, double amount)       { return amount / KG_LB; }
            #endregion

            public override string GetName() { return "kilogram"; }
            public override string GetAbbreviation() { return "kg"; }
        }

        public class Ounce : Solid
        {
            public override double Convert(Solid toUnit, double amount) { return toUnit.ConvertFrom(this, amount); }
            public override double ConvertFrom(Solid fromUnit, double amount) { return fromUnit.Convert(this, amount); }

            #region Convert From
            public override double ConvertFrom(Gram fromUnit, double amount)        { return amount / G_OZ; }
            public override double ConvertFrom(Kilogram fromUnit, double amount)    { return amount * KG_OZ; }
            public override double ConvertFrom(Ounce fromUnit, double amount)       { return amount; }
            public override double ConvertFrom(Pound fromUnit, double amount)       { return amount * OZ_LB; }
            #endregion

            public override string GetName() { return "ounce"; }
            public override string GetAbbreviation() { return "oz"; }
        }

        public class Pound : Solid
        {
            public override double Convert(Solid toUnit, double amount) { return toUnit.ConvertFrom(this, amount); }
            public override double ConvertFrom(Solid fromUnit, double amount) { return fromUnit.Convert(this, amount); }

            #region Convert From
            public override double ConvertFrom(Gram fromUnit, double amount)        { return amount / G_LB; }
            public override double ConvertFrom(Kilogram fromUnit, double amount)    { return amount * KG_LB; }
            public override double ConvertFrom(Ounce fromUnit, double amount)       { return amount / OZ_LB; }
            public override double ConvertFrom(Pound fromUnit, double amount)       { return amount; }
            #endregion

            public override string GetName() { return "pound"; }
            public override string GetAbbreviation() { return "lb"; }
        }
    }

    public class Liquid : Unit
    {
        private const double ML_OZI = 28.413f, ML_OZUS = 29.574f, L_OZI = 35.195f, L_OZUS = 33.814f, OZI_OZUS = 1.041f;


        public override double Convert(Unit toUnit, double amount) { return toUnit.ConvertFrom(this, amount); }
        public override double ConvertFrom(Unit fromUnit, double amount) { return fromUnit.Convert(this, amount); }

        public virtual double ConvertFrom(Millilitre fromUnit, double amount)           { return 0; }
        public virtual double ConvertFrom(Litre fromUnit, double amount)                { return 0; }
        public virtual double ConvertFrom(FlozImperial fromUnit, double amount)         { return 0; }
        public virtual double ConvertFrom(FlozUS fromUnit, double amount)               { return 0; }

        public override State GetState() { return State.LIQUID; }


        public class Millilitre : Liquid
        {
            public override double Convert(Liquid toUnit, double amount) { return toUnit.ConvertFrom(this, amount); }
            public override double ConvertFrom(Liquid fromUnit, double amount) { return fromUnit.Convert(this, amount); }

            #region Convert From
            public override double ConvertFrom(Millilitre fromUnit, double amount)      { return amount; }
            public override double ConvertFrom(Litre fromUnit, double amount)           { return amount * METRIC; }
            public override double ConvertFrom(FlozImperial fromUnit, double amount)    { return amount * ML_OZI; }
            public override double ConvertFrom(FlozUS fromUnit, double amount)          { return amount * ML_OZUS; }
            #endregion

            public override string GetName() { return "millilitre"; }
            public override string GetAbbreviation() { return "ml"; }
        }

        public class Litre : Liquid
        {
            public override double Convert(Liquid toUnit, double amount) { return toUnit.ConvertFrom(this, amount); }
            public override double ConvertFrom(Liquid fromUnit, double amount) { return fromUnit.Convert(this, amount); }

            #region Convert From
            public override double ConvertFrom(Millilitre fromUnit, double amount)      { return amount / METRIC; }
            public override double ConvertFrom(Litre fromUnit, double amount)           { return amount; }
            public override double ConvertFrom(FlozImperial fromUnit, double amount)    { return amount / L_OZI; }
            public override double ConvertFrom(FlozUS fromUnit, double amount)          { return amount / L_OZUS; }
            #endregion

            public override string GetName() { return "litre"; }
            public override string GetAbbreviation() { return "L"; }
        }

        public class FlozImperial : Liquid
        {
            public override double Convert(Liquid toUnit, double amount) { return toUnit.ConvertFrom(this, amount); }
            public override double ConvertFrom(Liquid fromUnit, double amount) { return fromUnit.Convert(this, amount); }

            #region Convert From
            public override double ConvertFrom(Millilitre fromUnit, double amount)      { return amount / ML_OZI; }
            public override double ConvertFrom(Litre fromUnit, double amount)           { return amount * L_OZI; }
            public override double ConvertFrom(FlozImperial fromUnit, double amount)    { return amount; }
            public override double ConvertFrom(FlozUS fromUnit, double amount)          { return amount * OZI_OZUS; }
            #endregion

            public override string GetName() { return "fluid ounce (Imperial)"; }
            public override string GetAbbreviation() { return "fl oz (Imperial)"; }
        }

        public class FlozUS : Liquid
        {
            public override double Convert(Liquid toUnit, double amount) { return toUnit.ConvertFrom(this, amount); }
            public override double ConvertFrom(Liquid fromUnit, double amount) { return fromUnit.Convert(this, amount); }

            #region Convert From
            public override double ConvertFrom(Millilitre fromUnit, double amount)      { return amount / ML_OZUS; }
            public override double ConvertFrom(Litre fromUnit, double amount)           { return amount * L_OZUS; }
            public override double ConvertFrom(FlozImperial fromUnit, double amount)    { return amount / OZI_OZUS; }
            public override double ConvertFrom(FlozUS fromUnit, double amount)          { return amount; }
            #endregion

            public override string GetName() { return "fluid ounce (US)"; }
            public override string GetAbbreviation() { return "fl oz (US)"; }
        }
    }
}