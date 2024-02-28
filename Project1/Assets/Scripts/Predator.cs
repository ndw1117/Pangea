using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Predator : MonoBehaviour
{
    [SerializeField]
    float speed;

    Vector3 direction = new Vector3(1, 0, 0);

    Vector3 velocity = Vector3.zero;

    [SerializeField]
    Vector3 predatorPosition = Vector3.zero;

    Camera cameraObject;

    float totalCamHeight;

    float totalCamWidth;

    // Start is called before the first frame update
    void Start()
    {
        speed = Random.Range(5f, 10f);

        predatorPosition = transform.position;

        cameraObject = Camera.main;

        totalCamHeight = cameraObject.orthographicSize * 2f;

        totalCamWidth = totalCamHeight * cameraObject.aspect;
    }

    // Update is called once per frame
    void Update()
    {
        velocity = direction * speed * Time.deltaTime;

        predatorPosition += velocity;

        transform.position = predatorPosition;
    }

    //Checks to see if predator is out of the camera view. Should be called by an update function in a master script
    public bool isOut()
    {
        //Only checks positive x because we spawn predators to left of screen, and don't mind if it is partially off the screen vertically

        if (predatorPosition.x > (totalCamWidth / 2) + 2)
        {
            return true;
        }

        return false;
    }
}
