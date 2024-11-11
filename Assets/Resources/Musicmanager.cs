using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Musicmanager : MonoBehaviour
{
    //Assignment
    public static Musicmanager musicbg;

    //This allows an audio track to play across scenes.
    //The Null check here automatically gets rid of the extra object created every scene after the first, avoiding multiple audio sources, and therefore multiple overlapping tracks
    private void Awake()
    {
        if (musicbg != null)
        {
            Destroy(gameObject);
        }
        else
        {
            musicbg = this;
        }
        DontDestroyOnLoad(this.gameObject);
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
