using UnityEngine;
using System.Collections;
using System.Threading;

public class AI2 : MonoBehaviour {
    public Transform[] Shops;
    public Transform[] Transport;
    public Transform Origin;
    public GameObject[] Outfits;
    int CycleStage = 1;
    int TransportNumber;
    int ShopNumber;
    int NumberVisits;
    int CurrentShop;
    int CurrentTransport;


    void Start () {
        //NavMeshAgent NPC = GetComponent<NavMeshAgent>();
        //int NumberShops = Random.Range(1, Shops.Length);
        //NPC.destination = Origin.position;
        //while (Vector3.Distance(NPC.destination, NPC.transform.position) >= NPC.stoppingDistance + 1)
        //{
        //    NPC.destination = Origin.position;
        //}

        //while (Vector3.Distance(NPC.destination, NPC.transform.position) >= NPC.stoppingDistance + 1)
        //{
        //    NPC.destination = Transport[0].position;
        //}


        

        //    if (NPC.remainingDistance - 1 <= NPC.stoppingDistance)
        //    {
        //        NPC.destination = Transport[Random.Range(0, Transport.Length - 1)].position;
        //        for (int i = 0; i < NumberShops; i++)
        //        {
        //            if (NPC.remainingDistance - 1 <= NPC.stoppingDistance)
        //            {
        //                NPC.destination = Shops[Random.Range(0, Shops.Length - 1)].position;
        //            }
        //        }
        //    }
    }
	

	void Update () {
        NavMeshAgent NPC = GetComponent<NavMeshAgent>();
        switch (CycleStage)
            {
            case 1:
                NPC.destination = Origin.position;
                if (Vector3.Distance(NPC.destination, NPC.transform.position) <= NPC.stoppingDistance + 1)
                {
                    CycleStage = CycleStage + 1;
                    TransportNumber = Random.Range(0, Transport.Length-1);
                    for (int i = 0; i < Outfits.Length; i++)
                    {
                        Outfits[i].SetActive(false);
                    }
                    Outfits[Random.Range(0, Outfits.Length - 1)].SetActive(true);
                }
                break;
            case 2:
                NPC.destination = Transport[TransportNumber].position;
                if (Vector3.Distance(NPC.destination, NPC.transform.position) <= NPC.stoppingDistance + 1)
                {
                    CycleStage = CycleStage + 1;
                    ShopNumber = Random.Range(0, Shops.Length - 1);
                    NumberVisits = Random.Range(2,5);
                }
                
                break;
            case 3:
                NPC.destination = Shops[ShopNumber].position;
                if (Vector3.Distance(NPC.destination, NPC.transform.position) <= NPC.stoppingDistance + 1)
                {
                    CurrentShop = ShopNumber;
                    while (CurrentShop == ShopNumber)
                    {
                        ShopNumber = Random.Range(0, Shops.Length - 1);
                    }
                    NumberVisits = NumberVisits - 1;
                    if (NumberVisits == 0)
                        CycleStage = 4;
                }
                
                break;
            case 4:
                NPC.destination = Transport[TransportNumber].position;
                if (Vector3.Distance(NPC.destination, NPC.transform.position) <= NPC.stoppingDistance + 1)
                {
                    CycleStage = 1;
                }
                
                break;
        }
    }    
}
