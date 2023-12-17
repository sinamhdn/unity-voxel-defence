using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] int health = 10;
    [SerializeField] int damageTake = 1;

    void OnTriggerEnter(Collider other)
    {
        health -= damageTake;
    }
}
