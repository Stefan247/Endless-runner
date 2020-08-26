using UnityEngine;

namespace TimeScripts
{
    [System.Serializable]
    [CreateAssetMenu(fileName = "Lighting Preset", menuName = "Scriptables/Lighting Presets Script", order = 1)]
    public class LightPresetsScript : ScriptableObject
    {
        public Gradient AmbientColor;
        public Gradient DirectionalColor;
        public Gradient FogColor;
    }
}
