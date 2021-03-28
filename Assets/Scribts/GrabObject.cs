using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabObject : MonoBehaviour
{

    [SerializeField] Transform Dest;
    [SerializeField] float Range = 1f;

    bool insideGrab;
    // Start is called before the first frame update
    void Start()
    {
        insideGrab = false;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 distanceToPlayer = GameObject.Find("Player").transform.position - transform.position;

        if(distanceToPlayer.magnitude <= Range && !insideGrab)
        {
            insideGrab = !insideGrab;
            Debug.Log("Inside grabbing area");
        }
        
        

        if(Input.GetKeyDown(KeyCode.E) && distanceToPlayer.magnitude <= Range)
        {        
            GetComponent<Rigidbody>().useGravity = false;
            this.transform.position = Dest.position;
            this.transform.parent = GameObject.Find("Destination").transform;
            if(gameObject.tag == "Brett")
            {
                transform.Rotate(0,90,0);
            }
            Debug.Log("Grabbing");
        }
        else if(Input.GetKeyUp(KeyCode.E))
        {
            this.transform.parent = null;
            GetComponent<Rigidbody>().useGravity = true;
            Debug.Log("Let go");
        }
    }
}
