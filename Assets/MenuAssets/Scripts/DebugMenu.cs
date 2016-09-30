using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DebugMenu : MonoBehaviour {

    public Button Movementbtn;
    public Button Animationbtn;
    public Button Insidebtn;
    public Button Cutscenebtn;
    public Button Outsidebtn;

    // Use this for initialization
    void Start () {
        Movementbtn.onClick.AddListener(() =>
        {
            SceneManager.LoadScene("Movement");
        });
        Animationbtn.onClick.AddListener(() =>
        {
            SceneManager.LoadScene("Animation");
        });
        Insidebtn.onClick.AddListener(() =>
        {
            SceneManager.LoadScene("Inside");
        });
        Cutscenebtn.onClick.AddListener(() =>
        {
            SceneManager.LoadScene("Cutscene");
        });
        Outsidebtn.onClick.AddListener(() =>
        {
            SceneManager.LoadScene("Outside");
        });
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
