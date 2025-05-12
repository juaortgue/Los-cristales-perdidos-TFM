using UnityEngine;
using System.Collections;
public class EnemyBattle : MonoBehaviour
{
    public int maxHP = 100;
    public int currentHP;
    public int attack = 10;
    public int defense = 1;
    public int exp = 10;
    public float moveDistance = 0.5f;
    public float speed = 5f;

    private Transform target;
    private SpriteRenderer spriteRenderer;


    void Start()
    {
        currentHP = maxHP;
        spriteRenderer = GetComponent<SpriteRenderer>();
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    public void PlayAttackAnimation()
    {
        StartCoroutine(AttackAnimationRoutine());
    }

    private IEnumerator AttackAnimationRoutine()
    {
        Vector3 originalPosition = transform.position;

        Vector3 direction = (target.position - transform.position).normalized;

        Vector3 attackPosition = originalPosition + direction * moveDistance;

        float time = 0f;

        while (time < 1f)
        {
            time += Time.deltaTime * speed;
            transform.position = Vector3.Lerp(originalPosition, attackPosition, time);
            yield return null;
        }

        time = 0f;
        while (time < 1f)
        {
            time += Time.deltaTime * speed;
            transform.position = Vector3.Lerp(attackPosition, originalPosition, time);
            yield return null;
        }


        transform.position = originalPosition;
    }


    public void TakeDamage(int damage)
    {

        int calculateHP = currentHP - damage;
        if (calculateHP < 0)
        {
            currentHP = 0;
        }
        else
        {
            currentHP = calculateHP;
        }
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
