using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] ParticleSystem hitParticle;
    [SerializeField] ParticleSystem deathParticle;
    [SerializeField] int hitPoints = 300;
    [SerializeField] int particlesHit = 0;

    void Start()
    {

    }

    void OnParticleCollision(GameObject other)
    {
        // Destroy(other); // THIS WILL DESTROY THE PARTICLE SYSTEM SOURCE
        getHit();
        if (hitPoints <= 0)
        {
            getKilled();
        }
        else
        {
            particlesHit++;
        }

    }

    void getHit()
    {
        hitPoints = hitPoints - 1;
        hitParticle.Play();
    }

    void getKilled()
    {
        var deathVFX = Instantiate(deathParticle, transform.position, Quaternion.identity);
        deathVFX.Play();
        Destroy(gameObject);
    }
}
