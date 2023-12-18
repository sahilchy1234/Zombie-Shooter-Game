using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class NPCHealing : MonoBehaviour
{
    public GameObject player;
    public GameObject helicopter;
    
    private bool _followPlayer;
    public float healingRate = 10f;
    public float healingDistance = 5f;
    public float healingDuration = 5f;
    public GameObject _healingUIanim;
    public Animator _animator;

    private bool isHealing = false;
    private NavMeshAgent navMeshAgent;

    private void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        if (IsPlayerInRange())
        {
            StartHealing();
        }
        else
        {
            StopHealing();
        }

        if (_followPlayer)
        {
            FollowPlayer();
        }
    }

    private bool IsPlayerInRange()
    {
        // GameObject player = GameObject.FindGameObjectWithTag("Player");

        if (player != null)
        {
            float distance = Vector3.Distance(transform.position, player.transform.position);
            return distance <= healingDistance;
        }

        return false;
    }

    private void StartHealing()
    {
        if (!isHealing)
        {
            if (_healingUIanim != null)
            {
                _healingUIanim.SetActive(true);
            }

            StartCoroutine(HealOverTime());
        }
    }

    private void StopHealing()
    {
        if (isHealing)
        {
            if (_healingUIanim != null)
            {
                _healingUIanim.SetActive(false);
            }

            StopAllCoroutines();
            isHealing = false;
        }
    }

    bool ik;
    private IEnumerator HealOverTime()
    {
        isHealing = true;
        float elapsedTime = 0f;

        while (isHealing && elapsedTime < healingDuration)
        {
            float healAmount = healingRate * Time.deltaTime;

            // Implement your actual healing logic here
            // e.g., npcHealth += healAmount;

            elapsedTime += Time.deltaTime;

            yield return null; // Wait for the next frame
        }

        // Healing successful
        if (_healingUIanim != null)
        {
            _healingUIanim.SetActive(false);
        }


        _healingUIanim = null;
        _animator.SetBool("healed", true);

        if (ik == false)
        {
            ik = true;
            _animator.Play("Healed");
        }

        // Follow the player after healing
        HostageManager.instance.Exploded();
        // ZombieTrigger();
        FollowPlayer();

    }

    float _time;
    private void FollowPlayer()
    {
        _followPlayer = true;
        _time += Time.deltaTime;

        if (_time > 12f)
        {


            // GameObject player = GameObject.FindGameObjectWithTag("Player");

            if (player != null)
            {
                navMeshAgent.SetDestination(helicopter.transform.position);

                if (navMeshAgent.velocity.magnitude > 0.01f)
                {
                    // The NavMeshAgent is moving, play the "Run" animation
                    _animator.SetBool("isRunning", true);
                }
                else
                {
                    // The NavMeshAgent is not moving, play the "Idle" animation
                    _animator.SetBool("isRunning", false);
                }
            }
        }
    }


}
