using System;
using UnityEngine;

namespace GMScripts
{
    public class DestroyFoodScript : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            Destroy(other.gameObject);
        }
    }
}
