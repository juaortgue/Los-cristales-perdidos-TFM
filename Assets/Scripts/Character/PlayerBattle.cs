using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBattle : MonoBehaviour
{

    public int maxHP = 100;
    public int currentHP;
    public int attack = 10;
    public int defense = 1;
    public int level = 1;

    void Start()
    {
        currentHP = maxHP;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(int damage)
    {
        Debug.Log("take damage from player");

        int calculateHP = currentHP - damage;
        if (calculateHP<0)
        {
            currentHP=0;
        }else{
            currentHP=calculateHP;
        }
        Debug.Log("life player = "+currentHP);

    }

    
}
