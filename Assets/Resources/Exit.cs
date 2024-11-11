using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Exit : MonoBehaviour
{

    public GameObject resetBarrier;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //This checks the reset barrier to see if the player is in the fail state, if so, they cannot win by hitting the tail of the exit marker
    public void OnTriggerEnter(Collider other)
    {
        Debug.Log("A thing has won!");

        if (other.CompareTag("Player"))
        {
            if (resetBarrier.GetComponent<ResetBarrier>().canWin == true)
            {
                Debug.Log("You have won!");
                Progress();
            }
        }
    }

    //This simply moves to the next scene in the index
    public void Progress()
    {
        int nextSceneIndex = SceneManager.GetActiveScene().buildIndex;

        SceneManager.LoadScene(nextSceneIndex += 1);
    }
}
