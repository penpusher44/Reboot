using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Playerv3 : MonoBehaviour {

    //CAMERA
    public int Sensitivity;
    public GameObject Head;
    
    //FLASHLIGHT
    public GameObject Flashlight;
    public bool LightOn;
    public GameObject LeftArm;
    public GameObject LeftWrist;

    //MOVEMENT
    public GameObject Player;
    public float speed;
    public float jumpSpeed;
    public float gravity;
    public float sprint;
    private Vector3 moveDirection = Vector3.zero;

    //STAMINA
    public float Stamina;
    public GameObject StaminaMarker;
    public GameObject StaminaText;
    bool StaminaDrain = false;

    //ABILITIES


    void Update () {

        //CAMERA
        if (Input.GetAxis("Mouse Y") < 0)
        {
            Head.transform.Rotate(0, Sensitivity * Time.deltaTime, 0);
        }
        if (Input.GetAxis("Mouse Y") > 0)
        {
            Head.transform.Rotate(0, -Sensitivity  * Time.deltaTime, 0);
        }
        if (Input.GetAxis("Mouse X") < 0)
        {
            Player.transform.Rotate(0, -Sensitivity  * Time.deltaTime, 0);
        }
        if (Input.GetAxis("Mouse X") > 0)
        {
            Player.transform.Rotate(0, Sensitivity  * Time.deltaTime, 0);
        }

        //Flashlight
        if (Input.GetKey(KeyCode.Mouse0))
        {
            if (LightOn == false)
            {
                Flashlight.SetActive(true);
                LightOn = true;

            }
            else
            {
                Flashlight.SetActive(false);
                LightOn = false;
            }
        }
        if (LightOn == true)
        {
            if (Input.GetAxis("Mouse Y") < 0)
            {
                LeftArm.transform.Rotate(0, -Sensitivity  * Time.deltaTime, 0);
            }
            if (Input.GetAxis("Mouse Y") > 0)
            {
                LeftArm.transform.Rotate(0, Sensitivity  * Time.deltaTime, 0);
            }
        }
        else
        {
            if (Input.GetAxis("Mouse Y") < 0)
            {
                LeftArm.transform.Rotate(0, Sensitivity * Time.deltaTime, 0);
            }
            if (Input.GetAxis("Mouse Y") > 0)
            {
                LeftArm.transform.Rotate(0, -Sensitivity  * Time.deltaTime, 0);
            }
            if (Input.GetAxis("Mouse Y") < 0)
            {
                LeftWrist.transform.Rotate(-Sensitivity  * Time.deltaTime, Sensitivity * Time.deltaTime, 0);
            }
            if (Input.GetAxis("Mouse Y") > 0)
            {
                LeftWrist.transform.Rotate(Sensitivity * Time.deltaTime, -Sensitivity * Time.deltaTime, 0);
            }
        }      

        //MOVEMENT
        CharacterController controller = GetComponent<CharacterController>();
        if (controller.isGrounded)
        {
            moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            moveDirection = transform.TransformDirection(moveDirection);
            moveDirection *= speed;

            if (System.Convert.ToInt16(Stamina) > 0)
            {
                if (Input.GetKey(KeyCode.LeftShift))
                {
                    moveDirection *= sprint;
                    Stamina = Stamina - 0.1f;
                    StaminaDrain = true;
                }
            }

            //Jumping
            if (Input.GetButton("Jump"))
                moveDirection.y = jumpSpeed;

        }
        //Applying gravity to the controller
        moveDirection.y -= gravity * Time.deltaTime;
        //Making the character move
        controller.Move(moveDirection * Time.deltaTime);

        //ABILITIES

        //STAMINA
        if (controller.velocity.sqrMagnitude == 0)
        {
            if (StaminaDrain == false)
            {
                if (Stamina < 100)
                {
                    Stamina = Stamina + 0.2f;
                }
            }
        }
        StaminaDrain = false;

        RectTransform Marker = StaminaMarker.GetComponent<RectTransform>();
        Marker.localPosition = new Vector3(Stamina - 50, 0, 0);

        Text Text = StaminaText.GetComponent<Text>();
        Text.text = System.Convert.ToString(System.Convert.ToInt16(Stamina));

        

    }
}
