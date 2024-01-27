using System.Collections;
using UnityEngine;

public class MonsterAttack : MonoBehaviour
{
    [SerializeField] private GameObject flame;
    private int i = 0;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(RepeatLaunch(2f));
        print((0 + 1) % 2);
    }

    // Update is called once per frame
    void Update()
    {
        // Other code if needed
    }

    IEnumerator RepeatLaunch(float delay)
    {
        while (true)  // Infinite loop to keep launching every 2 seconds
        {
            yield return new WaitForSeconds(delay);

            // Increment i and reset to 0 if it reaches the maximum case
            i = (i + 1) % 2;

            switch (i)
            {
                case 0:
                    LaunchFlames(1, 10, 50);
                    break;
                case 1:
                    LaunchFlames(1, 4, 150);
                    break;
            }
        }
    }

    void LaunchFlames(int direction, int height, int force)
    {
        GameObject flame1 = Instantiate(flame, transform.position, Quaternion.identity);
        flame1.GetComponent<Rigidbody2D>().AddForce(new Vector3(direction, height, 0) * force);

        GameObject flame2 = Instantiate(flame, transform.position, Quaternion.identity);
        flame2.GetComponent<Rigidbody2D>().AddForce(new Vector3(-direction, height, 0) * force);
    }
}
