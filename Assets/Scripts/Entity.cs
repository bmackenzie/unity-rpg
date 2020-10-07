using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
//Parent class containing basic utilities for game objects


public class Entity : MonoBehaviour
{
    //public GameObject grid;
    public Tilemap theMap;
    Vector3 bottomLeftLimit;
    Vector3 topRightLimit;
    //method to prevent entities from moving past the tilemap bounds
    public void setClamp(float toAddx, float toAddy)
    {
        //grid = GameObject.Find("Grid");
        theMap = GameObject.Find("Grid").GetComponentInChildren(typeof(Tilemap)) as Tilemap;
        bottomLeftLimit = theMap.localBounds.min;
        topRightLimit = theMap.localBounds.max;
        bottomLeftLimit += new Vector3(toAddx, toAddy, 0);
        topRightLimit += new Vector3(-toAddx, -toAddy, 0);
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, bottomLeftLimit.x, topRightLimit.x), Mathf.Clamp(transform.position.y, bottomLeftLimit.y, topRightLimit.y), transform.position.z);
    }

}
