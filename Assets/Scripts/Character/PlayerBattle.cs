using UnityEngine;
using System.Collections;
public class PlayerBattle : MonoBehaviour
{

    private SpriteRenderer spriteRenderer;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    public void TakeDamage(int damage)
    {

        int calculateHP = PlayerStats.Instance.getCurrentHP() - damage;
        if (calculateHP < 0)
        {
            PlayerStats.Instance.setCurrentHP(0);
        }
        else
        {
            PlayerStats.Instance.setCurrentHP(calculateHP);
        }

    }

    public void DoAttackAnimation()
    {
        GetComponent<Animator>().SetTrigger("Attack");

    }

    public void DoReceiveDamageAnimation()
    {
        if (spriteRenderer != null)
        {
            StartCoroutine(ReciveDamageFlash());
        }
    }

    private IEnumerator ReciveDamageFlash()
    {
        Color originalColor = spriteRenderer.color;
        spriteRenderer.color = Color.red;
        yield return new WaitForSeconds(0.6f);
        spriteRenderer.color = originalColor;
    }

}
