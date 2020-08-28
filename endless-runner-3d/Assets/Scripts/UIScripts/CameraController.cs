using System.Collections;
using SoundScripts;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace UIScripts
{
    public class CameraController : MonoBehaviour
    {

        public Transform[] views;
        public Transform currentView;
        public GameObject idle_player;
    
        public float cameraSpeed = 3f;

        private void Start()
        {
            Time.timeScale = 0f;
        }
        
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                currentView = views[1];
                idle_player.active = false;
                Time.timeScale = 1f;
                FindObjectOfType<AudioManager>().Play("game_start");
            }
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                currentView = views[0];
                Invoke(nameof(RestartGame), 2.5f);
            }
        }

        private void RestartGame()
        {
            SceneManager.LoadScene(0);
        }

        private void LateUpdate()
        {
            transform.position = Vector3.Lerp(transform.position, currentView.position, cameraSpeed * Time.deltaTime);
        
            Vector3 currentAngle = new Vector3(
                Mathf.LerpAngle(transform.rotation.eulerAngles.x, currentView.transform.rotation.eulerAngles.x, Time.deltaTime * cameraSpeed),
                Mathf.LerpAngle(transform.rotation.eulerAngles.y, currentView.transform.rotation.eulerAngles.y, Time.deltaTime * cameraSpeed),
                Mathf.LerpAngle(transform.rotation.eulerAngles.z, currentView.transform.rotation.eulerAngles.z, Time.deltaTime * cameraSpeed));

            transform.eulerAngles = currentAngle;
        }
    }
}
