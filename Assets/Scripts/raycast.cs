using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class raycast : MonoBehaviour
{
    public float range = 3;

    private bool lastTrigger = false;

    [System.NonSerialized]
    public GameObject character;
    [System.NonSerialized]
    public GameObject attacker;

    [SerializeField] 
    float attackCooldown = 2f;
    private float tempCooldown = 0f;

    [SerializeField]
    private Animator playerAnimator;
    private string randomAttack;
    [SerializeField]
    private Animator enemyAnimator;

    void Update()
    {
        float fireAxis = Input.GetAxisRaw("X360_Triggers");
        bool fire = Input.GetButtonDown("Fire1") || (fireAxis > 0 && !lastTrigger);

        Vector3 direction = Vector3.forward;

        Ray theRaycast = new Ray(new Vector3(transform.position.x, transform.position.y + 1.75f, transform.position.z), transform.TransformDirection(direction * range));

        if (Physics.Raycast(theRaycast, out RaycastHit hit, range))
        {
            if (hit.collider.tag == "Enemy" && fire)
            {
                randomAttack = ("attacking" + Random.Range(1, 4).ToString("0"));

                if (playerAnimator != null)
                {
                    playerAnimator.SetBool(randomAttack, true);
                }
                else
                {
                    playerAnimator = GetComponentInChildren<Animator>(true);

                    if (playerAnimator != null)
                        playerAnimator.SetBool(randomAttack, true);
                }

                StartCoroutine(CancelAnimDelay(randomAttack));

                character = hit.transform.gameObject;
                attacker = this.gameObject;
                DealDamage(character, attacker);
            }
            else if (hit.collider.tag == "Player")
            {
                if (tempCooldown <= 0f)
                {
                    enemyAnimator.SetBool("isAttacking", true);
                    StartCoroutine(EnemyAnimDelay());

                    character = hit.transform.gameObject;
                    attacker = this.gameObject;
                    DealDamage(character, attacker);

                    tempCooldown = attackCooldown;
                }
                else
                {
                    tempCooldown -= Time.deltaTime;
                }
            }

            if (fireAxis == 0)
            {
                lastTrigger = false;
            }
            else
            {
                lastTrigger = true;
            }
        }
    }

    void DealDamage(GameObject character, GameObject attacker)
    {
        if (character.tag == "Enemy")
        {
            TakeDamage(character, attacker.GetComponent<PlayerController>().attack);
        }
        else if (character.tag == "Player")
        {
            TakeDamage(character, attacker.GetComponent<EnemyController>().attack);
        }
    }

    void TakeDamage(GameObject character, int amount)
    {
        if (character.tag == "Enemy")
        {
            character.GetComponent<EnemyController>().health -= amount;
        }
        else if (character.tag == "Player")
        {
            character.GetComponent<PlayerController>().health -= amount;
        }
    }

    IEnumerator CancelAnimDelay(string randomAttack)
    {
        yield return new WaitForSeconds(0.5f);
        playerAnimator.SetBool(randomAttack, false);
    }

    IEnumerator EnemyAnimDelay()
    {
        yield return new WaitForSeconds(0.5f);
        enemyAnimator.SetBool("isAttacking", false);
    }
}
