using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Marker : MonoBehaviour
{


    // Start is called before the first frame update
    void Start()
    {
        transform.position += new Vector3(0, 5, 0);
    }

    // Update is called once per frame
    //Needed a random so...
    void Update()
    {
        int rotateSpeed = Random.Range(0, 3);
        transform.Rotate(rotateSpeed, 1, rotateSpeed);

    }

}