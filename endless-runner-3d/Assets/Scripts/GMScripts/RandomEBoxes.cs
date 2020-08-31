using PlayerScripts;
using UnityEngine;
using UnityEngine.UI;

namespace GMScripts
{
    public class RandomEBoxes : MonoBehaviour
    {
        public PlayerScoreScript playerScript;
        public FoodSpawningScript foodScript;
        public AudioSource pitchController;
        public Text notification;
        public Transform[] randomization;
        public Rigidbody boxPrefab;

        public string[] notifStrings =
        {
            "", "You're kinda good..", "Okay.. How about this", "Here's some boxes..",
            "Nice!", "Don't lose here..", "This might cause trouble",
            "You're really good!", "Take care!", "Ooops!", ""
        };
        
        private void Start()
        {
            notification.enabled = false;
            notification.color = Color.white;
        }
        
        private void Update()
        {
            if (playerScript.combo == 6)
            {
                print(notifStrings.Length);
                notification.text = notifStrings[Random.Range(0, notifStrings.Length)];
                notification.enabled = true;
                Invoke(nameof(RandomBoxesEvent), 1.5f);
                playerScript.combo++;
            }

            if (playerScript.combo == 12)
            {
                notification.text = "Okay but can you handle this?";
                notification.enabled = true;
                Invoke(nameof(DoubleTheSpeed), 1.5f);
                playerScript.combo++;
            }
        }

        private void DoubleTheSpeed()
        {
            notification.enabled = false;
            foodScript.foodSpeed *= 1.5f;
            foodScript.foodRepeatRate *= 2;
            pitchController.pitch = 1.05f;
            Invoke(nameof(RestoreSpeed), 15f);
        }

        private void RestoreSpeed()
        {
            notification.text = "You did well...";
            notification.enabled = true;
            foodScript.foodSpeed /= 1.5f;
            foodScript.foodRepeatRate /= 2;
            pitchController.pitch = 1f;
            Invoke(nameof(RandomBoxesEvent), 1.5f);
        }

        private void RandomBoxesEvent()
        {
            notification.enabled = false;
            Rigidbody box1 = Instantiate(boxPrefab, randomization[Random.Range(0, 3)].position, Quaternion.identity);
            box1.AddForce(0f, 0f, -foodScript.foodSpeed);
            Rigidbody box2 = Instantiate(boxPrefab, randomization[Random.Range(0, 3)].position, Quaternion.identity);
            box2.AddForce(0f, 0f, -foodScript.foodSpeed);
        }
    }
}
