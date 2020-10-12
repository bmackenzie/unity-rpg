using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//consider moving this into entity or npc
public class DialogActivator : MonoBehaviour
{
    //holds lines to be displayed by the entity
    public string[] lines;

    // check if player is in range of talking
    bool canActivate;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //calls the function that displays dialog if character is in range, button is released, and there isn't a dialog box on screen,  last part of the check keeps the method from being called repeatedly
        if(canActivate && Input.GetButtonDown("Fire1") && !DialogManager.instance.dialogBox.activeInHierarchy)
        {
            DialogManager.instance.showDialog(lines);
        }
    }

    //Set it so character can interact with the object when in range
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
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
