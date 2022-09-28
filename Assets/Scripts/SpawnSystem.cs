using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnSystem : MonoBehaviour
{
    public GameObject[] spawners;
    public GameObject[] waves;
    public GameObject[] zones;
    private int counter = 0;
    public int enemyDeaths;


    public void EnenyDeathsCheck()
    {
        Debug.Log(enemyDeaths);
        if(enemyDeaths == 4)
            Destroy( zones[0].gameObject );
        else if(enemyDeaths == 9)
            Destroy( zones[1].gameObject );
        else if(enemyDeaths == 14)
            Destroy( zones[2].gameObject );
        else if(enemyDeaths == 21)
            Destroy( zones[3].gameObject );

    }
    // Activa la oleada al tocar un Spawner
    public void WaveSpawn()
    {
        Debug.Log("Spawner #" + counter + " Activado");
        waves[counter].gameObject.SetActive(true);
        zones[counter].gameObject.SetActive(true);
        spawners[counter].gameObject.SetActive(false);
        counter++;
    }
}
