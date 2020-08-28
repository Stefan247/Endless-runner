using SoundScripts;
using UnityEngine;

namespace GMScripts
{
    public class HpHandler : MonoBehaviour
    {
        public ScoreScript scoreHandler;
        
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Enemy")) 
            {
                scoreHandler.UpdateHp(-1);
                FindObjectOfType<AudioManager>().Play("ghost_reach");
                Destroy(other.gameObject);
            }
        }
    }
}
