using UnityEngine;
using UnityEngine.UI;

namespace MiscScripts
{
    public class TowerAttack : MonoBehaviour
    {
        public GameObject bulletPrefab;
        public GameObject enemy;
        public Text ammo;
        public Transform firePoint;

        private int pizzaCount;

        private void Start()
        {
            InvokeRepeating("ShootPizza", 0f, 1f);
        }

        private void Update()
        {
            enemy = GameObject.FindGameObjectWithTag("Enemy");
            ammo.text = pizzaCount.ToString();
        }
        private void ShootPizza()
        {
            if (pizzaCount > 0 && enemy != null)
            {
                transform.LookAt(enemy.transform);
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
            if (pizzaCount < 10)
            {
                pizzaCount++;
            }
        }
    }
}
