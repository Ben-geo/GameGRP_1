using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private float health = 0f;
    [SerializeField] private float maxHealth = 100f;
    // Start is called before the first frame update
    private void Start()
    {
        health = maxHealth;
    }

    // Update is called once per frame
    public void UpdateHealth(float modification)
    {
        health += modification;
        if (health > maxHealth)
        {
            health = maxHealth;
        }
        else if(health <= 0f)
        {
            health = 0f;
            Debug.Log("Game over");
        }

    }
}
