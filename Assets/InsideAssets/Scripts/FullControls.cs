using UnityEngine;


public class FullControls : MonoBehaviour {
    public int Sensitivity;
    public GameObject Head;
    public GameObject Capsule;

    public int JumpStrength;
    public bool CanJump;
    public float WalkSpeed;
    public float RunSpeed;
    float CurrentSpeed;

    void Update () {
        //Camera
        if (Input.GetAxis("Mouse Y") < 0 )
        {
            Debug.Log("why");
            Head.transform.Rotate(0, Sensitivity, 0);
        }
        if (Input.GetAxis("Mouse Y") > 0 )
        {
            Head.transform.Rotate(0, -Sensitivity, 0);
        }
        if (Input.GetAxis("Mouse X") < 0)
        {
            Capsule.transform.Rotate(0, -Sensitivity, 0);
        }
        if (Input.GetAxis("Mouse X") > 0)
        {
            Capsule.transform.Rotate(0, Sensitivity, 0);
        }
        //Movement
        if (Input.GetKey(KeyCode.LeftShift))
        {
            CurrentSpeed = RunSpeed;
        }
        else
        {
            CurrentSpeed = WalkSpeed;
        }
        if (Input.GetKey(KeyCode.A))
        {
            Capsule.transform.Translate(-1 * CurrentSpeed, 0, 0, gameObject.transform);
        }

        if (Input.GetKey(KeyCode.W))
        {
            Capsule.transform.Translate(0, 0, CurrentSpeed, gameObject.transform);
        }

        if (Input.GetKey(KeyCode.S))
        {
            Capsule.transform.Translate(0, 0, -1 * CurrentSpeed, gameObject.transform);
        }

        if (Input.GetKey(KeyCode.D))
        {
            Capsule.transform.Translate(CurrentSpeed, 0, 0, gameObject.transform);
        }
        if (Input.GetKey(KeyCode.Space))
        {
            if (CanJump == true)
            {
                Capsule.transform.Translate(0, Time.deltaTime * JumpStrength, 0, gameObject.transform);
                CanJump = false;
            }
        }
    }
}
