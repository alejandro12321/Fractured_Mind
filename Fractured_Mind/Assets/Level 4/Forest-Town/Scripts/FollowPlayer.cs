using System.Collections;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public float detectionRadius = 10f;
    public float chasingSpeed = 5f;
    public float avoidanceDistance = 5f;
    public float stoppingDistance = 2f;

    private Animator wolfAnimator;
    private Transform player;
    private bool isChasing = false;

    private void Start()
    {
        wolfAnimator = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Update()
    {
        if (!isChasing && player != null)
        {
            float distance = Vector3.Distance(transform.position, player.position);
            if (distance <= detectionRadius)
            {
                StartChasing();
            }
        }

        if (isChasing)
        {
            ChasePlayer();
        }
    }

    private void StartChasing()
    {   
        PlayerController playerController = player.GetComponent<PlayerController>();
        if (playerController != null && !playerController._isStealth)
        {
            isChasing = true;
            wolfAnimator.SetBool("isWalking", true);
        }
    }

    private void ChasePlayer()
    {
        if (player == null)
            return;

        Vector3 direction = player.position - transform.position;
        direction.y = 0f;
        Quaternion rotation = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * 5f);

        float distance = Vector3.Distance(transform.position, player.position);

        if (distance > stoppingDistance)
        {
            RaycastHit hit;
            if (!Physics.Raycast(transform.position, direction, out hit, avoidanceDistance) || !hit.collider.CompareTag("Player"))
            {
                transform.Translate(Vector3.forward * chasingSpeed * Time.deltaTime);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (isChasing && other.CompareTag("Player"))
        {
            Debug.Log("¡El lobo ha atrapado al jugador!");
        }
    }
}
