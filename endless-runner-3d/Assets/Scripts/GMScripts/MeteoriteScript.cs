using UnityEngine;
using UnityEngine.UI;

namespace GMScripts
{
    public class MeteoriteScript : MonoBehaviour
    {
        public Rigidbody meteoritePrefab;
        public Transform[] spawnPoints;
        public Text notification;
        
        void Start()
        {
            InvokeRepeating("RandomMeteoriteEvent", 60f, Random.Range(60f, 90f));
        }

        private void RandomMeteoriteEvent()
        {
            if (Random.Range(0, 2) < 1)
            {
                notification.color = Color.red;
                notification.text = "This might help you.. or not";
                notification.enabled = true;
                Instantiate(meteoritePrefab, spawnPoints[Random.Range(0, 3)].position, Quaternion.Euler(0f, 180f, 0));
                Invoke(nameof(CloseNotif), 2.5f);
            }
        }

        private void CloseNotif()
        {
            notification.enabled = false;
            notification.color = Color.white;
        }
    }
}
