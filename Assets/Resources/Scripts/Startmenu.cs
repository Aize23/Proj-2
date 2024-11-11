using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Startmenu : MonoBehaviour
{
    //Assignment
    public AudioSource intAudio;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //This quits the game since pressing escape usually returns you to this screen.
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            intAudio.Play();
            Debug.Log("Quitting Game");
            Application.Quit();
        }
    }

    //This starts the game by always loading into the first lv.
    public void OnButtonClick()
    {
        intAudio.Play();
        Debug.Log("Started");
        SceneManager.LoadScene("SetupTest");
    }
}
