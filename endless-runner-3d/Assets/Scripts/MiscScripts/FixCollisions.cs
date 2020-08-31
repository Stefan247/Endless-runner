using UnityEngine;

namespace MiscScripts
{
    public class FixCollisions : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Coin") || other.CompareTag("Food") ||
                other.CompareTag("GoodFood") || other.CompareTag("Heart"))
            {
                Destroy(gameObject);
            }
        }
    }
}
