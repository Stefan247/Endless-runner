using UnityEngine;
using UnityEngine.Serialization;

namespace TimeScripts
{
    public class LanternController : MonoBehaviour
    {

        public LightController lightController;
        public Light lightx;

        private void Update()
        {
            if (lightController.timeOfDay > 10f && lightController.timeOfDay < 18f)
            {
                lightx.intensity = 0f;
            }
            else
            {
                lightx.intensity = 0.5f;
            }
        }
    }
}
