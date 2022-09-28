using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grenade : MonoBehaviour
{
    public GameObject explotion; 
    public GameObject grenade;
    public float Speed ;// velocidad de lanzamiento de la granada
   


    // Start is called before the first frame update 5 seconds
    void Start()
    {

        GetComponent<Rigidbody2D>().AddForce((transform.right + Vector3.up) * Speed, ForceMode2D.Impulse); // Lanza la granada a 45grados
        
        Destroy(gameObject, 5); // Destruye la granada despues de 5 segundos
    }

    // Cuando entra en contacto con un enemigo se destruyen
   private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Enemy")
        {
            Destroy(gameObject); // Destruye la bala al contact
            Debug.Log("Destruir enemigo");
            SoundManager.PlaySound ("nadeExplosion"); //Audio
            Instantiate(explotion, grenade.transform.position, transform.rotation);
        } 
        else if(other.tag == "FakeFloor")
        {
            Destroy(gameObject); // Destruye la bala al contacto
            SoundManager.PlaySound ("nadeExplosion"); //Audio
            Instantiate(explotion, grenade.transform.position, transform.rotation);
        }
    }
}