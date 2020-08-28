using UnityEngine;
using UnityEngine.Audio;
using System;

namespace SoundScripts
{
    public class AudioManager : MonoBehaviour
    {
        public SoundPreset[] sounds;

        private void Awake()
        {
            foreach (SoundPreset sound in sounds)
            {
                sound.source = gameObject.AddComponent<AudioSource>();
                sound.source.clip = sound.clip;

                sound.source.volume = sound.volume;
                sound.source.name = sound.name;
            }
        }

        public void Play(string name)
        {
            SoundPreset s = Array.Find(sounds, sound => sound.name == name);
            s.source.Play();
        }
    }
}
