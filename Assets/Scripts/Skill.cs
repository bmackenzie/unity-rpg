using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill
{
    //private string skillName;
    public string Name { get; set; }
    //private int Level;
    public int Level { get; set; }
    public int Exp { get; set; }
    //private int skillExp;
    private int maxLevel = 100;
    private int[] expToNextLevel;
    private int baseExp = 1000;

    //skill constructor
    public Skill(string name, int level, int exp)
    {
        Name = name;
        Level = level;
        Exp = exp;
        //array holding how much exp is needed to level up
        expToNextLevel = new int[99];
        expToNextLevel[1] = baseExp;
        //loop through the array, setting the exp needed for each level so we don't have to do it manually
        for (int i = 2; i < expToNextLevel.Length; i++)
        {
            expToNextLevel[i] = Mathf.FloorToInt(expToNextLevel[i - 1] * 1.05f);
        }
    }   



    //function for adding exp to the skill and leveling up
    public void AddExp(int expToAdd)
        {
            Exp += expToAdd;
            //check to make sure we aren't max level
            if (Level < maxLevel)
            {
                //check if we have enough exp to level up
                if (Exp > expToNextLevel[Level])
                {
                    //set exp to the difference between the exp we have and how much we need to level
                    Exp -= expToNextLevel[Level];

                    Level++;
                }
            }
            //make sure exp doesn't go up once we are max level
            if (Level >= maxLevel)
            {
                Exp = 0;
            }
        }
}
