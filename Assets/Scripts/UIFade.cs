﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.UI;

// Fades our transition image in and out on scene exit.  Must be attached to canvas, otherwise removing the image removes the script
public class UIFade : MonoBehaviour
{
    //make instance so we can easily call functions
    public static UIFade instance;

    public Image fadeScreen;

    public float fadeSpeed;

    bool shouldFadeToBlack;

    bool shouldFadeFromBlack;

    // Start is called before the first frame update
    void Start()
    {
        //makes sure canvas follows us from scene to scene
        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        if (shouldFadeToBlack)
        {
            //fades from current image color to the same color, but at full alpha. time.deltatime ensures this happens at the same rate regardless of FPS 
            fadeScreen.color = new Color(fadeScreen.color.r, fadeScreen.color.g, fadeScreen.color.b, Mathf.MoveTowards(fadeScreen.color.a, 1f, fadeSpeed * Time.deltaTime));
            //prevent player movement during fade
            GameManager.instance.fadingBetweenAreas = true;
            
            if (fadeScreen.color.a == 1f)
            {
                shouldFadeToBlack = false;
            }
        }

        if (shouldFadeFromBlack)
        {
            fadeScreen.color = new Color(fadeScreen.color.r, fadeScreen.color.g, fadeScreen.color.b, Mathf.MoveTowards(fadeScreen.color.a, 0f, fadeSpeed * Time.deltaTime));
            if (fadeScreen.color.a == 0f)
            {
                shouldFadeFromBlack = false;
                //allow player movement after fade
                GameManager.instance.fadingBetweenAreas = false;
            }
        }
    }


    //fade functions to be called by other scripts
    public void FadeToBlack()
    {
        shouldFadeToBlack = true;
        shouldFadeFromBlack = false;
    }
    
    public void FadeFromBlack()
    {
        shouldFadeFromBlack = true;
        shouldFadeToBlack = false;
    }
}
