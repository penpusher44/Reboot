using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Abilities : MonoBehaviour {
    public int Stamina;
    public GameObject StaminaMarker;
    public GameObject StaminaText;

    void Start() {
        //StaminaMarker.GetComponent<RectTransform>;
    }
	void Update () {
        RectTransform Marker = StaminaMarker.GetComponent<RectTransform>();
        Marker.localPosition = new Vector3(Stamina - 50, 0, 0);

        Text Text = StaminaText.GetComponent<Text>();
        Text.text = System.Convert.ToString(Stamina);

        //if (Marker.localPosition.x + 50 < Stamina)
        //{
        //    Marker.transform.Translate(1, 0, 0);
        //}
        //if (Marker.localPosition.x + 50 > Stamina)
        //{
        //    Marker.transform.Translate(-1, 0, 0);
        //}

    }
}
