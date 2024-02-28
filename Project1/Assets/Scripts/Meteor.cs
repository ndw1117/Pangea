using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meteor : MonoBehaviour
{
    [SerializeField]
    float speed;

    Vector3 direction = new Vector3((float)0.5, -1, 0);

    Vector3 velocity = Vector3.zero;

    [SerializeField]
    Vector3 meteorPosition = Vector3.zero;

    Camera cameraObject;

    float totalCamHeight;

    float totalCamWidth;

    // Start is called before the first frame update
    void Start()
    {
        meteorPosition = transform.position;

        cameraObject = Camera.main;

        totalCamHeight = cameraObject.orthographicSize * 2f;

        totalCamWidth = totalCamHeight * cameraObject.aspect;
    }

    // Update is called once per frame
    void Update()
    {
        velocity = direction * speed * Time.deltaTime;

        meteorPosition += velocity;

        transform.position = meteorPosition;
    }

    //Checks to see if meteor is out of the camera view. Should be called by an update function in a master script
    public bool isOut()
    {
        //Only checks negative y because we spawn meteors above screen, and don't mind if it is partially off the screen horizontally
 
        if (meteorPosition.y < (-(totalCamHeight / 2) - 2))
        {
            return true;
        }

        return false;
    }
}
