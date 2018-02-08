using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour {

    private Animator animator;


    // Use this for initialization
    void Start () {
        animator = GetComponent<Animator>();
        animator.speed = 3;
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("TriggerIn");
        if (other.gameObject.name == "ThirdPersonController")  //c.gameObject.name
        {
            animator.SetBool("isOpen", true);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        Debug.Log("TriggerOut");
        if (other.gameObject.name == "ThirdPersonController")
        {
            animator.SetBool("isOpen", false);
        }
    }
}
