using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever : MonoBehaviour
{
    //Assignment/Variables

    public AudioSource intAudio;
    bool inTrigger = false;

    // Start is called before the first frame update
    void Start()
    {
        foreach (Transform child in this.transform)
        {
            child.gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    //Manages the players ability to interact with a lever only when within range
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (inTrigger == true)
            {
                intAudio.Play();
                foreach (Transform child in this.transform)
                {
                    Debug.Log("Lever Pulled");
                    child.gameObject.SetActive(true);
                }
            }
        }
    }
    

    //These determine if the player is in range
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            inTrigger = true;
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            inTrigger = false;
        }
    }
}
