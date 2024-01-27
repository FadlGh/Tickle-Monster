using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterDamage : MonoBehaviour
{
    [SerializeField] private int maxHealth;
    private int health;

    void Start()
    {
        health = maxHealth;
        print(health);
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
