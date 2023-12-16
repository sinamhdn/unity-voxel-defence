using UnityEngine;

public class Turret : MonoBehaviour
{
    // [SerializeField] Transform topOBJ;
    // [SerializeField] Transform targetOBJ;
    // [SerializeField] ParticleSystem projectile;
    [SerializeField] float attackRange = 30f;
    ParticleSystem projectile;
    Transform turretTop;
    Transform target;

    void Start()
    {
        turretTop = transform.GetChild(0);
        target = FindObjectOfType<Enemy>().transform;
        projectile = GetComponentInChildren<ParticleSystem>();
    }

    void Update()
    {
        if (target)
        {
            turretTop.LookAt(target);
            Fire();
        }
        else
        {
            Shoot(false);
        }
    }

    void Fire()
    {
        float distanceToEnemy = Vector3.Distance(target.transform.position, gameObject.transform.position);
        if (distanceToEnemy <= attackRange)
        {
            Shoot(true);
        }
        else
        {
            Shoot(false);
        }
    }

    void Shoot(bool isShooting)
    {
        var emissionModule = projectile.emission;
        emissionModule.enabled = isShooting;
    }
}
