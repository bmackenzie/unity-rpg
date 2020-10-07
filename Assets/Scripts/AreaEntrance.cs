using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.Tilemaps;

public class AreaEntrance : MonoBehaviour
{

    public string transitionName;
    // Start is called before the first frame update
    void Start()
    {
        if(transitionName == PlayerController.instance.areaTransitionName)
        {
            PlayerController.instance.transform.position = transform.position;
        }

        //PlayerController.instance.theMap = GameObject.Find("Grid").GetComponent<Tilemap>(); 
           // GameObject.FindWithTag("mainTile");
    }

    // Update is called once per frame
    void Update()
    {

    }
}
