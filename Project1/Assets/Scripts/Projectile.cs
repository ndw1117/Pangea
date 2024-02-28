using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Projectile : MonoBehaviour
{
    [SerializeField]
    float speed;

    Vector3 direction = Vector3.left;

    Vector3 velocity = Vector3.zero;

    [SerializeField]
    Vector3 projectilePosition = Vector3.zero;

    Camera cameraObject;

    float totalCamHeight;

    float totalCamWidth;

    // Start is called before the first frame update
    void Start()
    {
        projectilePosition = transform.position;

        cameraObject = Camera.main;

        totalCamHeight = cameraObject.orthographicSize * 2f;

        totalCamWidth = totalCamHeight * cameraObject.aspect;
    }

    // Update is called once per frame
    void Update()
    {
        velocity = direction * speed * Time.deltaTime;

        projectilePosition += velocity;

        transform.position = projectilePosition;


    }

    //Checks to see if projectile is out of the camera view. Should be called by an update function in a master script
    public bool isOut()
    {
        if (projectilePosition.x > (totalCamWidth / 2))
        {
            return true;
        }
        else if (projectilePosition.x < -(totalCamWidth / 2))
        {
            return true;
        }

        if (projectilePosition.y > (totalCamHeight / 2))
        {
            return true;
        }
        else if (projectilePosition.y < -(totalCamHeight / 2))
        {
            return true;
        }

        return false;
    }
}
