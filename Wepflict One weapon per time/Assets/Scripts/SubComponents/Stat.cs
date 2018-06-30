using System.Collections.Generic;
using System.Linq;

public class Stat
{
    private float baseValue;
    public float BaseValue
    {
        get
        {
            return baseValue;
        }
        set
        {
            baseValue = value < 1.0f ? 1.0f : value;
        }
    }
    public float TotalValue
    {
        get
        {
            return BaseValue + modifiers.Sum();
        }
    }

    private List<int> modifiers;
    
    public void AddModifier(int modifier)
    {
        modifiers.Add(modifier);
    }

    public void RemoveModifier(int modifier)
    {
        modifiers.Remove(modifier);
    }
}