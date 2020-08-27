using UnityEngine;

namespace GMScripts
{
    public class ZombieSpawnScript : MonoBehaviour
    {
        public Transform[] spawnPoints;
        public GameObject zombiePrefab;
        
        public void SpawnZombies()
        {
            int randomPos = Random.Range(0, 2);
            Instantiate(zombiePrefab, spawnPoints[randomPos].position, Quaternion.Euler(new Vector3(0, 180, 0)));
            /*
            foreach (Transform t in spawnPoints)
            {
                Instantiate(zombiePrefab, t.position, Quaternion.Euler(new Vector3(0, 180, 0)));
            }
            */
        }
    }
}
