using System.Collections;
using UnityEngine;

public class MonsterAttack : MonoBehaviour
{
    [SerializeField] private GameObject flame;
    [SerializeField] private PlayerController player;
    private int i = 0;
    private int j = 0;

    void Start()
    {
        StartCoroutine(RepeatLaunch(2f));
        StartCoroutine(PlaySounds(7f));
    }

    IEnumerator RepeatLaunch(float delay)
    {
        while (true)
        {
            yield return new WaitForSeconds(delay);
            // sound
            if (player.CanAttack()) i = Random.Range(1, 4);
            else i = Random.Range(0, 4);

            switch (i)
            {
                case 0:
                    LaunchFlames(1, 4, 150);
                    break;
                case 1:
                    LaunchFlames(1, 10, 50);
                    break;
                case 2:
                    LaunchFlames(1, 10, 50);
                    LaunchFlames(1, 4, 150);
                    break;
                case 3:
                    LaunchFlames(1, 12, 50);
                    break;

            }
        }
    }

    IEnumerator PlaySounds(float delay)
    {
        while (true)
        {
            yield return new WaitForSeconds(delay);
            j = Random.Range(0, 4);

            switch (j)
            {
                case 0:
                    AudioManager.instance.Play("No");
                    break;
                case 1:
                    AudioManager.instance.Play("No");
                    break;
                case 2:
                    AudioManager.instance.Play("Stop Tickling Me");
                    break;
                case 3:
                    AudioManager.instance.Play("Help Me");
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
