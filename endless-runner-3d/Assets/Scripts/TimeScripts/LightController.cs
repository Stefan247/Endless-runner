using System;
using UnityEngine;

namespace TimeScripts
{
    [ExecuteAlways]
    public class LightController : MonoBehaviour
    {
        public Light directionalLight;
        public LightPresetsScript preset;
        public float timeOfDay;

        private void Start()
        {
            timeOfDay = 12;
        }
        private void Update()
        {
            if (Application.isPlaying)
            {
                timeOfDay += Time.deltaTime * 0.5f;
                timeOfDay %= 24;
                UpdateLighting(timeOfDay / 24);
            }
        }
        private void UpdateLighting(float timePercent)
        {
            RenderSettings.ambientLight = preset.AmbientColor.Evaluate(timePercent);
            RenderSettings.fogColor = preset.FogColor.Evaluate(timePercent);
            
            directionalLight.color = preset.DirectionalColor.Evaluate(timePercent);
            directionalLight.transform.localRotation = 
                Quaternion.Euler(new Vector3((timePercent * 360f) - 90f, 135f, 0));
        }
    }
}
