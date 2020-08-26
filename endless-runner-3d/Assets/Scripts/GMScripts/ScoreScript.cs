using UnityEngine;
using UnityEngine.UI;

namespace GMScripts
{
    public class ScoreScript : MonoBehaviour
    {
        public Text scoreText;
        public int score;

        private void Start()
        {
            score = 0;
        }

        private void Update()
        {
            scoreText.text = score.ToString();
        }

        public void UpdateScore(GameObject collectible)
        {
            if (collectible.CompareTag("GoodFood"))
            {
                score++;
                print(score);
            }
            else
            {
                score--;
                print(score);
            }
        }

        public void UpdateHp(int value)
        {
            print(value);
        }
    }
}
