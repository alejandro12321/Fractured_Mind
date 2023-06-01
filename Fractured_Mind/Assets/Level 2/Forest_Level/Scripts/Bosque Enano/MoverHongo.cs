using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoverHongo : MonoBehaviour, InterfaceInteractable
{
    [SerializeField] private string prompt;
    public string interactionPrompt => prompt;
    private float minX, maxX, minZ, maxZ, movementSpeed;
    public GameObject hongo, arbol, ManagerArbolDeLaVida;
    private Vector3 targetPosition;
    private bool isMoving;
    public Animation anim;
    private void Start()
    {
        prompt = "Tree of Life";
        minX = 30;
        maxX = 60;
        minZ = 230;
        maxZ = 260;
        movementSpeed = 2.0f;
        targetPosition = NewVector();
        isMoving = false;
    }
    public void StartMoving()
    {
        isMoving = true;
        prompt = "Fungi";
        transform.position = new Vector3(45.60f, -0.13f, 242.57f);
        IdleAninimation();
        StartCoroutine(Mover());
    }
    private Vector3 NewVector()
    {
        return new Vector3(Random.Range(minX, maxX), transform.position.y, Random.Range(minZ, maxZ));
    }
    IEnumerator Mover()
    {
        while (isMoving)
        {
            RunAnimation();
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, movementSpeed * Time.deltaTime);
            if (transform.position == targetPosition)
            {
                IdleAninimation();
                hongo.SetActive(false);
                arbol.SetActive(true);
                targetPosition = NewVector();
                yield return new WaitForSeconds(5f);
                hongo.SetActive(true);
                arbol.SetActive(false);
            }            
            yield return null;
        }     
    }
    public bool interact(Interactor interactor)
    {
        if (isMoving)
        {
            isMoving = false;
            hongo.SetActive(true);
            arbol.SetActive(false);
            DeathAnimation();
            GameObject.Find("Player").GetComponent<Inventario>().Madera = 0;
            ManagerArbolDeLaVida.GetComponent<ManagerArbolDeLaVida>().Checkear();
        }
        return true;
    }
    public void DeathAnimation()
    {
        anim.CrossFade("Death");
    }
    public void RunAnimation()
    {
        anim.CrossFade("Run");
    }
    public void IdleAninimation()
    {
        anim.CrossFade("Idle");
    }
}
