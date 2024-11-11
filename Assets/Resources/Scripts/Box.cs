using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour
{
    //Assignment
    public GameObject box;
    Rigidbody boxbody;
    public AudioSource intAudio;

    //The box prepares to access it's own rigidbody
    void Start()
    {
        boxbody = GetComponent<Rigidbody>();
    }

    //This locks all rotational and positional constraints in the rigidbody, allowing the player to use it as a platform.
    public void Lock()
    {
        Debug.Log("Box Locked");
        intAudio.Play();
        boxbody.constraints = RigidbodyConstraints.FreezeAll;
    }

    // Update is called once per frame
    void Update()
    {
        
    }


}
