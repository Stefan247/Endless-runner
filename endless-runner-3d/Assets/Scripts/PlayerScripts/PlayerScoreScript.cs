using GMScripts;
using MiscScripts;
using SoundScripts;
using UnityEngine;
using UnityEngine.UI;

namespace PlayerScripts
{
    public class PlayerScoreScript : MonoBehaviour
    {
        public ScoreScript scoreHandler;
        public ZombieSpawnScript zombieHandler;
        public TowerAttack towerHandler;
        public AudioManager audioManager;
        public Text comboText;
        public GameObject getHitEffect;
        
        public int combo;

        public void Update()
        {
            if (combo > 0)
            {
                comboText.text = "x" + combo;
            }
            else
            {
                comboText.text = "";
                comboText.color = Color.black;
            }
        }
        
        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Food") || other.gameObject.CompareTag("GoodFood"))
            {
                Destroy(other.gameObject);
                scoreHandler.UpdateScore(other.gameObject);
            }

            if (other.gameObject.CompareTag("Food"))
            {
                audioManager.Play("ghost_spawn");
                combo = 0;
                zombieHandler.SpawnZombies();
            }

            if (other.gameObject.CompareTag("GoodFood"))
            {
                audioManager.Play("collect_pizza");
                combo++;
                if (combo > 5)
                {
                    comboText.color = Color.yellow;
                }
                if (combo > 10)
                {
                    comboText.color = Color.red;
                }
                towerHandler.AddPizza();
            }

            if (other.gameObject.CompareTag("Box"))
            {
                audioManager.Play("losing_hp");
                GameObject getHit = Instantiate(getHitEffect, transform.position, Quaternion.identity);
                combo = 0;
                Destroy(other.gameObject);
                Destroy(getHit, 0.1f);
                scoreHandler.UpdateHp(-1);
            }

            if (other.gameObject.CompareTag("Heart"))
            {
                audioManager.Play("collect_heart");
                Destroy(other.gameObject);
                scoreHandler.UpdateHp(1);
            }

            if (other.gameObject.CompareTag("Coin"))
            {
                audioManager.Play("collect_coin");
                Destroy(other.gameObject);
                scoreHandler.UpdateScore(other.gameObject);
            }
        }
    }
}
