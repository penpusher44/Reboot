using UnityEngine;
using System.Collections;

public class DroneBuddy : MonoBehaviour
{
    public Transform Player;
    public Transform drone;
    public NavMeshAgent NPC;

    // Use this for initialization
    void Start()
    {
        NPC = GetComponent<NavMeshAgent>();
        NPC.destination = Player.position;
    }

    // Update is called once per frame
    void Update()
    {
        NPC = GetComponent<NavMeshAgent>();

        if (Vector3.Distance(Player.position, NPC.transform.position) <= NPC.stoppingDistance + 1)
        {
            NPC.destination = drone.position;
        }
        else
        {
            NPC.destination = Player.position;

        }
    }
}
