using System.Collections;
using SoundScripts;
using UnityEngine;

namespace MiscScripts
{
    public class MeteoriteController : MonoBehaviour
    {
        public Vector3 destination;
        public float speed = 5f;
        public bool played;
        
        private void Start()
        {
            destination =  transform.position + new Vector3(0, -9.75f, 0);
        }
        
        private void Update()
        {
            transform.position = Vector3.MoveTowards(transform.position, destination, Time.deltaTime * speed);

            if (transform.position.y - destination.y < 0.1f)
            {
                if (!played)
                {
                    FindObjectOfType<AudioManager>().Play("meteor_fall");
                    played = true;
                }

                Destroy(gameObject, 10f);
            }
        }
    }
}
