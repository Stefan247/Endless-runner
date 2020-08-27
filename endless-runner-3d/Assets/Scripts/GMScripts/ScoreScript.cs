using UnityEngine;
using UnityEngine.UI;

namespace GMScripts
{
    public class ScoreScript : MonoBehaviour
    {
        public Text scoreText;
        public Image[] healthBar;
        public int score;
        public int hp;
        public const int MaxHealth = 3;

        private void Start()
        {
            score = 0;
            hp = 3;
        }

        private void Update()
        {
            scoreText.text = score.ToString();
        }

        public void UpdateScore(GameObject collectible)
        {
            if (collectible.CompareTag("GoodFood"))
            {
                score += 2;
            }
            else
            {
                if (score > 0)
                {
                    score--;
                }
            }

            if (collectible.CompareTag("Coin"))
            {
                score += 10;
            }
        }

        public void UpdateHp(int value)
        {
            hp += value;

            if (hp <= 0)
            {
                Application.LoadLevel(Application.loadedLevel);
            }
            if (hp > 3)
            {
                hp = 3;
            }
            
            for (int i = 0; i < hp; i++)
            {
                healthBar[i].enabled = true;
            }

            for (int i = hp; i < MaxHealth; i++)
            {
                healthBar[i].enabled = false;
            }
        }
    }
}
