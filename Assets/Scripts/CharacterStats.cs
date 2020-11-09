using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStats : MonoBehaviour
{
    //variables for stats and experience
    public string charName;
    public int level = 1;
    public int currentExp;

    public int currentHP;
    public int maxHP = 100;

    public int currentMP;
    public int maxMP = 30;
    //array holding how much mp should go up by each level
    public int[] mpLevelBonus;
    
    //Character Stats, derived from skill increases
    public int strength;
    public int dexterity;
    public int body;
    public int mind;
    public int charm;

    //skills
    Skill oneHanded = new Skill("One Handed", 1, 0);
    Skill twoHanded = new Skill("Two Handed", 1, 0);
    Skill finesse = new Skill("Finesse Weapon", 1, 0);
    Skill fist = new Skill("Fist", 1, 0);
    Skill bow = new Skill("Bow", 1, 0);
    Skill magic = new Skill("Magic", 1, 0);

    //equipment
    public int weaponPower;
    public int weaponMagic;
    public int armorPower;
    public int armorDodge;
    public string equippedWeapon;
    public string equippedArmor;


    public Sprite charImage;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //code used to test exp gain and level up remove when done testing
        if (Input.GetKeyDown(KeyCode.K))
        {
            oneHanded.AddExp(1000);
        }
    }
}
