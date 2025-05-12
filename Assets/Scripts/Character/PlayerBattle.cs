using UnityEngine;

public class PlayerBattle : MonoBehaviour
{


    public void TakeDamage(int damage)
    {

        int calculateHP = PlayerStats.Instance.getCurrentHP() - damage;
        if (calculateHP<0)
        {
            PlayerStats.Instance.setCurrentHP(0);
        }else{
            PlayerStats.Instance.setCurrentHP(calculateHP);
        }
        
    }

    public void DoAttackAnimation()
    {
        GetComponent<Animator>().SetTrigger("Attack");
        Debug.Log("Attack animation");
    }

}
