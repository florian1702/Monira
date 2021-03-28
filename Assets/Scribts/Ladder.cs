using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ladder : MonoBehaviour
{
    bool insideLadder;
    public float ladderHeight = 3.3f;

    [SerializeField] CharacterController Controller;
    [SerializeField] float climbingSpeed = 5f;
    // Start is called before the first frame update
    void Start()
    {
        insideLadder = false;
    }

    // Update is called once per frame
    void Update()
    {

        if(insideLadder && Input.GetKey(KeyCode.E))
        {
            Debug.Log("climbing");
            Controller.Move(Vector3.up * climbingSpeed * Time.deltaTime);
        }
    }

    void OnTriggerEnter(Collider col) {
        if(col.gameObject.tag == "Ladder")
        {
            insideLadder = !insideLadder;
            Debug.Log("Inside ladder Area");
        }    
    }

    void OnTriggerExit(Collider col) {
        if(col.gameObject.tag == "Ladder")
        {
            insideLadder = !insideLadder;
            Debug.Log("Outside ladder Area");
        }  
    }
}
