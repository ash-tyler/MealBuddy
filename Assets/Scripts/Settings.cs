using UnityEngine;

public class Settings : MonoBehaviour
{
    public static Settings Instance { get; private set; }

    public int SelectedSolidUnits = 0;
    public int SelectedFluidUnits = 0;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            Instance = this;
        }
    }


    public void ChangeSolidUnits(int value)
    {
        if (SelectedSolidUnits == value) return;

        IngredientsManager.Instance.ConvertSolidUnits(Unit.solidTemplate[value]);
        SelectedSolidUnits = value;
    }

    public void ChangeFluidUnits(int value)
    {
        if (SelectedFluidUnits == value) return;

        IngredientsManager.Instance.ConvertLiquidUnits(Unit.liquidTemplate[value]);
        SelectedFluidUnits = value;
    }
}