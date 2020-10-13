using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

//Parent class containing basic utilities for game objects


public class Entity : MonoBehaviour
{
    //variables for dialog activator.  Doesn't do anything if lines are set to 0 in inspector
    //holds whether or not the entity is a person with a nameplate, false means there will be no nameplate
    public bool isPerson = true;
    //holds lines to be displayed by the entity
    public string[] lines;
    // check if player is in range of talking
    bool canActivate;


    //variables for locking movement past the tilemap bounds, method on line 23
    Tilemap theMap;
    Vector3 bottomLeftLimit;
    Vector3 topRightLimit;
    //method to prevent entities from moving past the tilemap bounds
    public void setClamp(float toAddx, float toAddy)
    {
        // gets the grid from the map and grabs its first child tilemap
        theMap = GameObject.Find("Grid").GetComponentInChildren(typeof(Tilemap)) as Tilemap;
        //Sets variable to hold the bottom left and top right of the tilemap
        bottomLeftLimit = theMap.localBounds.min;
        topRightLimit = theMap.localBounds.max;
        //adjust limit by the parameters passed from the object so half the object doesn't go out of the bounds
        bottomLeftLimit += new Vector3(toAddx, toAddy, 0);
        topRightLimit += new Vector3(-toAddx, -toAddy, 0);
        //clamp the objects position between the limits, preventing it from passing those bounds
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, bottomLeftLimit.x, topRightLimit.x), Mathf.Clamp(transform.position.y, bottomLeftLimit.y, topRightLimit.y), transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        //dialog code: calls the function that displays dialog if character is in range, button is released, and there isn't a dialog box on screen,  last part of the check keeps the method from being called repeatedly
        if (canActivate && Input.GetButtonDown("Fire1") && !DialogManager.instance.dialogBox.activeInHierarchy && lines.Length > 0)
        {
            DialogManager.instance.showDialog(lines, isPerson);
        }
    }

    //Set it so character can interact with the object when in range
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            canActivate = true;
        }
    }
    //Set it so character cannot interact with object once they've left the range
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            canActivate = false;
        }
    }

}
