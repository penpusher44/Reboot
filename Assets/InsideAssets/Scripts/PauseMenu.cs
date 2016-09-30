using UnityEngine;
using System.Collections;


public class PauseMenu : MonoBehaviour {

    public GameObject MovementScript;
    public GameObject Pause;
    public GameObject UI;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.Escape))
        { 
            MovementScript.GetComponent<Playerv3>().enabled = false;
            Pause.SetActive(true);
            UI.SetActive(false);
        }
        if (Input.GetKey(KeyCode.Backspace))
        {
            MovementScript.GetComponent<Playerv3>().enabled = true;
            Pause.SetActive(false);
            UI.SetActive(true);
        }

    }
}
