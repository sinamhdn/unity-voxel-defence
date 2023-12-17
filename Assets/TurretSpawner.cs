using UnityEngine;

public class TurretSpawner : MonoBehaviour
{
    [SerializeField] Turret turretPrefab;
    [SerializeField] int spawnLimit = 5;

    public void SpawnTurret(Block baseBlock)
    {
        int turrectCount = FindObjectsOfType<Turret>().Length;
        if (turrectCount < spawnLimit)
        {
            InstantiateTurret(baseBlock);
        }
        else
        {
            print("CANT SPAWN MORE TURRETS");
        }
    }

    private void InstantiateTurret(Block baseBlock)
    {
        Instantiate(turretPrefab, baseBlock.transform.position, Quaternion.identity);
        baseBlock.isPlaceable = false;
    }
}
