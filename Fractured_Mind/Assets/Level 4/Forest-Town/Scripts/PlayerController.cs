using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float playerSpeed = 8f;
    [SerializeField] private float jumpForce = 5f;
    [SerializeField] private float sigiloSpeedMultiplier = 0.1f;
    public Animator playerAnimator;
    private CharacterController _controller;
    private Vector3 _playerVelocity;
    private bool _isGrounded;
    public bool _isStealth;

    private void Start()
    {
        _controller = GetComponent<CharacterController>();
    }

    private void Update()
    {
        MovePlayer(); // Funcion de Movimiento del Jugador
        Jump(); // Funcion de Salto del Jugador
        ToggleStealth(); // Funcion para activar/desactivar el modo sigilo
    }
        public bool IsStealth // Propiedad pública para acceder a la variable _isStealth
    {
        get { return _isStealth; }
    }

    private void MovePlayer()
    {
        playerAnimator.SetBool("isWalking", false); // Animacion de Caminar Desactivada
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 direction = new Vector3(horizontal, 0f, vertical); // Direccion a la que se mueve el jugador
        if (direction.magnitude > 0.1f) // Calcula si la distancia del vector 1 y 2 es menor a 0.1f
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg; // Calculo de Angulo de caida
            transform.rotation = Quaternion.Euler(0f, targetAngle, 0f);

            // Aplicar velocidad de movimiento dependiendo del modo sigilo
            float speed = _isStealth ? playerSpeed * sigiloSpeedMultiplier  / 100.0f: playerSpeed ;

            _controller.Move(direction * speed * Time.deltaTime);

            if (_isGrounded)
            {
                playerAnimator.SetBool("isWalking", true);
            }
            else
            {
                playerAnimator.SetBool("isWalking", false);
            }
        }
    }

    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && _isGrounded) // Se verifica si se presiono espacio y si esta en tierra el jugador
        {
            playerAnimator.SetBool("isWalking", false);
            playerAnimator.SetBool("isJumping", true);
            _playerVelocity.y += Mathf.Sqrt(jumpForce * -2f * Physics.gravity.y);
            _isGrounded = false;
        }

        _playerVelocity.y += Physics.gravity.y * Time.deltaTime;
        _controller.Move(_playerVelocity * Time.deltaTime);

        if (_controller.isGrounded && _playerVelocity.y < 0f) // Se Verifica si el jugador esta en tierra y si la velocidad es menor que 0 esto para cargar la animacion de caida
        {
            playerAnimator.SetBool("isJumping", false);
            Debug.Log("Cai");
            _playerVelocity.y = 0f;
            _isGrounded = true;
        }
    }
private void ToggleStealth()
{
    if (Input.GetKeyDown(KeyCode.LeftShift))
    {
        _isStealth = true;
    }
    
    if (Input.GetKeyUp(KeyCode.LeftShift))
    {
        _isStealth = false;
    }
}


}