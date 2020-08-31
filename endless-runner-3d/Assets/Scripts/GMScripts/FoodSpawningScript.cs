using UnityEngine;

namespace GMScripts
{
    public class FoodSpawningScript : MonoBehaviour
    {
        public Transform[] spawnPoints;
        public Rigidbody[] collectibles;
        public Rigidbody boxPrefab;
        public Rigidbody heartPrefab;
        
        public float foodSpeed = 100f;
        public float foodRepeatRate = 1f;
        public float speedRepeatRate = 10f;
        
        private void Start()
        {
            Invoke(nameof(SpawnHandler), 2f);
            InvokeRepeating(nameof(SpeedHandler), 10f, speedRepeatRate);
        }
        
        private void SpawnHandler()
        {
            InvokeRepeating(nameof(SpawnFoodHandler), 0f, foodRepeatRate);
        }

        private void SpeedHandler()
        {
            foodSpeed += 10f;
            if (foodRepeatRate > 0.4f)
            {
                foodRepeatRate -= 0.1f;
            }
        }

        private void SpawnFoodHandler()
        {
            int freeSpace = Random.Range(0, 3);
            int randomization = Random.Range(0, 10);
            
            for (int i = 0; i < spawnPoints.Length; i++)
            {
                if (i != freeSpace)
                {
                    Rigidbody collectible = Instantiate(collectibles[Random.Range(0, collectibles.Length)],
                        spawnPoints[i].position, Quaternion.identity);
                    collectible.AddForce(0f, 0f, -foodSpeed);
                }
                else
                {
                    if (randomization != 9)
                    {
                        Rigidbody box = Instantiate(boxPrefab, spawnPoints[i].position - new Vector3(0.1f, 0f, 0.1f),
                            Quaternion.identity);
                        box.AddForce(0f, 0f, -foodSpeed);
                    }
                    else
                    {
                        Rigidbody heart = Instantiate(heartPrefab, spawnPoints[i].position, Quaternion.identity);
                        heart.AddForce(0f, 0f, -foodSpeed);
                    }
                }
            }
        }
    }
}
