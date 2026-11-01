
using UnityEngine;
using UnityEngine.AI;

public class ControlNPCFSM : MonoBehaviour
{
    private Animator anim;
    private GameObject player;
    private NavMeshAgent agent;
    private ManagePlayerHealth playerHealth;

    public float detectionDistance = 20f;
    public float stoppingDistance = 2f;
    public float attackDistance = 2.5f;
    public float attackInterval = 2f;
    public float fieldOfView = 90f;

    private float nextAttackTime;
    private bool hasSeenPlayer = false;

    void Start()
    {
        anim = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();

        FindPlayer();

        if (agent != null)
            agent.stoppingDistance = stoppingDistance;
    }

    void FindPlayer()
    {
        player = GameObject.FindGameObjectWithTag("Player");

        if (player != null)
            playerHealth = player.GetComponent<ManagePlayerHealth>();
    }

    void Update()
    {
        if (player == null)
        {
            FindPlayer();
            return;
        }

        if (agent == null || !agent.isOnNavMesh)
            return;

        Vector3 eyePosition = transform.position + Vector3.up * 1.5f;
        Vector3 playerPosition = player.transform.position + Vector3.up * 0.5f;
        Vector3 direction = playerPosition - eyePosition;

        float distance = Vector3.Distance(
            transform.position, player.transform.position
        );

        Vector3 flatDirection = player.transform.position - transform.position;
        flatDirection.y = 0f;

        float angle = Vector3.Angle(transform.forward, flatDirection);
        bool insideFieldOfView = angle <= fieldOfView / 2f;

        bool clearSight = false;

        if (direction.magnitude <= detectionDistance)
        {
            if (Physics.Raycast(eyePosition, direction.normalized,
                out RaycastHit hit, detectionDistance))
            {
                clearSight = hit.collider.transform.root == player.transform;
            }
        }

        bool canSeePlayer = insideFieldOfView && clearSight;

        if (canSeePlayer)
            hasSeenPlayer = true;

        anim.SetBool("canSeePlayer", hasSeenPlayer);

        bool canAttack = distance <= attackDistance && clearSight;
        anim.SetBool("canAttackPlayer", canAttack);

        if (canAttack)
        {
            agent.ResetPath();

            if (Time.time >= nextAttackTime)
            {
                if (playerHealth != null)
                    playerHealth.decreaseHealth(5);

                nextAttackTime = Time.time + attackInterval;
            }
        }
        else if (hasSeenPlayer)
        {
            agent.SetDestination(player.transform.position);
        }
        else
        {
            agent.ResetPath();
        }

        Debug.DrawRay(
            eyePosition,
            direction.normalized * detectionDistance,
            canSeePlayer ? Color.green : Color.red
        );
    }
}
