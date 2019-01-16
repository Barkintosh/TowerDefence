using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    public MovementBehavior movement;
    [Space(5)]
    public EnemyParam param;
    public float health;
    [HideInInspector] public GameObject visual;
    HealthBarBehavior healthBar;

    public void Start()
    {
        // Checking if all referencies are working
        if(movement == null) movement = gameObject.GetComponent<MovementBehavior>();
        if(movement == null) movement = gameObject.AddComponent<MovementBehavior>();
        if(movement.enemyBehavior == null) movement.enemyBehavior = this;
        
        // Getting a personnal healthbar
        healthBar = GameManager.instance.healthBarManager.GetBar();
        healthBar.Show();

        // Parsing values to the enemy
        visual = Instantiate(param.model, transform.position, Quaternion.identity, transform);
        health = param.health;
        movement.speed = param.speed;
    }

    public void TakeDamage(float nb)
    {
        health -= nb;
        if(health <= 0) Die();
    }

    public void Die()
    {
        GameManager.instance.enemyManager.activeEnemies.Remove(this);
        healthBar.Hide();
        Destroy(gameObject);
    }

    public void Update()
    {
        healthBar.SetBar(health, param.health, transform.position);
    }
}
