using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour {
    public Button Exitbtn;
    public Button PlayGamebtn;

    // Use this for initialization
    void Start () {
        Exitbtn.onClick.AddListener(() =>
        {
            Application.Quit();
        });
        PlayGamebtn.onClick.AddListener(() =>
        {
            SceneManager.LoadScene("InsideLevel");
        });
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
