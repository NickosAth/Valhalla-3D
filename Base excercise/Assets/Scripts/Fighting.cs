using System.Collections.Generic;
using UnityEngine;

public class Fighting : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private GameObject swordOut;
    [SerializeField] private GameObject swordIn;

    public int attackDamage = 20;
    public float attackRange = 1f;
    public List<GameObject> enemies;
    int damage = 20;
    private bool weaponOut = false;
    private bool canAttack = false;
    private bool isAttacking = false;

    // Start is called before the first frame update
    void Start()
    {
        swordOut.SetActive(false);
        swordIn.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            if (weaponOut)
            {
                animator.SetTrigger("seathWeapon");
                HideSword();
                weaponOut = false;
                canAttack = false;
            }
            else
            {
                animator.SetTrigger("drawWeapon");
                ShowSword();
                weaponOut = true;
                canAttack = true;
            }
        }
        if (Input.GetMouseButtonDown(0) && canAttack)
        {
            isAttacking = true;
            RaycastHit hit;
            if (Physics.Raycast(transform.position, transform.forward, out hit, attackRange))
            {
                if (hit.transform.CompareTag("Enemy"))
                {
                    hit.transform.GetComponent<EnemyDetectionAndAttack>().TakeDamage(damage);
                }
            }
            animator.SetTrigger("lightAttack1");
        }
    }

    public void ShowSword()
    {
        swordOut.SetActive(true);
        swordIn.SetActive(false);
    }

    public void HideSword()
    {
        swordOut.SetActive(false);
        swordIn.SetActive(true);
    }
}
