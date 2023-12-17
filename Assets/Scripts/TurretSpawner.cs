using System.Collections.Generic;
using UnityEngine;

public class TurretSpawner : MonoBehaviour
{
    [SerializeField] Turret turretPrefab;
    [SerializeField] int spawnLimit = 5;
    // [SerializeField] GameObject parent;
    Queue<Turret> turretQueue = new Queue<Turret>();
    GameObject parent;

    void Start()
    {
        parent = new GameObject("Turrets");
        //parent.transform.SetParent(transform);
    }

    public void SpawnTurret(Block baseBlock)
    {
        // int turrectCount = FindObjectsOfType<Turret>().Length;
        int turrectCount = turretQueue.Count;
        if (turrectCount < spawnLimit)
        {
            InstantiateTurret(baseBlock);
        }
        else
        {
            RelocateTurret(baseBlock);
        }
    }

    private void InstantiateTurret(Block baseBlock)
    {
        Turret newTurret = Instantiate(turretPrefab, baseBlock.transform.position, Quaternion.identity);
        newTurret.transform.SetParent(parent.transform);
        newTurret.baseBlock = baseBlock;
        baseBlock.isPlaceable = false;
        turretQueue.Enqueue(newTurret);
    }

    private void RelocateTurret(Block newBaseBlock)
    {
        Turret oldTurret = turretQueue.Dequeue();
        oldTurret.baseBlock.isPlaceable = true;
        newBaseBlock.isPlaceable = false;
        oldTurret.baseBlock = newBaseBlock;
        oldTurret.transform.position = newBaseBlock.transform.position;
        turretQueue.Enqueue(oldTurret);

    }
}
