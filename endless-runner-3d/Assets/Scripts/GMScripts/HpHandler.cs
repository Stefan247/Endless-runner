using SoundScripts;
using UnityEngine;

namespace GMScripts
{
    public class HpHandler : MonoBehaviour
    {
        public ScoreScript scoreHandler;
        public GameObject effectPrefab;
        
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Enemy"))
            {
                GameObject effect = Instantiate(effectPrefab, transform.position, Quaternion.identity);
                FindObjectOfType<AudioManager>().Play("ghost_reach");
                Destroy(other.gameObject);
                Destroy(effect, 3f);
                scoreHandler.UpdateHp(-1);
            }
        }
    }
}
