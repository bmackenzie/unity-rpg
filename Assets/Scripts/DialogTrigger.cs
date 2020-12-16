using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogTrigger : MonoBehaviour
{
    public Dialog dialog;

    public bool InRange = false;

    public void TriggerDialog()
    {
        FindObjectOfType<DialogManager>().StartDialog(dialog);
    }
    
    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            InRange = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            InRange = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (InRange == true && Input.GetKeyDown(KeyCode.Q))
        {
            //Debug.Log("Starting Dialog with " + dialog.name);
            TriggerDialog();
        }

    }


}
