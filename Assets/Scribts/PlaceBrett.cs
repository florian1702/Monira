using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceBrett : MonoBehaviour
{
    bool insidePlacingarea;

    Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        insidePlacingarea = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(insidePlacingarea && Input.GetKeyUp(KeyCode.E))
        {
            anim.enabled = true;
            Debug.Log("Placing board");
            
        }
    }

     void OnTriggerEnter(Collider col) {
        if(col.gameObject.tag == "PlacingArea")
        {
            insidePlacingarea = !insidePlacingarea;
            Debug.Log("Inside Placingarea");
        }    
    }

    void OnTriggerExit(Collider col) {
        if(col.gameObject.tag == "PlacingArea")
        {
            insidePlacingarea = !insidePlacingarea;
            Debug.Log("Outside Placingarea");
        }  
    }

    void PauseAnimation()
    {
        anim.enabled = false;
    }

}
