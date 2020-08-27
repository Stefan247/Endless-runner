using UnityEngine;

namespace PlayerScripts
{
    public class PlayerMovement : MonoBehaviour
    {
        public Animator anim;
        public Rigidbody rb;

        private static readonly Vector3 LookLeft = new Vector3(0f, -10f, 0f);
        private static readonly Vector3 LookRight = new Vector3(0f, 10f, 0f);
        private const float Tolerance = 0.1f;
            
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
                transform.localEulerAngles = x_input < 0f ? LookLeft : LookRight;
            }
            else
            {
                anim.SetBool(IsMoving, false);
                transform.localEulerAngles = Vector3.zero;
            }
        }
    }
}
