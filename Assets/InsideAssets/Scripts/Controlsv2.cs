using UnityEngine;


public class Controlsv2 : MonoBehaviour {
    public int Sensitivity;
    public GameObject Head;
    public GameObject Player;

    public GameObject Flashlight;
    public bool LightOn;
    public GameObject LeftArm;
    public GameObject LeftWrist;

    public float speed;
    public float jumpSpeed;
    public float gravity;
    public float sprint;
    private Vector3 moveDirection = Vector3.zero;

    void Update () {
        //Camera
        if (Input.GetAxis("Mouse Y") < 0 )
        {
            Head.transform.Rotate(0, Sensitivity * Time.deltaTime, 0);
        }
        if (Input.GetAxis("Mouse Y") > 0 )
        {
            Head.transform.Rotate(0, -Sensitivity * Time.deltaTime, 0);
        }
        if (Input.GetAxis("Mouse X") < 0)
        {
            Player.transform.Rotate(0, -Sensitivity * Time.deltaTime, 0);
        }
        if (Input.GetAxis("Mouse X") > 0)
        {
            Player.transform.Rotate(0, Sensitivity * Time.deltaTime, 0);
        }

        //Movement
        CharacterController controller = GetComponent<CharacterController>();
        if (controller.isGrounded)
        {
            moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            moveDirection = transform.TransformDirection(moveDirection);
            moveDirection *= speed;
            
            if(Input.GetKey(KeyCode.LeftShift))
            {
                moveDirection *= sprint;
            }

            //Jumping
            if (Input.GetButton("Jump"))
                moveDirection.y = jumpSpeed;

        }
        //Applying gravity to the controller
        moveDirection.y -= gravity * Time.deltaTime;
        //Making the character move
        controller.Move(moveDirection * Time.deltaTime);

        //Flashlight
        if(Input.GetKey(KeyCode.Mouse0))
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
                LeftArm.transform.Rotate(0, -Sensitivity * Time.deltaTime, 0);
            }
            if (Input.GetAxis("Mouse Y") > 0)
            {
                LeftArm.transform.Rotate(0, Sensitivity * Time.deltaTime, 0);
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
                LeftArm.transform.Rotate(0, -Sensitivity * Time.deltaTime, 0);
            }
            if (Input.GetAxis("Mouse Y") < 0)
            {
                LeftWrist.transform.Rotate( -Sensitivity * Time.deltaTime, Sensitivity * Time.deltaTime, 0);
            }
            if (Input.GetAxis("Mouse Y") > 0)
            {
                LeftWrist.transform.Rotate(Sensitivity * Time.deltaTime, -Sensitivity * Time.deltaTime, 0);
            }
        }
    }
}
