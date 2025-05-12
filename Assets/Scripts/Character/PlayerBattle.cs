using UnityEngine;
using System.Collections;
public class PlayerBattle : MonoBehaviour
{

    private SpriteRenderer spriteRenderer;
    private Color originalColor;
    public bool isDefending = false;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        originalColor = spriteRenderer.color;
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
        spriteRenderer.color = Color.red;
        yield return new WaitForSeconds(0.6f);
        spriteRenderer.color = originalColor;
    }

    public void Defend()
    {
        if (spriteRenderer != null)
        {
            spriteRenderer.color = Color.yellow;
        }
        isDefending = true;
    }

    public void Undefending()
    {
        if (spriteRenderer != null)
        {
            spriteRenderer.color = originalColor;
        }
        isDefending = false;
    }
}
