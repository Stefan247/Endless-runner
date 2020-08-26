using UnityEngine;

namespace FoodScripts
{
    public class FoodRotation : MonoBehaviour
    {
        private float angle;

        private void Update()
        {
            transform.RotateAround(transform.position, Vector3.up, angle);
            angle += Time.deltaTime * 0.125f;
        }
    }
}
