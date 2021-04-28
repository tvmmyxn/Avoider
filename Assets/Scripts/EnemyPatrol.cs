using System.Collections;
using System.Linq;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    [SerializeField] private GameObject movementPathPrefab = null;
    [SerializeField] private PlayerDash player;

    private Enemy enemy;
    private Transform[] waypoints;
    private int waypoints_Index;
    private Vector3 targetPosition;

    private void Awake()
    {
        enemy = GetComponent<Enemy>();
        waypoints = movementPathPrefab.GetComponentsInChildren<Transform>().Where(t => t.position != Vector3.zero).ToArray();
        transform.position = waypoints[0].transform.position;
    }

    void Update()
    {
        FollowPlayer();
        FollowPath();
        SetNextTargetWaypoint();
        Vector3 pos = transform.position;
        pos.z = 0;
        transform.position = pos;

    }

    private void FollowPlayer()
    {
       
        if (Mathf.Abs(transform.position.x - player.transform.position.x) > 5 ||
            Mathf.Abs(transform.position.y - player.transform.position.y) > 5)
        {
            return;
        }

        transform.position = Vector3.MoveTowards(transform.position, player.transform.position, enemy.movementSpeed * Time.deltaTime);
    }

    private void FollowPath()
    {
        if (waypoints_Index <= waypoints.Length - 1)
        {
            targetPosition = waypoints[waypoints_Index].transform.position;
            var movementOnFrame = enemy.movementSpeed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, movementOnFrame);
            
        }
    }

    private void SetNextTargetWaypoint()
    {
        if (new Vector3(transform.position.x, transform.position.y, transform.position.z) == targetPosition)
        {
            waypoints_Index++;
        }

        if (waypoints_Index == waypoints.Length)
        {
            waypoints_Index = 0;
        }
    }
}