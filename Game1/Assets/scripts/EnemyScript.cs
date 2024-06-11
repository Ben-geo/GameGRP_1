using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    [SerializeField] private int attackDamage;
    [SerializeField] private float attackSpeed = 1f;
    private float canAttack;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if(attackSpeed <= canAttack)
            {
                collision.gameObject.GetComponent<Health>().Damage(attackDamage);
                canAttack = 0;
            }
            else
            {
                canAttack += Time.deltaTime;
            }
        }
    }
}
