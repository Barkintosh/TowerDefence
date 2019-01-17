using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    EnemyVisualBehavior enemyVisualBehavior;
    HealthBarBehavior healthBar;
    public MovementBehavior movement;
    [HideInInspector] public GameObject visual;


    [Space(5)]
    public EnemyParam param;
    public float health;

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

        // Checking if the enemy visual has a visualBehavior
        enemyVisualBehavior = visual.GetComponent<EnemyVisualBehavior>();
        if(enemyVisualBehavior != null) enemyVisualBehavior.enemyBehavior = this;

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
        GameManager.instance.moneyManager.UpdateMoney(param.reward);
        GameManager.instance.enemyManager.activeEnemies.Remove(this);
        healthBar.Hide();
        movement.enabled = false;
        Destroy(gameObject, 2f);
    }

    public void Update()
    {
        healthBar.SetBar(health, param.health, transform.position);
    }
}
