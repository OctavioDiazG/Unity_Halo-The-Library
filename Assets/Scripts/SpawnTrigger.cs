using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnTrigger : MonoBehaviour
{
    private SpawnSystem spawnSystem;
    // Start is called before the first frame update
    void Start()
    {
        spawnSystem = FindObjectOfType<SpawnSystem>();
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            Debug.Log("Spawner");
            spawnSystem.WaveSpawn(); // Llama la funcion para activar la oleada al tocar un Spawner
        }
    }
}
