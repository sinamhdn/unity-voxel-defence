using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] ParticleSystem hitParticle;
    [SerializeField] ParticleSystem deathParticle;
    [SerializeField] int hitPoints = 300;
    [SerializeField] int particlesHit = 0;
    [SerializeField] AudioClip hitSFX;
    [SerializeField] AudioClip deathSFX;
    AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void OnParticleCollision(GameObject other)
    {
        // Destroy(other); // THIS WILL DESTROY THE PARTICLE SYSTEM SOURCE
        GetHit();
        if (hitPoints <= 0)
        {
            GetKilled();
        }
        else
        {
            particlesHit++;
        }

    }

    void GetHit()
    {
        audioSource.PlayOneShot(hitSFX);
        hitPoints = hitPoints - 1;
        hitParticle.Play();
    }

    void GetKilled()
    {
        var deathVFX = Instantiate(deathParticle, transform.position + new Vector3(0f, 5f, 0f), Quaternion.identity);
        deathVFX.Play();
        Destroy(deathVFX.gameObject, deathVFX.main.duration);
        AudioSource.PlayClipAtPoint(deathSFX, Camera.main.transform.position);
        // Debug.Break(); // auto pause editor when testing
        Destroy(gameObject);
    }
}
