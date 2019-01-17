using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponBehavior : MonoBehaviour
{
    [HideInInspector] public TowerBehavior tower;
    [HideInInspector] public EnemyBehavior target;
    [HideInInspector] public float reloadTimer;
    [HideInInspector] public float damage;
    [HideInInspector] public float speed;
    [HideInInspector] public float range;

    public void Load(float _damage, float _speed, float _range)
    {
        damage = _damage;
        speed = _speed;
        range = _range;
    }

    EnemyBehavior NewTarget()
    {
        List<EnemyBehavior> inRange = new List<EnemyBehavior>();
        foreach(EnemyBehavior enemy in GameManager.instance.enemyManager.activeEnemies)
        {
            if(Vector3.Distance(transform.position, enemy.transform.position) < range)
            {
                inRange.Add(enemy);
            }
        }

        if(inRange.Count > 0)
        {
            return GameManager.instance.enemyManager.GetNearestEnemy(inRange.ToArray());
        }

        return null;
    }

    void Update()
    {
        if(target != null)
        {
            // Drawing a debug line renderer on the canvas
            Vector2 origin = Camera.main.WorldToScreenPoint(transform.position);
            Vector2 targetPosition = Camera.main.WorldToScreenPoint(target.transform.position);
            GameManager.instance.canvasLineRenderer.DrawCanvasLine(origin, targetPosition, 2f, Color.red);

            // Rotate the tower visual towards its target
            //visual.transform.LookAt(target.transform.position);

            // Checking if the target is still in range
            if(Vector3.Distance(transform.position, target.transform.position) > range) 
            {
                // Getting a new target
                target = null;
                target = NewTarget();
            }

            // Check if the weapon is ready to fire
            if(Time.time > reloadTimer)
            {
                Shoot();
            }
        }
        else target = NewTarget();
    }

    void Shoot()
    {
        target.TakeDamage(damage);
        reloadTimer = Time.time + speed;

        if(tower.visual != null && tower.visual.animator != null)
        {
            tower.visual.animator.SetTrigger("Shoot");
        }
    }
}
