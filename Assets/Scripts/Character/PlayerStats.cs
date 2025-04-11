using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public static PlayerStats Instance;

    [SerializeField] private int level = 1;
    [SerializeField] private int currentXP = 0;
    [SerializeField] private int xpToNextLevel = 100;

    [SerializeField] private int maxHP = 100;
    [SerializeField] private int currentHP;
    [SerializeField] private int attack = 10;
    [SerializeField] private int defense = 5;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); 
        }
        else
        {
            Destroy(gameObject); 
        }
    }

    void Start()
    {
        
        if (currentHP == 0)
        {
            currentHP = maxHP;
        }
    }


    public int getCurrentHP()
    {
        return currentHP;
    }

    public int getMaxHP()
    {
        return maxHP;
    }

    public int getLevel()
    {
        return level;
    }

    public int getCurrentXP()
    {
        return currentXP;
    }

    public int getXPToNextLevel()
    {
        return xpToNextLevel;
    }

    public int getAttack()
    {
        return attack;
    }

    public int getDefense()
    {
        return defense;
    }

    public void setLevel(int newLevel)
    {
        level = newLevel;
    }

    public void setCurrentXP(int xp)
    {
        currentXP = xp;
    }

    public void setXPToNextLevel(int xp)
    {
        xpToNextLevel = xp;
    }

    public void setMaxHP(int hp)
    {
        maxHP = hp;
    }

    public void setAttack(int atk)
    {
        attack = atk;
    }

    public void setDefense(int def)
    {
        defense = def;
    }
    public void setCurrentHP(int hp)
    {
        currentHP = hp;
    }

}
