
using UnityEngine;
using UnityEngine.AI;

public class ControlNPC : MonoBehaviour
{
    public GameObject target;
    public GameObject WP1, WP2, WP3, WP4;
    public bool isWandering = false;

    private int WPCount;
    private GameObject[] WayPoints;
    private NavMeshAgent agent;
    private GameObject wanderingTarget;
    private float timer;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();

        WP1 = GameObject.Find("WP1");
        WP2 = GameObject.Find("WP2");
        WP3 = GameObject.Find("WP3");
        WP4 = GameObject.Find("WP4");

        WayPoints = new GameObject[] { WP1, WP2, WP3, WP4 };
        WPCount = 0;

        for (int i = 0; i < WayPoints.Length; i++)
        {
            WayPoints[i].GetComponent<Renderer>().enabled = false;
        }

        if (isWandering)
        {
            wanderingTarget = new GameObject("wanderingTarget");
            wander();
        }
    }

    void Update()
    {
        if (isWandering)
        {
            timer += Time.deltaTime;

            checkAhead();

            if (timer > 4f)
            {
                timer = 0f;
                wander();
            }
        }
        else
        {
            target = WayPoints[WPCount];

            if (Vector3.Distance(transform.position,
                target.transform.position) < 1.0f)
            {
                moveToRandomWP();
            }

            agent.SetDestination(WayPoints[WPCount].transform.position);
        }
    }

    void moveToRandomWP()
    {
        int previous = WPCount;
        int random = 0;

        do
        {
            random = Random.Range(0, WayPoints.Length);
        }
        while (random == previous);

        WPCount = random;
    }

    void wander()
    {
        Ray ray = new Ray();
        RaycastHit hit;

        ray.origin = transform.position + Vector3.up * 0.7f;

        float castingDistance = 20f;

        for (int i = 0; i < 20; i++)
        {
            float randomDirectionX = Random.Range(-1.0f, 1.0f);
            float randomDirectionZ = Random.Range(-1.0f, 1.0f);

            ray.direction = (transform.forward * randomDirectionZ +
                transform.right * randomDirectionX).normalized;

            Debug.DrawRay(ray.origin,
                ray.direction * castingDistance, Color.red, 2f);

            float distanceToObstacle = castingDistance;

            if (Physics.Raycast(ray, out hit, castingDistance))
            {
                distanceToObstacle = hit.distance;
            }

            if (distanceToObstacle < 2f)
                continue;

            Vector3 destination = ray.origin +
                ray.direction * (distanceToObstacle - 1f);

            if (NavMesh.SamplePosition(destination,
                out NavMeshHit navHit, 4f, agent.areaMask))
            {
                wanderingTarget.transform.position = navHit.position;
                target = wanderingTarget;
                agent.SetDestination(target.transform.position);
                return;
            }
        }
    }

    void checkAhead()
    {
        Ray ray = new Ray();
        RaycastHit hit;

        float castingDistance = 2f;

        ray.origin = transform.position + Vector3.up * 0.7f;
        ray.direction = transform.forward;

        Debug.DrawRay(ray.origin,
            ray.direction * castingDistance, Color.red);

        if (Physics.Raycast(ray, out hit, castingDistance))
        {
            wander();
            timer = 0f;
        }
    }
}
