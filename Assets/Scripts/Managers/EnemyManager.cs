using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public GameObject enemyPrefab;
    public EnemyParam[] enemies;

    public List<EnemyBehavior> activeEnemies = new List<EnemyBehavior>();

    public void SpawnEnemy(int which, Vector3 where)
    {
        EnemyBehavior newEnemy = Instantiate(enemyPrefab, where, Quaternion.identity).GetComponent<EnemyBehavior>();
        newEnemy.param = enemies[which];
        newEnemy.movement.path = GameManager.instance.levelManager.path;

        activeEnemies.Add(newEnemy);
    }

    public EnemyBehavior GetNearestEnemy(EnemyBehavior[] enemies)
    {
        EnemyBehavior nearest = enemies[0];
        for( int i = 1; i < enemies.Length; i++)
        {
            float distance1 = Vector3.Distance(nearest.transform.position, GameManager.instance.levelManager.path[GameManager.instance.levelManager.path.Count - 1]);
            float distance2 = Vector3.Distance(enemies[i].transform.position, GameManager.instance.levelManager.path[GameManager.instance.levelManager.path.Count - 1]);
            
            if(distance2 < distance1)
            {
                nearest = enemies[i];
            }
        }
        return nearest;
    }
}
