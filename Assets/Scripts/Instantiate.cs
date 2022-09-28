using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instantiate : MonoBehaviour
{
    private PlayerCtrlr playerCtrlr; // la referencia del jugador

    [Header("Grenade")]
    public Transform launchPoint; // Lugar de lanzamiento de la granada
    public GameObject grenade;

    [Header("Bullet")]
    public Transform firePoint; // Lugar de disparo de la bala
    public Transform firePointFx; // Lugar de disparo de la bala
    public GameObject bullet;
    public GameObject bulletFx;


    private void Start()
    {
        playerCtrlr = FindObjectOfType<PlayerCtrlr>();

    }
    
    public void launchGrenade()
    {
        Debug.Log("Desde la instancia");
        Instantiate(grenade, launchPoint.position, transform.rotation);
    }
    public void terminar()
    {
        PlayerCtrlr.granadas--;
        PlayerCtrlr.granadazo = false;
    }

    public void shoot() {
        // Debug.Log("Desde la instancia disparar");
        Instantiate( bullet,firePoint.position, bullet.transform.rotation );

        if( playerCtrlr.transform.localRotation.y != 0)// si el personaje gira hacia al otro lado
        {
            Instantiate( bulletFx, firePointFx.position , Quaternion.Euler(firePoint.rotation.x, 0, firePoint.rotation.z));

        } else 
        {
            Instantiate( bulletFx, firePointFx.position , Quaternion.Euler(firePoint.rotation.x, -180, firePoint.rotation.z));
        }
    }
}
