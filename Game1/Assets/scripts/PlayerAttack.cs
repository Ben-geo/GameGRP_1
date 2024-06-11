using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private GameObject atkArea = default;
    private GameObject anObject = default;

    private Animator anim;

    private bool attacking = false;
    private float timeToAttack = 0.25f;
    private float timer = 0f;

    private int currentAttackCounter = 0;
    private Timer attackCounterResetTimer;
    // Start is called before the first frame update
    void Start()
    {
        atkArea = transform.GetChild(0).GetChild(0).gameObject;
        anObject = transform.GetChild(0).Find("Animations").gameObject;
        anim = anObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Attack();
        }

        if (attacking)
        {
            timer += Time.deltaTime;

            if (timer >= timeToAttack)
            {
                timer = 0;
                attacking = false;
                atkArea.SetActive(attacking);
                anim.SetBool("active", false);
            }

        }
    }

    private void Attack()
    {
        attacking = true;
        atkArea.SetActive(attacking);
        anim.SetBool("active", true);
        anim.SetInteger("current", currentAttackCounter);
        currentAttackCounter++;
        Debug.Log("WeaponNum = " + currentAttackCounter);
        if (currentAttackCounter == 3)
        {
            currentAttackCounter = 0;
        }
    }
}