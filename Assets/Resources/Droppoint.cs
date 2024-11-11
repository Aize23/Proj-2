using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Droppoint : MonoBehaviour
{
    //Assignment
    public GameObject droppoint;
    public GameObject markerPrefab;
    public GameObject newMarker;

    //Checks for box entering the trigger. if it is, the box is teleported to the trigger and it's locked in place.
    //Also null checks for any extra markers.
    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Theres a thing here.");

        if (other.CompareTag("Box"))
        {
            Debug.Log("Yup, box.");
            other.transform.position = droppoint.transform.position;
            other.transform.GetComponent<Box>().Lock();
            if (newMarker != null)
            {
                Destroy(newMarker);
            }
            
        }

    }
        // Start is called before the first frame update
        // This is used to call the marker spawning the moment it is created.
        void Start()
    {
        SpawnMarker();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //This actually spawns the marker.
    void SpawnMarker()
    {
        newMarker = Instantiate(markerPrefab, droppoint.transform.position, Quaternion.identity);
    }
}
