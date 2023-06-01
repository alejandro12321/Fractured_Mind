using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactuar : MonoBehaviour
{
    public float distancia = 3f;

    ObjectMessage message;

    public GameObject prisionManager;
    private bool isFirstPrision;

    public GameObject dinningManager;
    private bool isFirstDinning;

    public GameObject storeHouseManager;
    private bool isFirstStoreHouse;

    public GameObject labManager;
    private bool isFirstLab;

    public GameObject LastManager;
    private bool isFirstManager;

    void Start() {
        
        isFirstPrision = true;
        isFirstDinning = true;
        isFirstStoreHouse = true;
        isFirstLab = true;
        isFirstManager = true;
    }

    void Update()
    {
        RaycastHit hit;

        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, distancia))
        {
            if (hit.collider.tag == "PrisionDoor")
            {
                if (Input.GetKeyDown(KeyCode.E) && prisionManager.GetComponent<PrisionPuzzle>().isPuzzleActive == false)
                {
                    hit.collider.transform.GetComponent<SistemDoor>().ChangeDoorState();
                }
                else if (Input.GetKeyDown(KeyCode.E) && prisionManager.GetComponent<PrisionPuzzle>().isPuzzleActive == true)
                {
                    message = hit.collider.transform.GetComponent<ObjectMessage>();
                    message.ActiveMessageState();

                    if (isFirstPrision)
                    {
                        isFirstPrision = false;
                        prisionManager.GetComponent<UIPuzzlesController>().ActivateUI();
                    }
                }
            }

            if (hit.collider.tag == "DinningDoor")
            {
                if (Input.GetKeyDown(KeyCode.E) && dinningManager.GetComponent<DinningPuzzle>().isPuzzleActive == false)
                {
                    hit.collider.transform.GetComponent<SistemDoor>().ChangeDoorState();
                }
                else if (Input.GetKeyDown(KeyCode.E) && dinningManager.GetComponent<DinningPuzzle>().isPuzzleActive == true)
                {
                    message = hit.collider.transform.GetComponent<ObjectMessage>();
                    message.ActiveMessageState();
                }
            }

            if (hit.collider.tag == "StoreHouseDoor")
            {
                if (Input.GetKeyDown(KeyCode.E) && storeHouseManager.GetComponent<StoreHousePuzzle>().isPuzzleActive == false)
                {
                    hit.collider.transform.GetComponent<SistemDoor>().ChangeDoorState();
                }
                else if (Input.GetKeyDown(KeyCode.E) && storeHouseManager.GetComponent<StoreHousePuzzle>().isPuzzleActive == true &&
                    storeHouseManager.GetComponent<StoreHousePuzzle>().riddlesActive == true)
                {
                    storeHouseManager.GetComponent<StoreHousePuzzle>().ActivateSelection();
                }
                else if (Input.GetKeyDown(KeyCode.E) && storeHouseManager.GetComponent<StoreHousePuzzle>().riddlesActive == false)
                {
                    message = hit.collider.transform.GetComponent<ObjectMessage>();
                    message.ActiveMessageState();
                }
            }

            if (hit.collider.tag == "LastDoor")
            {
                if (Input.GetKeyDown(KeyCode.E) && LastManager.GetComponent<StoreHousePuzzle>().isPuzzleActive == false)
                {
                    // Cambia de escena
                }
                else if (Input.GetKeyDown(KeyCode.E) && storeHouseManager.GetComponent<StoreHousePuzzle>().isPuzzleActive == true)
                {
                    if (isFirstManager)
                    {
                        LastManager.GetComponent<LastPuzzle>().activateLastPuzzle();
                    }
                    else
                    {
                        
                    }
                    
                }
            }

            if (hit.collider.tag == "Door")
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    hit.collider.transform.GetComponent<SistemDoor>().ChangeDoorState();
                }
            }

            if (hit.collider.tag == "LockedDoor" && labManager.GetComponent<LabPuzzle>().isPuzzleActive == false)
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    hit.collider.transform.GetComponent<SistemDoor>().ChangeDoorState();
                }
                else
                {
                    message = hit.collider.transform.GetComponent<ObjectMessage>();
                    message.ActiveMessageState();
                }
            }

            if (hit.collider.tag == "Objeto")
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    message = hit.collider.transform.GetComponent<ObjectMessage>();
                    message.ActiveMessageState();
                    
                    string objectName = hit.collider.gameObject.name;

                    if (prisionManager.GetComponent<PrisionPuzzle>().isPuzzleActive == true 
                        && prisionManager.GetComponent<UIPuzzlesController>().uiPanel.activeSelf)
                    {
                        prisionManager.GetComponent<PrisionPuzzle>().resolvePuzzle(objectName);
                    }

                    if (storeHouseManager.GetComponent<StoreHousePuzzle>().isPuzzleActive == true)
                    {
                        if (isFirstStoreHouse && objectName == "Puzzle_Almacen")
                        {
                            isFirstStoreHouse = false;
                            storeHouseManager.GetComponent<UIPuzzlesController>().ActivateUI();
                        }
                        else if (storeHouseManager.GetComponent<UIPuzzlesController>().uiPanel.activeSelf)
                        {
                            storeHouseManager.GetComponent<StoreHousePuzzle>().findKeys(objectName);
                        } 
                    }

                    if (dinningManager.GetComponent<DinningPuzzle>().isPuzzleActive == true)
                    {
                        if (isFirstDinning && objectName == "Puzzle_Comedor")
                        {
                            isFirstDinning = false;
                            dinningManager.GetComponent<UIPuzzlesController>().ActivateUI();
                            dinningManager.GetComponent<DinningPuzzle>().activePuzzle();
                        }
                        else if (objectName == "Key_Rusty")
                        {
                            dinningManager.GetComponent<DinningPuzzle>().keyFound();
                        }
                        else 
                        {
                            dinningManager.GetComponent<DinningPuzzle>().confusePlayer(objectName);
                        }
                    }

                    if (labManager.GetComponent<LabPuzzle>().isPuzzleActive == true)
                    {
                        if (isFirstLab && objectName == "Puzzle_Estudio")
                        {
                            isFirstLab = false;
                            labManager.GetComponent<UIPuzzlesController>().ActivateUI();
                        }
                        if (labManager.GetComponent<UIPuzzlesController>().uiPanel.activeSelf && objectName == "Receta_2")
                        {
                            labManager.GetComponent<UIPuzzlesController>().DeactivateUI();
                            labManager.GetComponent<LabPuzzle>().ActivateRecipe();
                        }
                        if (labManager.GetComponent<LabPuzzle>().fullObjects == true && objectName == "Caldero")
                        {
                            labManager.GetComponent<LabPuzzle>().ActivateSelection();
                        }
                        else if (labManager.GetComponent<LabPuzzle>().recipePanel.activeSelf)
                        {
                            labManager.GetComponent<LabPuzzle>().findObjects(objectName);
                        } 
                    }
                    
                }
            }
        }
        else
        {
            if (message != null)
            {
                message.DisableMessageState();
                message = null;
            }
        }
        
    }
}
