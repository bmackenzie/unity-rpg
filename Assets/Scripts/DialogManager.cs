using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.UI;

public class DialogManager : MonoBehaviour
{ 

    //variables to store UI objects
    public Text dialogText;
    public Text nameText;
    public GameObject dialogBox;
    public GameObject nameBox;

    //variable to store dialog by line, private as this is set by other objects that call the showDialog function
    string[] dialogLines;

    //variable to store line being displayed
    public int currentLine;

    //variable checking if dialog just started to make sure the first line isn't skipped
    bool justStarted;

    //instanced for easy referencing since their will only ever be one
    public static DialogManager instance;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        //consider deleting this if there's a better way to do it
        dialogBox.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        //moves through dialog on button press.  On button release instead of press. Checks to see if dialog just started to avoid skipping the first line
        if (dialogBox.activeInHierarchy)
        {
            if (Input.GetButtonUp("Fire1"))
            {
                if (!justStarted)
                {
                    currentLine++;

                    //changes dialog text in else condition, deactivates dialog box after all dialog has been shown.
                    if (currentLine >= dialogLines.Length)
                    {
                        dialogBox.SetActive(false);
                        PlayerController.instance.canMove = true;

                    }
                    else
                    {
                        checkIfName();
                        dialogText.text = dialogLines[currentLine];
                    }
                }
                else
                {
                    justStarted = false;
                }

            }
        }
    }
    
    //function to be called by dialogActivatorscript, hides namebox if isPerson is false
    public void showDialog(string[] newLines, bool isPerson)
    {
        dialogLines = newLines;

        currentLine = 0;

        checkIfName();

        dialogText.text = dialogLines[currentLine];

        dialogBox.SetActive(true);

        justStarted = true;

        nameBox.SetActive(isPerson);

        PlayerController.instance.canMove = false;
    }

    //set name function, checks if line includes n-, and sets name if so, replacing the n- with nothing so it doesn't appear in the namebox
    public void checkIfName()
    {
        if(dialogLines[currentLine].StartsWith("n-"))
        {
            nameText.text = dialogLines[currentLine].Replace("n-", "");
            currentLine++;
        }
    }
}
