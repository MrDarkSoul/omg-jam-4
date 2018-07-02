using UnityEngine;

[CreateAssetMenu(fileName = "Enemy", menuName = "GameData/Enemy", order = 2)]
public class Enemy : ScriptableObject {

    public Renderer model;
    public Stat health;
    public Stat accuracy;

}
