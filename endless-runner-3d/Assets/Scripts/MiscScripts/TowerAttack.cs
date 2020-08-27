using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace MiscScripts
{
    public class TowerAttack : MonoBehaviour
    {
        public GameObject bulletPrefab;
        public GameObject enemy;
        
        public Transform firePoint;

        private int pizzaCount;

        private void Start()
        {
            InvokeRepeating("ShootPizza", 0f, 1f);
        }

        private void Update()
        {
            enemy = GameObject.FindGameObjectWithTag("Enemy");
            if (enemy != null)
                transform.LookAt(enemy.transform);
        }
        private void ShootPizza()
        {
            if (pizzaCount > 0)
            {
                Shoot();
                pizzaCount--;
            }
        }

        private void Shoot()
        {
            Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);
        }
        
        public void AddPizza()
        {
            pizzaCount++;
        }
    }
}
