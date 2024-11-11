using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResetBarrier : MonoBehaviour
{
    //Variables
    public bool canWin = true;


    //Upon colliding, it loads the fail screen and locks the player from winning as they now no longer meet the requirements of the exit script.
    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("uh oh, something fell");

        if (collision.gameObject.CompareTag("Player"))
        {
            canWin = false;
            Debug.Log("uh oh, you fell");
            SceneManager.LoadScene("Fail Overlay", LoadSceneMode.Additive);
        }
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
