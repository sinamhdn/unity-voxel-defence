using TMPro;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] int health = 10;
    [SerializeField] int damageTake = 1;
    [SerializeField] TextMeshProUGUI healthText;
    [SerializeField] AudioClip hitSFX;

    void Start()
    {
        healthText.text = health.ToString();
    }

    void OnTriggerEnter(Collider other)
    {
        GetComponent<AudioSource>().PlayOneShot(hitSFX);
        health -= damageTake;
        if (health < 0) health = 0;
        healthText.text = health.ToString();
    }
}
