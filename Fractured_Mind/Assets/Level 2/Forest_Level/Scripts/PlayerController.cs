using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Animator playerAnimator;
    CharacterController _controller;
    private Vector3 lastMovement;
    private bool isJumping;
    [SerializeField] private float playerSpeed;

    void Start()
    {
        _controller = GetComponent<CharacterController>();
        playerSpeed = 5f;
        isJumping = false;
    }
    void Update()
    {
        if (Input.GetKey("space"))
        {
            StartCoroutine(Jump());
        }
        Move();
    } 
    void Move()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(moveX, 0, moveZ);
        lastMovement = movement;
        _controller.Move(movement * playerSpeed * Time.deltaTime);
        playerAnimator.SetBool("isWalking", true);
        if (movement != Vector3.zero)
        {
            transform.forward = lastMovement;
        }
        else
        {
            playerAnimator.SetBool("isWalking", false);
        }
    }
    IEnumerator Jump()
    {
        if (!isJumping)
        {
            playerAnimator.SetBool("isWalking", false);
            isJumping = true;

            Vector3 startPos = transform.position;
            Vector3 targetPos = startPos + new Vector3(0, 5f, 0);

            float elapsedTime = 0f;
            float duration = 0.3f;

            while (elapsedTime < duration)
            {
                float t = elapsedTime / duration;
                Vector3 newPosition = Vector3.Lerp(startPos, targetPos, t);

                _controller.Move((newPosition - transform.position) * playerSpeed * Time.deltaTime);

                elapsedTime += Time.deltaTime;
                yield return null;
            }

            _controller.Move((targetPos - transform.position) * playerSpeed * Time.deltaTime);

            targetPos = startPos + new Vector3(0, -5f, 0);

            elapsedTime = 0f;

            while (elapsedTime < duration)
            {
                float t = elapsedTime / duration;
                Vector3 newPosition = Vector3.Lerp(startPos, targetPos, t);

                _controller.Move((newPosition - transform.position) * playerSpeed * Time.deltaTime);

                elapsedTime += Time.deltaTime;
                yield return null;
            }

            _controller.Move((targetPos - transform.position) * playerSpeed * Time.deltaTime);

            isJumping = false;
            playerAnimator.SetBool("isWalking", true);
        }
    }
}
