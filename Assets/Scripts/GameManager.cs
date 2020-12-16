using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//hold information on what characters we have to display to players
public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    //array of character stats that can be displayed
    public CharacterStats[] playerStats;


    // Setting bools that will be used to stop player movement
    public bool gameMenuOpen, dialogueActive, fadingBetweenAreas;


    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        //check if any conditions are active that should stop the player from moving
        if (gameMenuOpen || fadingBetweenAreas)
        {
            PlayerController.instance.canMove = false;
        }
        else
        {
            PlayerController.instance.canMove = true;
        }
    }
}
