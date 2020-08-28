using System;
using UnityEngine;

namespace SoundScripts
{
    [Serializable]
    public class SoundPreset
    {
        public string name;
        
        public AudioClip clip;

        [Range(0f, 1f)] public float volume;

        [HideInInspector] public AudioSource source;
    }
}
