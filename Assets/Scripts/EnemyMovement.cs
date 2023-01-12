using UnityEngine;
using UnityEngine.AI;
public class EnemyMovement : MonoBehaviour
{
    public float moveSpeed;
    private int nextMovePoint = -1;
    private float dist = 30f;
    public Transform[] targetMovementPath;
    NavMeshAgent agent;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    public void MoveEnemy()
    {
        float step = moveSpeed * Time.deltaTime;

        if (nextMovePoint == -1 || dist <= 1)
        {
           nextMovePoint = Random.Range(0, targetMovementPath.Length);
        }
        if (nextMovePoint >= 0)
        {
            //transform.position = Vector3.MoveTowards(transform.position, targetMovementPath[nextMovePoint].position, step);
            //agent.destination = targetMovementPath[nextMovePoint].position;
            agent.SetDestination(targetMovementPath[nextMovePoint].position);
            dist = Vector3.Distance(transform.position, targetMovementPath[nextMovePoint].position);
            //transform.LookAt(targetMovementPath[nextMovePoint], Vector3.up);
        }


        
    }
}
