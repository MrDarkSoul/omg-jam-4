using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[System.Serializable]
public class Stat
{

    [SerializeField]
    private float baseValue;
    public float BaseValue
    {
        get
        {
            return baseValue;
        }
        set
        {
            this.baseValue = value < 0 ? 0 : value;
        }
    }
    public float TotalValue
    {
        get
        {
            float value = BaseValue + modifiers.Sum();

            if (cap > 0 & value > cap)
            {
                return (float)cap;
            }

            return value;
        }
    }
    public float cap;

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