using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript1 : MonoBehaviour
{
    //The speed of the ship going around
    public float forwardSpeed = 50f, strafeSpeed = 30f, hoverSpeed = 10f;

    //The activity of the ship's speed
    private float activeForwardSpeed, activeStrafeSpeed, activeHoverSpeed;
    private float forwardAcceleration = 15f, strafeAccleration = 10f; //, hoverAcceleration = 2f;

    //The look rate from the movement of the mouse.
    public float lookRateSpeed = 50f;
    private Vector2 lookInput, screenCenter, mouseDistance;

    CameraControl MainCamera;


    //The rolling or rotation of the ship
    private float rollInput;

    //The roll or rotation speed of the ship
    public float rollSpeed = 90f, rollAcceleration = 10f;

    // Start is called before the first frame update
    void Start()
    {
        MainCamera = Camera.main.GetComponent<CameraControl>();


        //Setting the limit of the screen when played
        screenCenter.x = Screen.width * 0.5f;
        screenCenter.y = Screen.height * 0.5f;
    }

    // Update is called once per frame
    void Update()
    {
        //The movement of the mouse and screen
        lookInput.x = Input.mousePosition.x;
        lookInput.y = Input.mousePosition.y;

        mouseDistance.x = (lookInput.x - screenCenter.x) / screenCenter.y;
        mouseDistance.y = (lookInput.y - screenCenter.y) / screenCenter.y;

        //Clamping the distance of the mouse on the screen
        mouseDistance = Vector2.ClampMagnitude(mouseDistance, 2f);

        //The Roll input function
        rollInput = Mathf.Lerp(rollInput, Input.GetAxisRaw("Roll"), rollAcceleration * Time.deltaTime);

        //Updating the rotation of the screen when the mouse moves
        transform.Rotate(-mouseDistance.y * lookRateSpeed * Time.deltaTime, mouseDistance.x * lookRateSpeed * Time.deltaTime, rollInput * rollSpeed * Time.deltaTime);

        //The active speed on the Vertical axis and Horizontal axis when the mouse and ship moves
        activeForwardSpeed = Mathf.Lerp(activeForwardSpeed, Input.GetAxisRaw("Vertical") * forwardSpeed, forwardAcceleration * Time.deltaTime);
        activeStrafeSpeed = Mathf.Lerp(activeStrafeSpeed, Input.GetAxisRaw("Horizontal") * strafeSpeed, strafeAccleration * Time.deltaTime);
        //activeHoverSpeed = Mathf.Lerp(activeHoverSpeed, Input.GetAxisRaw("Hover") * hoverSpeed * hoverAcceleration * Time.deltaTime);

        //Updating the ship's position when moving off
        transform.position += transform.forward * activeForwardSpeed * Time.deltaTime;
        transform.position += (transform.right * activeStrafeSpeed * Time.deltaTime) + (transform.up * activeHoverSpeed * Time.deltaTime);
    }

    //To detect and destroy the gameobject, the ship collides with
    private void OnTriggerEnter(Collider collider)
    {
        //The if statement for the ship to decide if its true or false on collision with the stated tag
        if(collider.tag == "CoinToCollect")
        {   
            Destroy(collider.gameObject);
        }
    }
}
