using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerBehavior : MonoBehaviour
{
    public TowerParam param;
    public EnemyBehavior target;

    [HideInInspector] public float reloadTimer;
    GameObject visual;
    TowerVisualsBehavior towerVisualsBehavior;

    public void LoadTower(TowerParam _param)
    {
        param = _param;
        visual = Instantiate(param.model, transform.position, Quaternion.identity, transform);

        // Checking if the tower visual has a visualBehavior
        towerVisualsBehavior = visual.GetComponent<TowerVisualsBehavior>();
        if(towerVisualsBehavior != null) towerVisualsBehavior.towerBehavior = this;
    }


    EnemyBehavior NewTarget()
    {
        List<EnemyBehavior> inRange = new List<EnemyBehavior>();
        foreach(EnemyBehavior enemy in GameManager.instance.enemyManager.activeEnemies)
        {
            if(Vector3.Distance(transform.position, enemy.transform.position) < param.range)
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
            if(Vector3.Distance(transform.position, target.transform.position) > param.range) 
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
        target.TakeDamage(param.damage);
        reloadTimer = Time.time + param.speed;

        if(towerVisualsBehavior != null && towerVisualsBehavior.animator != null)
        {
            towerVisualsBehavior.animator.SetTrigger("Shoot");
        }
    }
}
