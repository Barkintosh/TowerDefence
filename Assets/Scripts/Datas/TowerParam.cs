using UnityEngine;

[CreateAssetMenu(fileName = "TowerParam", menuName = "TowerParam")]
public class TowerParam : ScriptableObject
{
    public string title = "tower title";
    [TextArea] public string description = "tower description";
    [Header("Stats")]
    public float price;
    public float damage;
    public float speed;
    public float range;
    public float[] levelMultiplier = new float[]{ 1f, 1.25f, 1.5f, 1.75f, 2f };
    [Header("Visuals")]
    public Sprite image;
    public GameObject model;
}
