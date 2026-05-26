using UnityEngine;

public class RoomMonsterAI : MonoBehaviour
{
    public Transform player;
    public RoomNode currentRoom;

    private RoomNode targetRoom;
    private Vector3 targetPos;

    private RoomNode lastSeenRoom;
    private float memoryTimer = 0f;
    public float memoryDuration = 6f;

    private MonsterMove mover;

    void Start()
    {
        mover = GetComponent<MonsterMove>();
        InvokeRepeating(nameof(Think), 0.8f, 1.2f);
    }

    void Update()
    {
        if (targetRoom != null)
        {
            mover.MoveTowards(targetPos);

            if (Vector3.Distance(transform.position, targetPos) < 0.25f)
            {
                currentRoom = targetRoom;
                targetRoom = null;
            }
        }
        else
        {
            mover.Stop();
        }

        UpdateMemory();
    }

    void Think()
    {
        if (player == null || currentRoom == null) return;

        RoomNode playerRoom = FindClosestRoom(player.position);

        if (playerRoom != null)
        {
            lastSeenRoom = playerRoom;
            memoryTimer = memoryDuration;
        }

        // 🧠 STATE 1: PLAYER IN SAME ROOM → DIRECT PRESSURE
        if (playerRoom == currentRoom)
        {
            targetPos = player.position;
            targetRoom = currentRoom;
            return;
        }

        // 🧠 STATE 2: INTERCEPT MODE
        if (playerRoom != null && Random.value < 0.7f)
        {
            targetRoom = GetInterceptRoom(playerRoom);
        }
        else
        {
            // 🧠 STATE 3: SEARCH / MEMORY MODE
            if (lastSeenRoom != null)
            {
                targetRoom = GetNextRoomTowards(lastSeenRoom);
            }
            else
            {
                targetRoom = GetRandomNeighbor();
            }
        }

        if (targetRoom != null)
            targetPos = targetRoom.transform.position;
    }

    void UpdateMemory()
    {
        if (memoryTimer > 0)
            memoryTimer -= Time.deltaTime;
        else
            lastSeenRoom = null;
    }

    // 🔥 SMART INTERCEPT (not direct chase)
    RoomNode GetInterceptRoom(RoomNode playerRoom)
    {
        RoomNode best = null;
        float bestScore = Mathf.Infinity;

        foreach (RoomNode r in currentRoom.connectedRooms)
        {
            float distToPlayer = Vector3.Distance(r.transform.position, playerRoom.transform.position);
            float distToMe = Vector3.Distance(r.transform.position, transform.position);

            float score = distToPlayer * 0.7f + distToMe * 0.3f;

            if (score < bestScore)
            {
                bestScore = score;
                best = r;
            }
        }

        return best;
    }

    RoomNode GetNextRoomTowards(RoomNode target)
    {
        RoomNode best = null;
        float bestDist = Mathf.Infinity;

        foreach (RoomNode r in currentRoom.connectedRooms)
        {
            float d = Vector3.Distance(r.transform.position, target.transform.position);

            if (d < bestDist)
            {
                bestDist = d;
                best = r;
            }
        }

        return best;
    }

    RoomNode GetRandomNeighbor()
    {
        if (currentRoom.connectedRooms.Length == 0) return null;
        return currentRoom.connectedRooms[Random.Range(0, currentRoom.connectedRooms.Length)];
    }

    RoomNode FindClosestRoom(Vector3 pos)
    {
        RoomNode[] all = Object.FindObjectsByType<RoomNode>(FindObjectsSortMode.None);

        RoomNode best = null;
        float bestDist = Mathf.Infinity;

        foreach (RoomNode r in all)
        {
            float d = Vector3.Distance(pos, r.transform.position);

            if (d < bestDist)
            {
                bestDist = d;
                best = r;
            }
        }

        return best;
    }
}