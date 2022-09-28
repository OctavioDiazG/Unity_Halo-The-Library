using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorTrigger : MonoBehaviour
{
    private CameraMovement cameraMovement;
    public GameObject elevatorManager;

    private void Start()
    {
        cameraMovement = FindObjectOfType<CameraMovement>();
    
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player") // Activamos el evento del elevador
        {
            
            elevatorManager.SetActive(true);
            cameraMovement.elevator = true;
                
            cameraMovement.ElevatorVP(); // hacemos que la camara cambie su tamaño
            // cameraMovement.enabled = false;
            Destroy(gameObject);
        }
        
    }

    
}
