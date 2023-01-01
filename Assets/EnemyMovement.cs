using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float moveSpeed;
    private int nextMovePoint = -1;
    private float dist = 30f;
    public Transform[] targetMovementPath;


    public void MoveEnemy()
    {
        float step = moveSpeed * Time.deltaTime;

        if (nextMovePoint == -1 || dist <= 0)
        {
           nextMovePoint = Random.Range(0, targetMovementPath.Length);
        }
        if (nextMovePoint >= 0)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetMovementPath[nextMovePoint].position, step);
            dist = Vector3.Distance(transform.position, targetMovementPath[nextMovePoint].position);
            transform.LookAt(targetMovementPath[nextMovePoint]);
        }
    }
}
