using System.Collections;
using PlayerScripts;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace GMScripts
{
    public class ScoreScript : MonoBehaviour
    {
        public PlayerScoreScript playerScript;
        
        public Text scoreText;
        public Image[] healthBar;
        public Text finalScoreText;
        
        public int score;
        public int hp;
        public const int MaxHealth = 3;

        private void Start()
        {
            score = 0;
            hp = 3;
            finalScoreText.enabled = false;
        }

        private void Update()
        {
            scoreText.text = score.ToString();
        }

        public void UpdateScore(GameObject collectible)
        {
            if (collectible.CompareTag("GoodFood"))
            {
                score += 2 + playerScript.combo * 2;
            }
            else if (score > 0) 
            {
                score--;
            }

            if (collectible.CompareTag("Coin"))
            {
                score += 10 + playerScript.combo * 10;
            }
        }

        public void UpdateHp(int value)
        {
            hp += value;

            CheckIfDead();
            CheckOverflow();
            
            for (int i = 0; i < hp; i++)
            {
                healthBar[i].enabled = true;
            }

            for (int i = hp; i < MaxHealth; i++)
            {
                healthBar[i].enabled = false;
            }
        }

        private void CheckOverflow()
        {
            if (hp > 3) 
            { 
                hp = 3;
            }
        }

        private void CheckIfDead()
        {
            if (hp <= 0)
            { 
                hp = 0;
                finalScoreText.text = "Score: " + score.ToString();
                finalScoreText.enabled = true;
                Invoke("RestartGame", 0.75f);
            }
        }

        private void RestartGame()
        {
            SceneManager.LoadScene(0);
        }
    }
}
