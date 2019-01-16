using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerBehavior : MonoBehaviour
{
    public TowerParam param;
    public EnemyBehavior target;
    float reloadTimer;

    [HideInInspector] public GameObject visual;

    public void LoadTower(TowerParam _param)
    {
        param = _param;
        visual = Instantiate(param.model, transform.position, Quaternion.identity, transform);
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
            Vector2 origin = Camera.main.WorldToScreenPoint(transform.position);
            Vector2 targetPosition = Camera.main.WorldToScreenPoint(target.transform.position);
            GameManager.instance.canvasLineRenderer.DrawCanvasLine(origin, targetPosition, 2f, Color.red);
            if(Vector3.Distance(transform.position, target.transform.position) > param.range) 
            {
                target = null;
                target = NewTarget();
            }
            if(Time.time > reloadTimer)
            {
                target.TakeDamage(param.damage);
                reloadTimer = Time.time + param.speed;
            }
        }
        else target = NewTarget();
    }
}
