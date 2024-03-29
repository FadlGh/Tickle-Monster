using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flame : MonoBehaviour
{
    void Start()
    {
        Destroy(this.gameObject, 5f); 
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<Health>().damage(1);
            Destroy(this.gameObject);
        }
    }
}
