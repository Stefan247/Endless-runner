using UnityEngine;

namespace UIScripts
{
    public class UI_Controller : MonoBehaviour
    {
        public GameObject[] UI_Elements;
        public GameObject[] MenuUI_Elements;

        private void Start()
        {
            for (int i = 0; i < UI_Elements.Length; i++)
            {
                UI_Elements[i].active = false;
            }

            for (int i = 0; i < MenuUI_Elements.Length; i++)
            {
                MenuUI_Elements[i].active = true;
            }
        }
    
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                for (int i = 0; i < UI_Elements.Length; i++)
                {
                    UI_Elements[i].active = true;
                }
            
                for (int i = 0; i < MenuUI_Elements.Length; i++)
                {
                    MenuUI_Elements[i].active = false;
                }
            }
        }
    }
}
