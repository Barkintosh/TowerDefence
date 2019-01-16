using UnityEngine;

[CreateAssetMenu(fileName = "TowerParam", menuName = "TowerParam")]
public class TowerParam : ScriptableObject
{
    public string title;
    [TextArea] public string description;
    [Header("Stats")]
    public float price;
    public float damage;
    public float speed;
    public float range;
    [Header("Visuals")]
    public Sprite image;
    public GameObject model;
}
