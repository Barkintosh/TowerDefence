using UnityEngine;

[CreateAssetMenu(fileName = "EnemyParam", menuName = "EnemyParam")]
public class EnemyParam : ScriptableObject
{
    public string title;
    [Header("Stats")]
    public float health;
    public float speed;
    public float damageToPlayer;
    public float reward;
    [Header("Visuals")]
    public Sprite image;
    public GameObject model;
}
