using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class target : MonoBehaviour
{
    public float health = 100f;
    public Transform[] targetMovementPath;
    public float moveSpeed = 100f;

    int nextMovePoint = -1;
    float dist = 30;
    public void getDamage(float amount)
    {
        health -= amount;
        if (health <= 0f)
        {
            Die();
        }
    }

    void Die()
    {
        Destroy(gameObject);
    }

    void Update()
    {
        float step = moveSpeed * Time.deltaTime;

        if (nextMovePoint == -1 || dist <= 0)
        {
            nextMovePoint = Random.Range(0, targetMovementPath.Length);
        }

        transform.position = Vector3.MoveTowards(transform.position, targetMovementPath[nextMovePoint].position, step);
        dist = Vector3.Distance(transform.position, targetMovementPath[nextMovePoint].position);
    }


}
