using UnityEngine;

namespace GMScripts
{
    public class ZombieSpawnScript : MonoBehaviour
    {
        public Transform[] spawnPoints;
        public GameObject zombiePrefab;
        
        public void SpawnZombies() {
            foreach (Transform t in spawnPoints)
            {
                Instantiate(zombiePrefab, t.position, Quaternion.Euler(new Vector3(0, 180, 0)));
            }
        }
    }
}
