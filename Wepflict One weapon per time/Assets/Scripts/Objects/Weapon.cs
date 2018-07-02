using UnityEngine;
using System;

[CreateAssetMenu(fileName = "Weapon", menuName = "GameData/Weapon", order = 2)]
public class Weapon : ScriptableObject
{
    public new string name;
    public Sprite icon;
    public Renderer model;
    public AttackType shootType;

    public Stat damage;
    public Stat accuracy;
    public Stat bulletsPerShot;
    public Stat maxDistance;
    
    [Tooltip("Rate of fire calculated in seconds")]
    public float rateOfFire;

}