using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    //Assignment
    public GameObject player;
    public GameObject entrance;
    public GameObject exit;

    // Start is called before the first frame update
    //This automatically sets the player to the intended starting position.
    void Start()
    {
      player.transform.position = entrance.transform.position;
    }

    // Update is called once per frame
    //This gives access to manually restart and the start menu's escape function for convenience.
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            Restart();
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log("returning to menu");
            SceneManager.LoadScene("Startscreen");
        }
    }
    

    public void Restart()
    {
        Debug.Log("Restarting!");
        string currentSceneName = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(currentSceneName);
    }
}
