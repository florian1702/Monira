using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shutcontianer : MonoBehaviour
{
    Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision other) 
    {

        if(other.gameObject.tag == "Wall")
        {
            anim.enabled = true;
        }
        
    }

    void PauseAnimation()
    {
        anim.enabled = false;
    }
}
