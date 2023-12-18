using UnityEngine;
using UnityEngine.AI;

using AuroraFPSRuntime.Attributes;
using AuroraFPSRuntime.CoreModules.Mathematics;
using AuroraFPSRuntime.SystemModules.ControllerModules;
using AuroraFPSRuntime.SystemModules;
using AuroraFPSRuntime.SystemModules.HealthModules;
using UnityEngine;
using AuroraFPSRuntime.SystemModules.ControllerSystems;
using AuroraFPSRuntime;
public class ZombieAI : MonoBehaviour
{

    [Foldout("Not Necessary Except Level 5 and 6", Style = "Header")]
    public ObjectHealth _objectHealth;
    public float runningSpeed;
    private bool isRunning;

    public DamageInfo dmgInfo;
    public int AttackDamage;
    public FPHealth fpHealth;

    public float detectionRadius = 10f;
    public float attackRange = 2f;
    public float attackCooldown = 2f;
    public float hurtCooldown = 1f;
    public float patrolRadius = 10f; // Radius for random patrol points

    public Transform player;
    private NavMeshAgent navMeshAgent;
    private Animator animator;

    public bool masterAlert;
    public bool isAlerted = false;
    private bool isHurt = false;
    private bool isDead = false;
    private float lastAttackTime;
    private float lastHurtTime;



    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        // animator.SetBool("IsWalking", true); // Set walking animation to true at the start
        SetRandomDestination(); // Start by moving to a random point
    }

    void Update()
    {
        if (!isDead)
        {
            if (!isHurt)
            {

                if (navMeshAgent.isStopped == true)
                {
                    animator.SetBool("IsWalking", false);
                    animator.SetBool("Running", false);
                }

                float velocity = navMeshAgent.velocity.magnitude;
                if (velocity > 0.2)
                {
                    if (isRunning == false)
                    {
                        animator.SetBool("IsWalking", true);

                    }
                    else
                    {
                        animator.SetBool("IsWalking", false);
                        animator.SetBool("Running", true);
                        navMeshAgent.speed = runningSpeed;
                    }

                }
                else
                {
                    animator.SetBool("IsWalking", false);
                    animator.SetBool("Running", false);
                }

                if (Vector3.Distance(transform.position, player.position) < detectionRadius)
                {
                    isAlerted = true;
                }
                else
                {
                    isAlerted = false;
                }
                if (!isAlerted)
                {
                    if (masterAlert != true)
                    {
                        Patrol();
                        CheckForPlayer();
                    }
                }
                else
                {
                    FollowPlayer();
                    AttackPlayer();
                }

                if (masterAlert == true)
                {
                    FollowPlayer();
                    AttackPlayer();
                }
            }
        }



        float desiredSpeed = navMeshAgent.desiredVelocity.magnitude;

        // Normalize and scale to animation parameter range (adjust range if needed)
        float normalizedSpeed = Mathf.Clamp01(desiredSpeed / runningSpeed);

        // Set animation speed parameter
        animator.SetFloat("MovementSpeed", normalizedSpeed);
    }

    void Patrol()
    {
        if (!navMeshAgent.pathPending && navMeshAgent.remainingDistance < 2.2f)
        {
            SetRandomDestination();
            isRunning = false;

        }
    }

    void SetRandomDestination()
    {
        Vector3 randomPoint = GetRandomPointOnNavMesh(transform.position, patrolRadius);
        navMeshAgent.SetDestination(randomPoint);
    }

    Vector3 GetRandomPointOnNavMesh(Vector3 center, float radius)
    {
        Vector3 randomDirection = Random.insideUnitSphere * radius;
        randomDirection += center;
        NavMeshHit hit;
        NavMesh.SamplePosition(randomDirection, out hit, radius, NavMesh.AllAreas);
        return hit.position;
    }

    void CheckForPlayer()
    {
        if (Vector3.Distance(transform.position, player.position) < detectionRadius)
        {
            // isAlerted = true;
            SetRandomDestination();
            // animator.SetBool("IsWalking", true);
        }
    }

    void FollowPlayer()
    {
        if (Vector3.Distance(transform.position, player.position) < detectionRadius)
        {
            // Set destination to player position
            navMeshAgent.SetDestination(player.position);
            isRunning = true;
            // Look at the player
            Vector3 directionToPlayer = (player.position - transform.position).normalized;
            Quaternion lookRotation = Quaternion.LookRotation(new Vector3(directionToPlayer.x, 0, directionToPlayer.z));
            transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);


        }

        if (Vector3.Distance(transform.position, player.position) < 2f)
        {
            if (!PlayerPrefs.HasKey("tutorial 2nd Part"))
            {
                DialongM.instance.tutorialHeadshot();
                Invoke("NormalizeTime",4f);
                PlayerPrefs.SetInt("tutorial 2nd Part", 1);
            }
        }
    }


    void NormalizeTime()
    {
        Time.timeScale = 1f;
    }
    void AttackPlayer()
    {
        if (Vector3.Distance(transform.position, player.position) < attackRange)
        {
            if (Time.time - lastAttackTime > attackCooldown)
            {
                fpHealth.TakeDamage(AttackDamage, dmgInfo);

                if (_objectHealth != null)
                {
                    _objectHealth.TakeDamage(AttackDamage, dmgInfo);
                }

                // Perform attack logic here
                Debug.Log("Zombie attacks!");
                animator.SetTrigger("Attack");

                lastAttackTime = Time.time;

                // Set isAlerted to true after attacking
                isAlerted = true;
                isRunning = false;
                animator.SetBool("Running", false);

                // Stop the navigation agent during attack animation
                navMeshAgent.isStopped = true;
            }
        }
        else
        {
            // Player is out of attack range, set isWalking to false
            // animator.SetBool("IsWalking", false);

            // Resume navigation when the player is out of attack range
            navMeshAgent.isStopped = false;
        }
    }


    public void Hurt()
    {
        ZombieAudioController zn = gameObject.GetComponent<ZombieAudioController>();
        if (!isDead && Time.time - lastHurtTime > hurtCooldown)
        {

            navMeshAgent.SetDestination(player.position);
            isRunning = true;
            // Look at the player
            Vector3 directionToPlayer = (player.position - transform.position).normalized;
            Quaternion lookRotation = Quaternion.LookRotation(new Vector3(directionToPlayer.x, 0, directionToPlayer.z));
            transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);


            isHurt = true;
            animator.SetTrigger("Hurt");
            zn.PlayHurtSoundEffect();
            Invoke("EndHurt", hurtCooldown);
            lastHurtTime = Time.time;
        }
    }

    public void Die()
    {
        if (!isDead)
        {
            Level_Manager.instance.kills++;
            Popup_Manager.instance.ShowPopupMessage("Killed !");
            isDead = true;
            animator.SetBool("Die", true);
            navMeshAgent.isStopped = true;
            // You may want to disable other components (like a collider) here as well.
            Destroy(gameObject, 10f); // Destroy the GameObject after 3 seconds, adjust as needed.
        }
    }

    void EndHurt()
    {
        isHurt = false;
    }
}
