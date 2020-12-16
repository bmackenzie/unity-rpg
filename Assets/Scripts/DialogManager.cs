using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogManager : MonoBehaviour
{

    private Queue<string> sentences;
    // Start is called before the first frame update
    void Start()
    {
        sentences = new Queue<string>();
    }

    public void StartDialog (Dialog dialog)
    {
        Debug.Log("Starting Dialog with " + dialog.Name);
    }
    // Update is called once per frame
    void Update()
    {
    
    }
}
