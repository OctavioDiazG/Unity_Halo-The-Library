using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BulletCtrlr : MonoBehaviour
{
    public float speed; // velocidad del proyectil
    public float damage; // el daño que hace al enemigo

    private Rigidbody2D bulletRB2D; 

    private PlayerCtrlr playerCtrlr; // la referencia del jugador




    // Start is called before the first frame update
    void Start()
    {
        bulletRB2D = GetComponent<Rigidbody2D>();
        playerCtrlr = FindObjectOfType<PlayerCtrlr>();

        if( playerCtrlr.transform.localRotation.y != 0) // si el personaje gira hacia al otro lado
            speed = -speed; // la velocidad ira al reves
        
    }

    // Update is called once per frame
    void Update()
    {
        bulletRB2D.velocity = new Vector2(speed, bulletRB2D.velocity.y);
        Destroy(gameObject, 5); // destruimos el objeto en 5 segundos
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Enemy")
        {
            other.GetComponent<EnemyHealthManager>().DamageEnemy(damage); // Hace referencia al objeto con el que choca y llama la funcion para hacerle daño
            Destroy(gameObject); // Destruye la bala al contacto
        }
    }
}
