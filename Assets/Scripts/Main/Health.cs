using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private int maxHealth;
    private int health;

    void Start()
    {
        health = maxHealth;
        print(health);
    }

    void Update()
    {
        if (health <= 0)
        {
            print("ded");
        }
    }

    public void damage(int amount)
    {
        print("ouch!");
        health -= amount;
    }
}
