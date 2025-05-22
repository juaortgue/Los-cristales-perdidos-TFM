using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    // Singleton instance
    public static PlayerStats Instance;

    //character progression
    [SerializeField] private int level = 1;
    [SerializeField] private int currentXP = 0;
    [SerializeField] private int xpToNextLevel = 10;
    [SerializeField] private int maxLvl = 5;
    [SerializeField] private int[] lifeLevels = new int[5] { 40, 50, 60, 70, 80 };
    [SerializeField] private int[] attackLevels = new int[5] { 8, 10, 12, 14, 16 };
    [SerializeField] private int[] defenseLevels = new int[5] { 4, 6, 8, 10, 12 };

    //only for testing purposes
    [SerializeField] private bool updgradeToMaxLevel = false;
    [SerializeField] private bool upgradeToMaxStats = false;

    //character stats
    private int maxHP = 40;
    private int currentHP;
    private int attack = 8;
    private int defense = 4;

    private Vector3 playerPosition;



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
        maxHP = lifeLevels[0];
        attack = attackLevels[0];
        defense = defenseLevels[0];

        if (currentHP == 0)
        {
            currentHP = maxHP;
        }
        playerPosition = Vector3.zero;

        if (updgradeToMaxLevel)
        {
            level = maxLvl;
            currentXP = 0;
            xpToNextLevel = 0;

            maxHP = lifeLevels[maxLvl - 1];
            attack = attackLevels[maxLvl - 1];
            defense = defenseLevels[maxLvl - 1];
            currentHP = maxHP;
        }
        else if (upgradeToMaxStats)
        {
            maxHP = 999;
            attack = 999;
            defense = 999;
            currentHP = maxHP;
            level = maxLvl;
        }
    }
    public void ResetStats()
    {
        level = 1;
        currentXP = 0;
        xpToNextLevel = 10;

        maxHP = lifeLevels[0];
        attack = attackLevels[0];
        defense = defenseLevels[0];
        currentHP = maxHP;

        playerPosition = Vector3.zero;
    }

    public void RecoverHP()
    {
        currentHP = maxHP;
    }
    public void GainExpFromEnemy(int exp)
    {
        Debug.Log("GainExpFromEnemy");
        if (level < maxLvl)
        {
            currentXP += exp;
            Debug.Log("Current XP: " + currentXP);

            if (currentXP >= xpToNextLevel)
            {
                LevelUp();
            }

            if (currentXP < 0 || currentXP > xpToNextLevel)
            {
                currentXP = 0;
            }
        }

    }

    private void LevelUp()
    {
        level++;
        Debug.Log("Level Up! New Level: " + level);
        currentXP = 0;
        xpToNextLevel = xpToNextLevel * 2;
        if (level >= maxLvl)
        {
            xpToNextLevel = 0;
        }

        if (level > 1 && level <= maxLvl)
        {
            maxHP = lifeLevels[level - 1];
            attack = attackLevels[level - 1];
            defense = defenseLevels[level - 1];
        }
        else if (level > maxLvl)
        {
            level = maxLvl;
        }

    }

    public int getMaxLvl()
    {
        return maxLvl;
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
    public Vector3 getPlayerPosition()
    {
        return playerPosition;
    }
    public void setPlayerPosition(Vector3 position)
    {
        playerPosition = position;
    }

}
