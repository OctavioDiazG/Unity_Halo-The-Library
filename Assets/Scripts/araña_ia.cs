using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class araña_ia : MonoBehaviour
{
    public float velocidad;
    public bool atacando;
    public bool muerte;
    public Animator enemy;
    public Rigidbody2D rb;
    public float rangoVision;
    public float rangoAtaque;
    public Transform ap;
    public BoxCollider2D dano;

    float danarSFX = 0.0f;
    public float danarRate = 2.0f; //variable que cada tanto quires que la araña dañe al marine

    // float ROAR_SFX = 0.0f;
    // float SoundRate = 0.3f;
    // bool rand;

    GameObject player;
    Vector3 posicionInical;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Lp");
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
            transform.position = player.transform.position;
            rangoAtaque = 5;
            dano.enabled = false;
            if (Time.time > danarSFX) {
                dano.enabled = true;
                danarSFX = Time.time + danarRate;
            }
     
        }
        else
        {
            rb.MovePosition(transform.position + dir * velocidad * Time.deltaTime);
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
        Gizmos.DrawWireSphere(ap.position, rangoAtaque);
    }
}
