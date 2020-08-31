using System.Numerics;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;

namespace PlayerScripts
{
    public class PlayerMovement : MonoBehaviour
    {
        public Animator anim;
        public Rigidbody rb;

        private static readonly Vector3 LookLeft = new Vector3(0f, -30f, 0f);
        private static readonly Vector3 LookRight = new Vector3(0f, 30f, 0f);
        Vector3 currentAngle;
        private const float Tolerance = 0.05f;
            
        private float x_input;
        private float movementSpeed = 3.5f;
        private static readonly int IsMoving = Animator.StringToHash("isMoving");

        private void Update()
        {
            x_input = Input.GetAxisRaw("Horizontal");
            rb.MovePosition(transform.position + new Vector3(x_input, 0f, 0f) * (Time.deltaTime * movementSpeed));
            if (Mathf.Abs(x_input) > Tolerance)
            {
                anim.SetBool(IsMoving, true);
                // transform.localEulerAngles = x_input < 0f ? LookLeft : LookRight;

                if (x_input < 0f)
                {
                    currentAngle = new Vector3(
                        Mathf.LerpAngle(transform.rotation.eulerAngles.x, LookLeft.x, Time.deltaTime * 3f),
                        Mathf.LerpAngle(transform.rotation.eulerAngles.y, LookLeft.y, Time.deltaTime * 3f),
                        Mathf.LerpAngle(transform.rotation.eulerAngles.z, LookLeft.z, Time.deltaTime * 3f));
                }
                else
                {
                    currentAngle = new Vector3(
                        Mathf.LerpAngle(transform.rotation.eulerAngles.x, LookRight.x, Time.deltaTime * 3f),
                        Mathf.LerpAngle(transform.rotation.eulerAngles.y, LookRight.y, Time.deltaTime * 3f),
                        Mathf.LerpAngle(transform.rotation.eulerAngles.z, LookRight.z, Time.deltaTime * 3f));
                }

                transform.eulerAngles = currentAngle;
            }
            else
            {
                anim.SetBool(IsMoving, false);
                currentAngle = new Vector3(
                    Mathf.LerpAngle(transform.rotation.eulerAngles.x, 0f, Time.deltaTime * 5f),
                    Mathf.LerpAngle(transform.rotation.eulerAngles.y, 0f, Time.deltaTime * 5f),
                    Mathf.LerpAngle(transform.rotation.eulerAngles.z, 0f, Time.deltaTime * 5f));
                transform.eulerAngles = currentAngle;
            }
        }
    }
}
