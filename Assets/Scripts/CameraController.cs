using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.Tilemaps;


public class CameraController : Entity
{
    // variable to hold player transform
    Transform target;

    float halfHeight;
    float halfWidth;

    // Start is called before the first frame update
    void Start()
    {
        target = PlayerController.instance.transform;

        //Gets the current height and width of the main camera, which is this one if you only have one camera, aspect is aspect ratio
        halfHeight = Camera.main.orthographicSize;
        halfWidth = halfHeight * Camera.main.aspect;

    }

    // Update is called once per frame after update
    void LateUpdate()
    {
        // move camera to follow player (or other target)
        transform.position = new Vector3(target.position.x, target.position.y, transform.position.z);

        // keep the camera inside the bounds of the map, function is from Entity class
        setClamp(halfWidth, halfHeight);
    }
}
