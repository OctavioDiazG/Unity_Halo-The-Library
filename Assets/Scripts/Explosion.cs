using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    private SpriteRenderer explosion; 

     public int damage; // el daño que hace al enemigo
    // Start is called before the first frame update
    void Start()
    {
        explosion = GetComponent<SpriteRenderer>();
        StartCoroutine("afterExplosion");  
    }

    private IEnumerator afterExplosion() 
    {
       
        yield return new WaitForSeconds(0.5f);
        explosion.color = new Color(1,1,1,.9f);
        yield return new WaitForSeconds(.05f);
        explosion.color = new Color(1,1,1,.8f);
        yield return new WaitForSeconds(.05f);
        explosion.color = new Color(1,1,1,.7f);
        yield return new WaitForSeconds(.05f);
        explosion.color = new Color(1,1,1,.6f);
        yield return new WaitForSeconds(.05f);
        explosion.color = new Color(1,1,1,.5f);
        yield return new WaitForSeconds(.05f);
        explosion.color = new Color(1,1,1,.4f);
        yield return new WaitForSeconds(.05f);
        explosion.color = new Color(1,1,1,.3f);
        yield return new WaitForSeconds(.05f);
        explosion.color = new Color(1,1,1,.2f);
        yield return new WaitForSeconds(.05f);
        explosion.color = new Color(1,1,1,.1f);
        yield return new WaitForSeconds(.05f);
        explosion.color = new Color(1,1,1,0f);
        Destroy(gameObject); 
    }



   private void OnTriggerEnter2D (Collider2D other)
    {  if(other.tag == "Enemy")
        {
          
          other.GetComponent<EnemyHealthManager>().DamageEnemy(damage); // Hace referencia al objeto con el que choca y llama la funcion para hacerle daño 
          gameObject.GetComponent<CircleCollider2D>().enabled = false;  
          Debug.Log("se lo hizo mierda");
        }
    }
}
