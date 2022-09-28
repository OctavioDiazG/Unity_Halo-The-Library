using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kamizake_IA : MonoBehaviour
{
    public float velocidad;
    public bool atacando;
    public bool muerte;
    public Animator enemy;
    public  Rigidbody2D rb;
    public float rangoVision;
    public float rangoAtaque;
    public Transform ap;

    public GameObject Explosion;

    public GameObject parasito;



    // float ROAR_SFX = 0.0f;
    // float SoundRate = 0.3f;
    // bool rand;

    GameObject player;
    Vector3 posicionInical;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        posicionInical = transform.position;
        rb = GetComponent<Rigidbody2D>();
        enemy = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 target = posicionInical;

        RaycastHit2D hit = Physics2D.Raycast(transform.position, player.transform.position - transform.position, rangoVision,
            1 << LayerMask.NameToLayer("Default"));

        Vector3 foward = transform.TransformDirection(player.transform.position - transform.position);
        Debug.DrawRay(transform.position, foward, Color.red);

        if (hit.collider != null)
        {
            if (hit.collider.tag == "Player")
            {
                target = player.transform.position;
            }
        }

        float distance = Vector3.Distance(target, transform.position);
        Vector3 dir = (target - transform.position).normalized;

        if (target != posicionInical && distance < rangoAtaque)
        {
            enemy.SetBool("punching", atacando = true);
        
        }
        else
        {
            rb.MovePosition(transform.position + dir * velocidad * Time.deltaTime);
         
            enemy.SetBool("punching", atacando = false);
        }
        if (target == posicionInical && distance < 0.02f)
        {
            transform.position = posicionInical;
        }
        Debug.DrawLine(transform.position, target, Color.green);

        if (player.transform.position.x > transform.position.x)
        {
             transform.rotation = Quaternion.Euler(0, 180, 0);
           
            //lowerChest.rotation = Quaternion.Euler(0, 0, 90);
        }
        else if (player.transform.position.x < transform.position.x)
        {
            transform.rotation = Quaternion.identity;
            //lowerChest.rotation = Quaternion.Euler(0, 180, 90);
        }
    }


    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, rangoVision);
        Gizmos.DrawWireSphere(transform.position, rangoAtaque);
    }
    public void ataque_enemigo()
    {
      gameObject.GetComponent<BoxCollider2D>().enabled = false;
      gameObject.GetComponent<Rigidbody2D>().simulated = false;
    }

     private IEnumerator generacion() {
        Instantiate(Explosion, transform.position, transform.rotation);
        yield return new WaitForSeconds(0.6f);
        Destroy(gameObject);
        Instantiate(parasito, new Vector3(transform.position.x, transform.position.y, transform.position.z), transform.rotation);
        Instantiate(parasito, new Vector3(transform.position.x + 0.5f, transform.position.y + 0.5f, transform.position.z), transform.rotation);
        Instantiate(parasito, new Vector3(transform.position.x - 0.5f, transform.position.y - 0.5f, transform.position.z), transform.rotation);
     }
}
