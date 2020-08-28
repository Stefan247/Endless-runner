using System;
using GMScripts;
using MiscScripts;
using SoundScripts;
using UnityEngine;

namespace PlayerScripts
{
    public class PlayerScoreScript : MonoBehaviour
    {
        public ScoreScript scoreHandler;
        public ZombieSpawnScript zombieHandler;
        public TowerAttack towerHandler;
        public AudioManager audioManager;

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
                zombieHandler.SpawnZombies();
            }

            if (other.gameObject.CompareTag("GoodFood"))
            {
                audioManager.Play("collect_pizza");
                towerHandler.AddPizza();
            }

            if (other.gameObject.CompareTag("Box"))
            {
                audioManager.Play("losing_hp");
                Destroy(other.gameObject);
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
