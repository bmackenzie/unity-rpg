using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
//Parent class containing basic utilities for game objects


public class Entity : MonoBehaviour
{
    //public GameObject grid;
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

}
