using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    [Header("Life")]
    //public Image lifeFill;


    [Header("Movement")]
    public float velocidad;

    [Header("Grenade")]
    public float launchRate; // cantidad de balas que se pueden disparar por segundo
    float nextLaunch = 0.0f;
    //private bool IsTossing = false; //animator component

    [Header("Assault Rifle")]
    public Transform firePoint; // Lugar de disparo de la bala
    public GameObject bullet;
    public float fireRate; // cantidad de balas que se pueden disparar por segundo
    //private Image[] bulletUI; // El cargador de balas en UI
    private int magazine = 60; // contador de las balas en el cargador
    float nextFire = 0.0f;

    [Header("Punch")]
    public  int combos;
    public  bool atacando;
    public Transform AP; //punto de ataque
    public float AR; //rango de ataque 
    public LayerMask enemy;
    public float damage; // el da�o que hace al enemigo
    

    [Header("Change Weapon")]
    bool change = false;

    [Header("Player AR")]
    public Animator PAnimAR;
    public GameObject playerAR;
    //private bool IsShootig; //animator Component
    public Instantiate instantiate;

    [Header("Player CQC")]
    public Animator PAnimCQC;
    public GameObject playerCQC;

    private Rigidbody2D rb;
    private Vector2 cntr;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        //asignamos los controles de movimiento base de unity, para ir tanto de manera horizontal como vertical
        cntr = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")); //usamos el sistema de movimineto que viene por defecto
        if(Input.GetKeyDown(KeyCode.Y) && !atacando)
        {
            change = !change;
            if (!change)
            {
                playerAR.SetActive(!change);
                AnimAR();
            }
            else
            {
                playerCQC.SetActive(change);
                AnimCQC();
            }
        }
    }

    private void FixedUpdate() // FixedUpdate se usa normalmente para cuando se trata del rigidbody
    {
        rb.velocity = new Vector2(cntr.x, cntr.y) * velocidad * Time.deltaTime;
        //establecemos la velocidad

        // Rota al personaje dependiendo de su axis
        if(cntr.x == 1)
        {
            transform.rotation = Quaternion.identity;
        }
        else if(cntr.x == -1)
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
    }

    public void ataque()
    {
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(AP.position, AR, enemy);
        foreach (Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<EnemyHealthManager>().DamageEnemy(damage);
            Debug.Log("danado");
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(AP.position, AR);
    }

    public void AnimAR()
    {
        PAnimAR.SetBool("IsWalking", cntr.magnitude != 0); //la velocidad es = 0
        //----------------------------------------------------------------------------------
        // Input para granada
        if(Input.GetKeyDown(KeyCode.G) && Time.time > nextLaunch)
        {
            nextLaunch = Time.time + launchRate;  
            Debug.Log("Granada_AR");
            PAnimAR.SetBool("ThrowG" , /*IsTossing =*/ true); //animacion de AR
        }
        else
        {
            PAnimAR.SetBool("ThrowG" , /*IsTossing =*/ false); //animacion de AR
        }
        //----------------------------------------------------------------------------------
        // Input para disparar
        if(Input.GetKey(KeyCode.F) && Time.time > nextFire && playerAR.activeSelf)
        {
            if(magazine >= 0) // Si hay balas en el cargador
            {
                Debug.Log("Disparo");
                nextFire = Time.time + fireRate; 
                PAnimAR.SetBool("Shooting" , /*IsShootig =*/ true);
                magazine--; // disminuye el cargador
                instantiate.shoot();
            }
        }
        else
        {
            PAnimAR.SetBool("Shooting" , /*IsShootig =*/ false);
        }
        //----------------------------------------------------------------------------------
    }

    public void AnimCQC()
    {
        PAnimCQC.SetBool("isWalking", cntr.magnitude != 0); //la velocidad es = 0
        //----------------------------------------------------------------------------------
        // Input para granada
        if(Input.GetKeyDown(KeyCode.G) && Time.time > nextLaunch)
        {
            nextLaunch = Time.time + launchRate;  
            Debug.Log("Granada_CQC");
            PAnimCQC.SetBool("throwG" , /*IsTossing =*/ true); //animacion de CQC
        }
        else
        {
            PAnimCQC.SetBool("throwG" , /*IsTossing =*/ false); //animacion de CQC
        }
        //----------------------------------------------------------------------------------
        //Input para CQC
        if( Input.GetKeyDown(KeyCode.J) && !atacando  && playerCQC.activeSelf)
        {
            atacando = true;
            PAnimCQC.SetTrigger("" + combos); //animacion de CQC
            ataque();
        }
    }
}

