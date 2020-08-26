using UnityEngine;

namespace GMScripts
{
    public class ScoreScript : MonoBehaviour
    {
        public int score;

        private void Start()
        {
            score = 0;
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
