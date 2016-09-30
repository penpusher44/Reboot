using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Exit : MonoBehaviour {

    public Button ExitToMenu;

	// Use this for initialization
	void Start () {
        ExitToMenu.onClick.AddListener(() =>
        {
            SceneManager.LoadScene("MainMenu");
        });
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
