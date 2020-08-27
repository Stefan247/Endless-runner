using UnityEngine;

namespace MiscScripts
{
    public class FoodRotation : MonoBehaviour
    {
        private float angle;

        private void Update()
        {
            transform.RotateAround(transform.position, Vector3.up, angle);
            angle += Time.deltaTime * 0.2f;
        }
    }
}
