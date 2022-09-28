using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorManager : MonoBehaviour
{
    public GameObject[] enemies;
    public float spawnRate;
    private float totalTime;
    private float spawnTime = 0.0f;
    private LoopingBackground loopingBackground;
    private CameraMovement cameraMovement;
    bool velocidadElevador = false;
    int counter = 0;

    

   
    private void Start() {
        cameraMovement = FindObjectOfType<CameraMovement>();
        loopingBackground = FindObjectOfType<LoopingBackground>();
        SoundManager.PlaySound("elevatorOn");
    }
    // Update is called once per frame
    void Update()
    {
        totalTime += Time.deltaTime; // Contamos el tiempo que ha transcurrido desde que inicia
        // Debug.Log(totalTime);
        if(totalTime < 50 && Time.time > spawnTime) // Mientras se cumple siguen apareciendo dependiendo del spawnRate que se coloque
        {
            spawnTime = Time.time + spawnRate; 
            enemies[counter].SetActive(true);
            counter++;
        }
        if(totalTime >= 50) 
        {   
            if(!velocidadElevador)
            {
                Debug.Log("Entro");
                loopingBackground.StartCoroutine("transition"); // empezamos a bjar la velocidad del elevador
                velocidadElevador = true;
            }
        }
        if(totalTime >= 60)
        {
            if(cameraMovement.elevator)
            {
                SoundManager.PlaySound("elevatorOff");
                cameraMovement.elevator = false;
                cameraMovement.ElevatorVP();
            
                StartCoroutine("timer");
            }
        }       
    }

    public IEnumerator timer(){
        yield return new WaitForSeconds(.5f);
        cameraMovement.fakeF.SetActive(true);
        Destroy(gameObject); 
    }   
}
