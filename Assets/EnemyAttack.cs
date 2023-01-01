
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class EnemyAttack : MonoBehaviour
{
    public Transform player;
    public float enemyRange=2f;
    public float playerHealth=1000f;
    public float damage=10f;
    public float moveSpeed;
    public Transform[] targetMovementPath;
    public Text gameOver;

    private void Start()
    {

        gameOver.enabled = false;
    }

    private void Update()
    {
        EnemyShoot();
    }

    public bool DetectPlayer()
    {
        
        if (Vector3.Distance(transform.position, player.position) <= enemyRange)
        {
            return true;
        }
        else
        {

            return false;
        }
        

    }
    void EnemyShoot()
    {
        if (DetectPlayer())
        {
            transform.LookAt(player, Vector3.up); // look at player
            AttackPlayer();
        }
        else
        {
            EnemyMovement enemy = GetComponent<EnemyMovement>();
            if (enemy != null)
            {
                enemy.MoveEnemy();
            }
            
        }
    }


    void AttackPlayer()
    {
        RaycastHit hit;
        
        if (Physics.Raycast(transform.position, transform.forward, out hit, enemyRange))
        {
            

            PlayerMovement target = hit.transform.GetComponent<PlayerMovement>();

            if (target != null)
            {
                
                
                    playerHealth -= damage;
                    if (playerHealth <= 0f)
                    {
                        print("HITTTTTT");
                        gameOver.enabled = true;

                    }
                

            }


        }
    }

}
