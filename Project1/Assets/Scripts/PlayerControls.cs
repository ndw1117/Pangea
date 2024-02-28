using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControls : MonoBehaviour
{
    [SerializeField]
    Manager manager;

    [SerializeField]
    GameObject projectile;

    [SerializeField]
    float speed;

    Vector3 direction = Vector3.zero;

    Vector3 velocity = Vector3.zero;

    [SerializeField]
    Vector3 vehiclePosition = Vector3.zero;

    Camera cameraObject;

    float totalCamHeight;

    float totalCamWidth;

    //Responsible for a delay in the spawning of Projectiles (NOTE: This is used a bit differently than the spawnTimer in Manager for meteors!)
    float spawnTimer = 0f;

    // Start is called before the first frame update
    void Start()
    {
        vehiclePosition = transform.position;

        cameraObject = Camera.main;

        totalCamHeight = cameraObject.orthographicSize * 2f;

        totalCamWidth = totalCamHeight * cameraObject.aspect;

        spawnTimer = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        //getting mouse position
        Vector3 mousePosition = cameraObject.ScreenToWorldPoint(Mouse.current.position.ReadValue());
        mousePosition.z = 0;
        vehiclePosition.z = 0;

        //if the player sprite is at the mouse position, don't move
        //(Needed to use a threshold of .03 because otherwise it missed
        if (Vector3.Distance(mousePosition, vehiclePosition) < .03)
        {
            direction = Vector3.zero;
        }

        velocity = direction * speed * Time.deltaTime;

        vehiclePosition += velocity;

        // Check for wrapping here (if the new position is out of bounds, alter it before applying it to the transform)

        if (vehiclePosition.x > (totalCamWidth / 2))
        {
            vehiclePosition.x = (totalCamWidth / 2);
        }
        else if (vehiclePosition.x < -(totalCamWidth / 2))
        {
            vehiclePosition.x = -(totalCamWidth / 2);
        }

        if (vehiclePosition.y > (totalCamHeight / 2))
        {
            vehiclePosition.y = (totalCamHeight / 2);
        }
        else if (vehiclePosition.y < -(totalCamHeight / 2))
        {
            vehiclePosition.y = -(totalCamHeight / 2);
        }

        transform.position = vehiclePosition;

        //Decrements spawnTimer each update
        if (spawnTimer > 0f)
        {
            spawnTimer -= Time.deltaTime;
        }

    }

    public void OnPlayerMove(InputAction.CallbackContext context)
    {
        Vector3 mousePosition = cameraObject.ScreenToWorldPoint(context.ReadValue<Vector2>());

        //if the player sprite is at the mouse position, don't move
        if (mousePosition == vehiclePosition)
        {
            direction = Vector3.zero;
        }
        else
        {
            direction = (mousePosition - vehiclePosition).normalized;
        }
        

        direction.z = 0;
      
    }

    public void OnFire(InputAction.CallbackContext context)
    {
        //This handles the delay in spawning Projectiles (also in update method)

        if (spawnTimer <= 0f)
        {
            manager.AddProjectile(Instantiate(projectile, new Vector3(vehiclePosition.x - 1, (float)(vehiclePosition.y + .71), 0), Quaternion.identity));
            //Must wait for update to decrement spawnTimer over .3 seconds before this method does anything again (prevents multiple projectiles on 1 click)
            spawnTimer = 0.3f;
        }
        
    }
}
