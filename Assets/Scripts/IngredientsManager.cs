using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using static Unit;

public class IngredientsManager : MonoBehaviour
{
    public static IngredientsManager Instance { get; private set; }

    private List<Ingredient> _ingredients = new List<Ingredient>() { new Ingredient() };


    private void Awake()
    {
        if (Instance != null && Instance != this) Destroy(this.gameObject);
        else Instance = this;
    }


    public void AddIngredient(Ingredient newIngredient)         { _ingredients.Add(newIngredient); }
    public void RemoveIngredient(Ingredient ingredientToRemove) { _ingredients.Remove(ingredientToRemove); }
    //public void SortIngredients()    { // }


    public void ConvertSolidUnits(Solid unit)
    {
        foreach (Ingredient ing in _ingredients.Where(n => n.Measure.IsSolid))
            ing.Measure.ConvertUnitTo(unit);
    }

    public void ConvertLiquidUnits(Liquid unit)
    {
        foreach (Ingredient ing in _ingredients.Where(n => n.Measure.IsLiquid))
            ing.Measure.ConvertUnitTo(unit);
    }
}