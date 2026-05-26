using UnityEngine;

public class GraphMonsterAI : MonoBehaviour
{
    public Transform player;
    public PathNode currentNode;

    [Header("Vision")]
    public float loseDelay = 2f;

    private MonsterMove mover;

    private PathNode targetNode;

    private enum State { Patrol, Chase, Return }
    private State state = State.Patrol;

    private bool playerInRange = false;
    private float loseTimer = 0f;

    void Start()
    {
        mover = GetComponent<MonsterMove>();
        targetNode = currentNode;
    }

    void Update()
    {
        UpdateState();

        switch (state)
        {
            case State.Patrol:
                Patrol();
                break;

            case State.Chase:
                Chase();
                break;

            case State.Return:
                ReturnToGraph();
                break;
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.transform == player)
        {
            playerInRange = true;
            state = State.Chase;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.transform == player)
        {
            playerInRange = false;
            loseTimer = loseDelay;
        }
    }
    void UpdateState()
    {
        if (state == State.Chase)
        {
            if (!playerInRange)
            {
                loseTimer -= Time.deltaTime;

                if (loseTimer <= 0f)
                {
                    state = State.Return;
                }
            }
            else
            {
                loseTimer = loseDelay;
            }
        }
    }
    void Patrol()
    {
        if (targetNode == null) return;

        mover.MoveTowards(targetNode.transform.position);

        if (Reached(targetNode))
        {
            targetNode = GetRandomConnectedNode();
            currentNode = targetNode;
        }
    }
    void Chase()
    {
        if (player == null) return;

        mover.MoveTowards(player.position);
    }
    void ReturnToGraph()
    {
        if (currentNode == null) return;

        mover.MoveTowards(currentNode.transform.position);

        if (Reached(currentNode))
            state = State.Patrol;
    }
    bool Reached(PathNode node)
    {
        return Vector3.Distance(transform.position, node.transform.position) < 0.25f;
    }

    PathNode GetRandomConnectedNode()
    {
        if (targetNode == null || targetNode.connectedNodes.Length == 0)
            return targetNode;

        return targetNode.connectedNodes[
            Random.Range(0, targetNode.connectedNodes.Length)
        ];
    }
}