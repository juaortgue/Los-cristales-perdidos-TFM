using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBattle : MonoBehaviour
{
    public int maxHP = 100;
    public int currentHP;
    public int attack = 10;
    public int defense = 1;
    public int exp = 10;

    void Start()
    {
        currentHP = maxHP;
    }

    public void TakeDamage(int damage)
    {
       
        int calculateHP = currentHP - damage;
        if (calculateHP<0)
        {
            currentHP=0;
        }else{
            currentHP=calculateHP;
        }
    }
}
