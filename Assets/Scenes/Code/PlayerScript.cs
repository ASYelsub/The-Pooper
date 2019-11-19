using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerScript : MonoBehaviour
{

    CharacterController characterController;

    float speed = 5f;
    float maxSpeed = 5f;
    float jumpSpeed = 2.0f;
    float gravity = 5.0f;

    private Vector3 moveDirection = Vector3.zero;

    float playerHeight;

    float xSpeed;
    float zSpeed;

    //Camera
    float tilt = 0;
    float heading = 0;
    Transform Cam;
    Vector3 camF;
    Vector3 camR;
    Vector3 camU;


    //Crosshair
    public Texture2D crosshair;
    public Rect position;

    //playerbody and crouch
    public Transform playerbody;
    bool ceilingAbove;

    //bam effect
    //public GameObject bam;

    public Image hand;
    bool upbob = false;

    //AUDIO
    AudioSource AS;

    //Minimap
    public static int Xpos;
    public static int Zpos;

    //ITEMS
    bool haveKey;

    //Shop
    Vector3 ShopPos;

    void Start()
    {
        //mover = GetComponent<CharacterController>(); // allows us to access the character controller through the variable mover  
        characterController = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
        Cam = Camera.main.transform;
        //Debug.Log(Cam.name);
    }

    void Update()
    {
        Xpos = Mathf.RoundToInt(transform.position.x);
        Zpos = Mathf.RoundToInt(transform.position.z);

        CalcCam();

        CrosshairPosition();

        //Crouch();

        //SpeedAcceleration();
        PlayerMove();
        characterController.Move(moveDirection * Time.deltaTime);

        //HandBob();
        //Debug.Log("X: " + Mathf.RoundToInt(transform.position.x) + " Z: " + Mathf.RoundToInt(transform.position.z));
    }

    void HandBob()
    {
        if (Mathf.RoundToInt(moveDirection.magnitude) > 0)
        {
            if (hand.rectTransform.localPosition.y > 0)
            {
                upbob = false;
            }
            else if (hand.rectTransform.localPosition.y < -40)
            {
                upbob = true;
            }

            if (upbob == true)
            {
                hand.rectTransform.localPosition += new Vector3(0, 1, 0) * Time.deltaTime * 200;
            }
            else
            {
                hand.rectTransform.localPosition += new Vector3(0, -1, 0) * Time.deltaTime * 200;
            }
        }
        else
        {
            hand.rectTransform.localPosition = Vector3.Lerp(hand.rectTransform.localPosition, new Vector3(160, 0, 0), Time.deltaTime * 6);
        }
    }

    void Crouch()
    {

        if (Input.GetKey(KeyCode.LeftControl))
        {
            playerHeight = Mathf.Lerp(playerHeight, 1.5f, Time.deltaTime * 10);
            characterController.center = Vector3.Lerp(characterController.center, new Vector3(0, -.3f, 0), Time.deltaTime * 10);
            playerbody.localPosition = Vector3.Lerp(playerbody.localPosition, new Vector3(0, -.3f, 0), Time.deltaTime * 10);
        }
        else
        {
            if (!ceilingAbove)
            {
                playerHeight = Mathf.Lerp(playerHeight, 2f, Time.deltaTime * 10);
                characterController.center = Vector3.Lerp(characterController.center, new Vector3(0, 0, 0), Time.deltaTime * 10);
                playerbody.localPosition = Vector3.Lerp(playerbody.localPosition, new Vector3(0, 0, 0), Time.deltaTime * 10);
            }
        }


        RaycastHit tophit;
        if (Physics.Raycast(playerbody.position, Vector3.up, out tophit, playerbody.localScale.y * 2))
        {
            //ceilingAbove = true;
        }
        else
        {
            ceilingAbove = false;
        }

        //Debug.Log(ceilingAbove);

        characterController.height = playerHeight;
        playerbody.localScale = new Vector3(1, playerHeight / 2, 1);
    }

    void CrosshairPosition()
    {

        position = new Rect((Screen.width - crosshair.width) / 2, (Screen.height - crosshair.height) / 2, crosshair.width, crosshair.height);

    }

    void CalcCam()
    {


        camF = Cam.forward; //camF is the forward direction of the camera or the relative Z axis 

        camR = Cam.right; //camR is the relative X axis

        camU = Cam.up; //camU is the relative Y axis, use this for aiming 

        camF.y = 0;
        camR.y = 0;

        camU.z = 0;

        camU.x = 0;

        camF = camF.normalized;
        camR = camR.normalized;
        camU = camU.normalized;


        //Cam.transform.rotation = Quaternion.Euler(tilt, heading, 0);

        //tilt -= Input.GetAxis("Mouse Y") * Time.deltaTime * 180;
        //heading += Input.GetAxis("Mouse X") * Time.deltaTime * 180;
        //tilt = Mathf.Clamp(tilt, -89, 89);

    }

    void SpeedAcceleration()
    {
        if (Input.GetButton("Horizontal") || Input.GetButton("Vertical"))
        {
            speed = Mathf.Lerp(speed, maxSpeed, Time.deltaTime * 5);
        }
        else if (!(Input.GetButton("Horizontal") && Input.GetButton("Vertical")))
        {
            speed = Mathf.Lerp(speed, 0, Time.deltaTime * 7);
        }
    }

    void PlayerMove()
    {
        if (characterController.isGrounded)
        {
            // We are grounded, so recalculate
            // move direction directly from axes

            if (Input.GetButton("Horizontal"))
            {
                xSpeed = Mathf.Lerp(xSpeed, Input.GetAxis("Horizontal"), Time.deltaTime * 8);
            }
            else
            {
                xSpeed = xSpeed = Mathf.Lerp(xSpeed, 0, Time.deltaTime * 8);
            }
            if (Input.GetButton("Vertical"))
            {
                zSpeed = Mathf.Lerp(zSpeed, Input.GetAxis("Vertical"), Time.deltaTime * 8);
            }
            else
            {
                zSpeed = Mathf.Lerp(zSpeed, 0, Time.deltaTime * 8);
            }

            //moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0.0f, Input.GetAxis("Vertical"));
            moveDirection = new Vector3(xSpeed, 0.0f, zSpeed);
            moveDirection = Vector3.ClampMagnitude(moveDirection, 1);
            moveDirection *= speed;
            moveDirection = (camF * moveDirection.z + camR * moveDirection.x + camU * moveDirection.y);

            if (Input.GetButton("Jump") && !ceilingAbove)
            {
                //moveDirection.y = jumpSpeed; // removed jump
            }
        }
        else // if in the air
        {
            moveDirection.x = Input.GetAxis("Horizontal");
            moveDirection.z = Input.GetAxis("Vertical");

            moveDirection.x = Mathf.Clamp(moveDirection.x, -1, 1);
            moveDirection.z = Mathf.Clamp(moveDirection.z, -1, 1);

            moveDirection.x *= speed;
            moveDirection.z *= speed;

            moveDirection = (camF * moveDirection.z + camR * moveDirection.x + camU * moveDirection.y);
        }



        moveDirection.y -= gravity * Time.deltaTime;

        // Move the controller
    }

    void OnGUI()
    {
        //GUI.DrawTexture(position, crosshair);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Key")
        {
            Destroy(other.gameObject);
            haveKey = true;
        }

        if (other.tag == "shopDoor")
        {
            ShopPos = new Vector3(Mathf.RoundToInt(transform.position.x), transform.position.y, Mathf.RoundToInt(transform.position.z));
            characterController.enabled = false;
            transform.position = new Vector3(0, 60.7f, 0);
            characterController.enabled = true;
        }
        if (other.tag == "DoorBack")
        {
            characterController.enabled = false;
            transform.position = ShopPos;
            characterController.enabled = true;
        }
    }
}
