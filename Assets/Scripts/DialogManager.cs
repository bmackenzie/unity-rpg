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
                    }
                    else
                    {
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
    
    //function to be called by dialogActivatorscript
    public void showDialog(string[] newLines)
    {
        dialogLines = newLines;

        currentLine = 0;

        dialogText.text = dialogLines[0];

        dialogBox.SetActive(true);

        justStarted = true;
    }
}
