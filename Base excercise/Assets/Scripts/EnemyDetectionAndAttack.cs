using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDetectionAndAttack : MonoBehaviour
{
    public Animator animator1;
    public int maxHealth = 100;
    public int currentHealth;
    public int damage = 20;
    public float detectionRange = 10f;
    public float attackRange = 3f;
    public GameObject player;
    private bool isAttacking = false;
    private bool isDead = false;
    public float stoppingDistance = 2f;
    public float attackDelay = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (!isDead)
        {
            if (Vector3.Distance(transform.position, player.transform.position) <= detectionRange)
            {
                // If the player is within the detection range, move towards the player
                transform.LookAt(player.transform); // Look at the player
                animator1.SetTrigger("walk");
                if (Vector3.Distance(transform.position, player.transform.position) > stoppingDistance)
                {
                    transform.position = Vector3.MoveTowards(transform.position, player.transform.position, Time.deltaTime);
                }

                if (Vector3.Distance(transform.position, player.transform.position) <= attackRange && !isAttacking)
                {
                    // If the player is within the attack range, start attacking
                    isAttacking = true;
                    StartCoroutine(Attack());
                }
            }
            else
            {
                animator1.SetTrigger("idle");
            }

        }
    }


    IEnumerator Attack()
    {
        // Play the attack animation
        animator1.SetTrigger("punch");

        // Wait for the attack delay
        yield return new WaitForSeconds(attackDelay);

        // Deal damage to the player
        player.GetComponent<PlayerTakeDamage>().TakeDamage(damage);

        // The enemy is no longer attacking
        isAttacking = false;
    }

    public void TakeDamage(int damage)
    {
        if (!isDead)
        {
            currentHealth -= damage;
            if (currentHealth <= 0)
            {
                Die();
            }
        }
    }
    private void Die()
    {
        isDead = true;
        StartCoroutine(DeathAnimation());
    }
    IEnumerator DeathAnimation()
    {
        // Play the death animation
        animator1.SetTrigger("death");


        // Wait for the animation to finish
        yield return new WaitForSeconds(6);

        // Destroy the enemy
        Destroy(gameObject);

        // increment enemiesKilled variable
        OpenDoorWithKills.instance.KillEnemy();
    }
}