using UnityEngine;
using Platformer.Movement;

namespace Platformer.Control
{
    public class PlayerMove : MonoBehaviour
    {
        // Reference to components on said object,
        CharacterController characterController;

        // Movement vars,
        [SerializeField] float speed;
        [SerializeField] float jumpHeight;
        [SerializeField] float gravityValue = -9.81f;

        // Input vars,
        float xAxisInput = 0f;
        float zAxisInput = 0f;
        bool isJumping = false;

        // Movement vectors,
        Vector3 playerUpwardVelocity = Vector3.zero;
        Vector3 moveVector = Vector3.zero;

        #region Unity functions,
        private void Start()
        {
            // Getting components,
            characterController = GetComponent<CharacterController>();
        }


        private void Update()
        {
            // Getting input from user,
            xAxisInput = Input.GetAxisRaw("Horizontal");
            zAxisInput = Input.GetAxisRaw("Vertical");

          
        }

        private void FixedUpdate()
        {
            if (characterController == null)
            {
                Debug.LogError("Missing character controller from " + gameObject.name); 
                return;
            }

            // Getting movement direction and applying it to the character controller,
            moveVector = new Vector3(xAxisInput, 0f, zAxisInput);
            characterController.Move(moveVector * speed * Time.fixedDeltaTime);

            // Jumping calculations,
            // Getting jump button (space bar) down,
            if (Input.GetButtonDown("Jump") && characterController.isGrounded)
            {
                playerUpwardVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
            }

            playerUpwardVelocity.y += gravityValue * Time.fixedDeltaTime;
            characterController.Move(playerUpwardVelocity * Time.fixedDeltaTime);



        }
        #endregion

        #region Private functions,
        #endregion

    }

}




