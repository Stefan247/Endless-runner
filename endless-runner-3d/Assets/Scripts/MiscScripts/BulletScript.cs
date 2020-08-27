using System;
using UnityEngine;

namespace MiscScripts
{
    public class BulletScript : MonoBehaviour
    {
        public GameObject enemy;
        private float speed = 5f;
        
        private void Update()
        {
            enemy = GameObject.FindGameObjectWithTag("Enemy");
            if (enemy != null)
                transform.position = Vector3.MoveTowards(transform.position, enemy.transform.position, Time.deltaTime * speed);
            else 
                Destroy(gameObject);
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Enemy"))
            {
                Destroy(other.gameObject);
                Destroy(gameObject);
            }
        }
    }
}
