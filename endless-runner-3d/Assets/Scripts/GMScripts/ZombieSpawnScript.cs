using UnityEngine;

namespace GMScripts
{
    public class ZombieSpawnScript : MonoBehaviour
    {
        public Transform[] spawnPoints;
        public GameObject zombiePrefab;
        public GameObject effectPrefab;

        public void SpawnZombies()
        {
            foreach (Transform t in spawnPoints)
            {
                GameObject effect = Instantiate(effectPrefab, t.position, Quaternion.identity);
                Instantiate(zombiePrefab, t.position, Quaternion.Euler(new Vector3(0, 180, 0)));
                Destroy(effect, 0.5f);
            }
        }
    }
}