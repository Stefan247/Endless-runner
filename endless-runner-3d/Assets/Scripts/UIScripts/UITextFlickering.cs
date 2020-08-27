using UnityEngine;

namespace UIScripts
{
    public class UITextFlickering : MonoBehaviour
    {
    
        private bool trigger = true;
        private void Start()
        {
            InvokeRepeating("TextFlicker", 0f, 0.75f);
        }

        private void TextFlicker()
        {
            this.gameObject.active = trigger;
            trigger = !trigger;
        }

    }
}
