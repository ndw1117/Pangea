using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteInfo : MonoBehaviour
{
    public float radius;

    /*[SerializeField]
    Vector2 boxSize;*/

    public Bounds bounds;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //bounds = new Bounds(transform.position, boxSize);              <- Used to set box size manually and then calculate bounds
        bounds = gameObject.GetComponent<SpriteRenderer>().bounds;     //<- Can be used to set bounds if you're satisfied with the bounds of the sprite
        //Debug.Log("Center " + bounds.center + " Min " + bounds.min + " Max " + bounds.max + " Extents " + bounds.extents + " Size " + bounds.size);


    }

    private void OnDrawGizmos() // This method works in the editor without the game being run. Make sure it will compile without the Start method happening!
    {
        Gizmos.color = Color.green;

        Gizmos.DrawWireSphere(transform.position, radius);

    }

}
