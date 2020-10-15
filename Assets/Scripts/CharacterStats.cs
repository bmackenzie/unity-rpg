using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStats : MonoBehaviour
{
    //variables for stats and experience
    public string charName;
    public int level = 1;
    public int currentExp;
    public int[] expToNextLevel;
    public int maxLevel = 100;
    public int baseExp = 1000;

    public int currentHP;
    public int maxHP = 100;

    public int currentMP;
    public int maxMP = 30;
    //array holding how much mp should go up by each level
    public int[] mpLevelBonus;
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
        //array holding how much exp is needed to level up
        expToNextLevel = new int[99];
        expToNextLevel[1] = baseExp;
        //loop through the array, setting the exp needed for each level so we don't have to do it manually
        for (int i = 2; i < expToNextLevel.Length; i++)
        {
            expToNextLevel[i] = Mathf.FloorToInt(expToNextLevel[i - 1] * 1.05f);
        }
    }

    // Update is called once per frame
    void Update()
    {
        //code used to test exp gain and level up remove when done testing
        if (Input.GetKeyDown(KeyCode.K))
        {
            AddExp(1000);
        }
    }

    //function for adding exp to the character and leveling up
    public void AddExp(int expToAdd)
    {
        currentExp += expToAdd;
        //check to make sure we aren't max level
        if (level < maxLevel)
        {
            //check if we have enough exp to level up
            if (currentExp > expToNextLevel[level]l)
            {
                //set exp to the difference between the exp we have and how much we need to level
                currentExp -= expToNextLevel[level];

                level++;

                //determine what stats should increase (starting with alternating strength and defense)
                if (level % 2 == 0)
                {
                    strength++;
                }
                else
                {
                    defence++;
                }

                maxHP = Mathf.FloorToInt(maxHP * 1.05f);
                currentHP = maxHP;

                maxMP += mpLevelBonus[level];
                currentMP = maxMP;
            }
        }
        //make sure exp doesn't go up once we are max level
        if(level >= maxLevel)
        {
            currentExp = 0;
        }
    }
}
