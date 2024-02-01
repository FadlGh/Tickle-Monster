using UnityEngine.UI;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Health health;

    void Update()
    {
        GetComponent<Slider>().value = health.health;
    }
}
