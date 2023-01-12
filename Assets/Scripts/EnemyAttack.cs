
using System.Collections;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class EnemyAttack : MonoBehaviour
{
    public Transform player;
    public float waitForNextFire=2;
    public float fireTime;
    // enemy patrol
    public float moveSpeed;

    // chase player
    public float sightRange = 15f;
    bool playerInSightRange;

    // attack player
    public float attackRange=10f;
    bool playerInAttackRange;
    bool isFired = false;
    

    public float playerHealth;
    public float damage=10f;
    NavMeshAgent agent;

    public Transform[] targetMovementPath;
    public Text gameOver;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    private void Start()
    {

        gameOver.enabled = false;
    }

    private void Update()
    {
        if (!playerInSightRange && !playerInAttackRange) EnemyPatrol();
        if (playerInSightRange && !playerInAttackRange) ChasePlayer(); 
        if (playerInSightRange && playerInAttackRange) AttackPlayer();
        
    }

    void EnemyPatrol()
    {
        EnemyMovement enemy = GetComponent<EnemyMovement>();
        enemy.MoveEnemy();
        if(Vector3.Distance(transform.position, player.position) <= sightRange)
        {
            playerInSightRange = true;
        }
    }

    void ChasePlayer()
    {
        //float step = moveSpeed * Time.deltaTime;
        //transform.position = Vector3.MoveTowards(transform.position, player.transform.position, step);
        //transform.LookAt(player, Vector3.up);
        agent.SetDestination(player.transform.position);

        if (playerInSightRange && Vector3.Distance(transform.position, player.position) <= attackRange)
        {
            playerInAttackRange = true;
            agent.isStopped = true;
        }
            

        if (Vector3.Distance(transform.position, player.position) > sightRange)
        {
            playerInSightRange = false;
            agent.isStopped = false;
        }
            
        
    }

    void AttackPlayer()
    {
        transform.LookAt(player, Vector3.up); // look at player
        Quaternion rotation = transform.rotation;
        Vector3 playerPos = player.position;
        rotation.x = 0f;
        rotation.z = 0f;
        transform.Rotate(new Vector3(rotation.x, playerPos.y, rotation.z));
        transform.rotation = rotation;

        
        if(!isFired && Time.time>fireTime)
        {
            isFired = true;
            HitFire();
            print("fired");
            
        }

        

        if (Vector3.Distance(transform.position, player.position) > attackRange)
        {
            playerInAttackRange = false;
            agent.isStopped = false;
        }
            
        if (Vector3.Distance(transform.position, player.position) > sightRange)
            playerInSightRange = false;
    }


    void HitFire()
    {
        RaycastHit hit;
        
        if (Physics.Raycast(transform.position, transform.forward, out hit, attackRange))
        {
            //Debug.Log(hit.transform.name);
            
            PlayerMovement target = hit.transform.GetComponent<PlayerMovement>();
            if (target != null)
            {
                playerHealth -= damage;
                fireTime = Time.time + waitForNextFire;
                isFired = false;

                if (playerHealth <= 0f)
                    {
                        print("HITTTTTT");
                        gameOver.enabled = true;
                    }               
            }
        }
        


    }

    

}
