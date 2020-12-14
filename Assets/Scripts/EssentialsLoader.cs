using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//used to load important gameobjects into scenes, both so we can test scenes without having to walk a character to them, and to organize the hierarchy
public class EssentialsLoader : MonoBehaviour
{

    // objects we need to load into the scene
    public GameObject UIScreen;
    public GameObject Player;
    public GameObject gameMan;
    // Start is called before the first frame update
    void Start()
    {
        if(UIFade.instance == null)
        {
            UIFade.instance = Instantiate(UIScreen).GetComponent<UIFade>();
        }

        if(PlayerController.instance == null)
        {
            PlayerController clone = Instantiate(Player).GetComponent<PlayerController>();
            PlayerController.instance = clone;
        }

        if (GameManager.instance == null)
        {
            Instantiate(gameMan);
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
