using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterAttack : MonoBehaviour
{
    [SerializeField] private GameObject flame;

    // Start is called before the first frame update
    void Start()
    {
        GameObject flame1 = Instantiate(flame, transform.position, Quaternion.Euler(new Vector3(0, 0, 90)));
        flame1.GetComponent<Rigidbody2D>().AddForce(new Vector3(1, 3, 0) * 50);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
