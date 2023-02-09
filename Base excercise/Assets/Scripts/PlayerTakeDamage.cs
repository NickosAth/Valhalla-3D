using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTakeDamage : MonoBehaviour
{

    public int maxHealth = 100;
    public int currentHealth;
    public Canvas healthBarCanvas;
    public HealthBar healthBar;
    public Canvas DeathCanvas;



    [SerializeField] private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        DeathCanvas.gameObject.SetActive(false);

        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        AnimatorStateInfo currentState = animator.GetCurrentAnimatorStateInfo(0);
        if (Input.GetKeyDown(KeyCode.CapsLock) && currentState.IsName("Healing") == false)
        {
            animator.SetTrigger("heal");
            StartCoroutine(WaitForHeal(50));
        }
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
        if (currentHealth <= 0)
        {
            Die();           
        }       
    }

    private void Die()
    {
        animator = GetComponent<Animator>();
        int currentLayerIndex = animator.GetLayerIndex("CombatLayer");
        if (currentLayerIndex == animator.GetLayerIndex("CombatLayer"))
        {
            animator.SetTrigger("Dead");
            // Wait for the death animation to finish before showing the death panel
            StartCoroutine(WaitForAnimation());
        }
    }

    public void Heal(int amount)
    {
        animator.SetTrigger("heal");
        StartCoroutine(WaitForHeal(amount));
    }

    IEnumerator WaitForAnimation()
    {
        yield return new WaitForSeconds(3);
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        DeathCanvas.gameObject.SetActive(true);
    }
    IEnumerator WaitForHeal(int amount)
    {
        yield return new WaitForSeconds(animator.GetCurrentAnimatorStateInfo(0).length);
        currentHealth += amount;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
        healthBar.SetHealth(currentHealth);
    }
}