using TMPro;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private int maxHealth;
    [SerializeField] private GameObject screen;
    public int health;

    void Start()
    {
        health = maxHealth;
    }

    void Update()
    {
        if (health <= 0)
        {
            screen.SetActive(true);
            screen.transform.GetChild(0).GetComponent<TMP_Text>().text = this.name + " Lost!";
            Destroy(this.gameObject);
        }
    }

    public void damage(int amount)
    {
        health -= amount;
    }
}
