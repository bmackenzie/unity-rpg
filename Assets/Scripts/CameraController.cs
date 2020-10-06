using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.Tilemaps;

//if this script is going beyond the bounds of the tilemap, make sure tilemap bounds are compressed, you can do that in the settings for each tilemap

public class CameraController : MonoBehaviour
{

    public Transform target;

    //Assign largest tilemap to theMap
    public Tilemap theMap;

    Vector3 bottomLeftLimit;
    Vector3 topRightLimit;

    float halfHeight;
    float halfWidth;

    // Start is called before the first frame update
    void Start()
    {
        target = PlayerController.instance.transform;
        //Gets the current height and width of the main camera, which is this one if you only have one camera, aspect is aspect ratio
        halfHeight = Camera.main.orthographicSize;
        halfWidth = halfHeight * Camera.main.aspect;

        //sets camera bouyndary variables
        bottomLeftLimit = theMap.localBounds.min + new Vector3(halfWidth, halfHeight, 0f);
        topRightLimit = theMap.localBounds.max + new Vector3(-halfWidth, -halfHeight, 0f);
    }

    // Update is called once per frame after update
    void LateUpdate()
    {
        // move camera to follow player (or other target)
        transform.position = new Vector3(target.position.x, target.position.y, transform.position.z);

        // keep the camera inside the bounds of the map
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, bottomLeftLimit.x, topRightLimit.x), Mathf.Clamp(transform.position.y, bottomLeftLimit.y, topRightLimit.y), transform.position.z);

    }
}
