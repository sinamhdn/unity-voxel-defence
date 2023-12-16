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
        projectile = GetComponentInChildren<ParticleSystem>();
        // target = FindObjectOfType<Enemy>().transform;
    }

    void Update()
    {
        FindTarget();
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

    void FindTarget()
    {
        var sceneEnemies = FindObjectsOfType<Enemy>();
        if (sceneEnemies.Length == 0) return;
        Transform closeEnemy = sceneEnemies[0].transform;
        foreach (Enemy enemy in sceneEnemies)
        {
            closeEnemy = FindClosestEnemy(closeEnemy, enemy.transform);
        }
        target = closeEnemy;
    }

    Transform FindClosestEnemy(Transform transform0, Transform transform1)
    {
        var disstTo0 = Vector3.Distance(transform.position, transform0.position);
        var disstTo1 = Vector3.Distance(transform.position, transform1.position);
        if (disstTo0 < disstTo1) return transform0;
        return transform1;
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
