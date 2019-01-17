using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementBehavior : MonoBehaviour
{
    public EnemyBehavior enemyBehavior;
    [Space(5)]
    public float speed = 0f;
    public List<Vector3> path = new List<Vector3>();

    Vector3 direction;
    int waypoint;
    int currentWayPoint;

    void Update()
    {
        WalkPath();
    }

    public void NextPathPoint()
    {
        direction = path[currentWayPoint] - transform.position;
        enemyBehavior.visual.transform.LookAt(new Vector3(path[currentWayPoint].x, transform.position.y, path[currentWayPoint].z));
    } // SET THE NEXT WAYPOINT OF THE MOB

    void WalkPath()
    {
        transform.Translate(direction.normalized * speed * Time.fixedDeltaTime);
        if((path[currentWayPoint] - transform.position).magnitude <= 0.25f )
        {
            if(currentWayPoint < path.Count - 1)
            {
                currentWayPoint++;
                NextPathPoint();
            }
            else
            {
                Arrived();
                this.enabled = false;
            }
        }
    } // WALK ALONG THE PATH UNTIL HE REACH HIS WAYPOINT

    void Arrived()
    {
        if(path[currentWayPoint] == GameManager.instance.levelManager.path[GameManager.instance.levelManager.path.Count - 1])
        {
            GameManager.instance.systemManager.UpdateHealth(-enemyBehavior.param.damageToPlayer);
            enemyBehavior.Die();
        }
        
    }
}
