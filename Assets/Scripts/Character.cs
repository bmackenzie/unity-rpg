using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class Character : Entity
{

    public string charName;
    public int level;
    public int currentExp;
    public int[] expToNextLevel;
    public int maxLevel = 99;
    public int baseExp = 1000;

    public int currentHP;
    public int maxHP = 100;

    public int currentMP;
    public int maxMP = 30;
    public int strength;
    public int defence;
    public int weaponPower;
    public int armorPower;
    public string equippedWeapon;
    public string equippedArmor;
    public Sprite charImage;

    // Start is called before the first frame update
    void Start()
    {
        expToNextLevel = new int[99];
        expToNextLevel[1] = baseExp;

        for(int i = 2; i<expToNextLevel.Length; i++)
        {
            expToNextLevel[i] = Mathf.FloorToInt(expToNextLevel[i - 1] * 1.05f);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.K))
        {
            AddExp(500);
        }
    }

    public void AddExp(int expToAdd)
    {
        currentExp += expToAdd;

        if(currentExp > expToNextLevel[level])
        {
            currentExp -= expToNextLevel[level];

            level++;
        }
    }
}
