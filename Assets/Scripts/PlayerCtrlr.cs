using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCtrlr : MonoBehaviour
{
    [Header("Life")]
    public Image lifeFill;
    float life = 1;

    [Header("Movement")]
    public float velocidad;
    float auxVelocidad;

    [Header("Grenade")]
    public float launchRate; // cantidad de balas que se pueden disparar por segundo
    float nextLaunch = 0.0f;
    static public bool granadazo; //evita interrumpir la animacion del lanzamiento de granda
    private bool IsTossing = false; //animator component
    public Text granadasText; 
    public static int granadas = 3;

    [Header("Assault Rifle")]
    public Transform firePoint; // Lugar de disparo de la bala
    public GameObject bullet;
    public float fireRate; // cantidad de balas que se pueden disparar por segundo
    public Text municionText;
    private int magazine = 60; // contador de las balas en el cargador
    //private Image[] bulletUI; // El cargador de balas en UI
    
    float nextFire = 0.0f;

    float caminarSFX = 0.0f;
    float walkingRate = 0.3f;
    

    [Header("Punch")]
    public  int combos;
    public  bool atacando;
    public Transform AP; //punto de ataque
    public float AR; //rango de ataque 
    public LayerMask enemy;
    public float damage; // el dano que hace al enemigo
    public bool noLoHagaCompa = false; //evita interrumpir la animacion de golpear

    [Header("Change Weapon")]
    //public Animator pCQC;
    //public Animator pAR;
    public SpriteRenderer pCQCSprite;
    public SpriteRenderer pARSprite;
    bool change = false;

    [Header("Player AR")]
    public Animator PAnimAR;
    public GameObject playerAR;
    private bool IsShootig; //animator Component
    public Instantiate instantiate;

    [Header("Player CQC")]
    public Animator PAnimCQC;
    public GameObject playerCQC;

    [Header("GameOver")]
    public GameObject gameOver;
    private Rigidbody2D rb;
    private Vector2 cntr;
    private SpriteRenderer activeSprite; // sprite actualmente en uso
    private PauseMenu pauseMenu;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        auxVelocidad = velocidad;
        pauseMenu = FindObjectOfType<PauseMenu>();
        pauseMenu.Resume(); // Evitamos que se quede congelado al volver al juego despues de la pausa
        granadas = 3;
    }

    

    // Update is called once per frame
    void Update()
    {

        municionText.text = "" + magazine;
        granadasText.text = "" + granadas;
        //asignamos los controles de movimiento base de unity, para ir tanto de manera horizontal como vertical
        cntr = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")); //usamos el sistema de movimineto que viene por defecto
        
        //if para el sonido de caminar
       if ((Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D)) && Time.time > caminarSFX)
        {
            caminarSFX = Time.time + walkingRate;
            Debug.Log("SONIDO ");
            SoundManager.PlaySound ("walk"); //Audio
        }
        PAnimAR.SetBool("IsWalking", cntr.magnitude != 0); //la velocidad es = 0
        PAnimCQC.SetBool("isWalking", cntr.magnitude != 0); //la velocidad es = 0

        // Al presionar G hacesmos la animacion de la granada
        if (Input.GetKeyDown(KeyCode.G) && Time.time > nextLaunch && granadas > 0)
        {
            nextLaunch = Time.time + launchRate;
            Debug.Log("Granada");
            PAnimAR.SetBool("ThrowG", IsTossing = true); //animacion de AR
            PAnimCQC.SetBool("throwG", IsTossing = true); //animacion de CQC
            SoundManager.PlaySound ("nadeToss"); //Audio
            granadazo = true;
        }
        else
        {
            PAnimAR.SetBool("ThrowG", IsTossing = false); //animacion de AR
            PAnimCQC.SetBool("throwG", IsTossing = false); //animacion de CQC
        }

        // Input para disparar
        if (Input.GetKey(KeyCode.F) && Time.time > nextFire && !change /*&&magazine > 0*/)
        {
            nextFire = Time.time + fireRate;
            if (magazine > 0) // Si hay balas en el cargador
            {
                SoundManager.PlaySound ("OneBulletFire"); //Audio
                Debug.Log("Disparo");
                PAnimAR.SetBool("Shooting", IsShootig = true);
                magazine--; // disminuye el cargador
                instantiate.shoot();
                //bulletUI[magazine].color = new Color( 1f, 1f, 1f, 0.1f); // cambiamos de color la bala en el UI
            }
            if (magazine == 0)
            {
                SoundManager.PlaySound ("emptyMag"); //Audio
            }
        }
        else
        {
            PAnimAR.SetBool("Shooting", IsShootig = false);
        }

        //Input para CQC
        if (Input.GetKeyDown(KeyCode.J) && !atacando && change)
        {
            if (combos == 0)
            {
                SoundManager.PlaySound ("firstPunch");
            }
            else if (combos == 1)
            {
                SoundManager.PlaySound ("secondPunch");
            }
            else
            {
                SoundManager.PlaySound ("thirdPunch");
            }
            atacando = true;
            noLoHagaCompa = true;
            PAnimCQC.SetTrigger("" + combos); //animacion de CQC
            ataque();
        }

        else
        {
            // PAnimCQC.SetBool("Punching", IsPunching = false);
        }
        if (Input.GetKeyDown(KeyCode.Y) && !noLoHagaCompa && !granadazo)
        {
            change = !change;
            pARSprite.enabled = !change;
            pCQCSprite.enabled = change;
            PAnimAR.enabled = !change;
            PAnimCQC.enabled = change;
        }

    }

    private void FixedUpdate() // FixedUpdate se usa normalmente para cuando se trata del rigidbody
    {
        velocidad = (pARSprite.enabled == true ) ? auxVelocidad : auxVelocidad + 50; // La velocidad es mas raro
        rb.velocity = new Vector2(cntr.x, cntr.y) * velocidad * Time.deltaTime;
        //establecemos la velocidad

        // Rota al personaje dependiendo de su axis
        if (cntr.x == 1)
        {
            transform.rotation = Quaternion.identity;
            //lowerChest.rotation = Quaternion.Euler(0, 0, 90);
        }
        else if (cntr.x == -1)
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
            //lowerChest.rotation = Quaternion.Euler(0, 180, 90);
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

    public void OnTriggerEnter2D(Collider2D _other) // Seccion de triggers que entran en contacto con el jugador
    {
        if(_other.tag == ("HealthPack"))
        {
            if (life < 1)
            {
                life = 1;
                lifeFill.fillAmount = life;
                SoundManager.PlaySound ("health"); //Audio
                Destroy(_other.gameObject);
            }
            else
            {
                Debug.Log("tienes toda la vida");
            }
        }

        if (_other.tag == ("municion"))
        {
            if (magazine < 60)
            {
                magazine = ((magazine + 10) > 60) ? 60 : magazine += 10;
                //sonido para recojer balas
                Destroy(_other.gameObject);
            }
            else
            {
                Debug.Log("tienes toda la municion");
            }
        }

        if (_other.tag == ("granada"))
        {
            if (granadas < 3)
            {
                granadas++;
                Destroy(_other.gameObject);
            }
            else
            {
                Debug.Log("tienes todas las granadas");
            }
        }

        if (_other.tag == ("Dano"))
        {
            SoundManager.PlaySound ("damagePlayer");  //Audio
            activeSprite = (pARSprite.enabled == true ) ? pARSprite : pCQCSprite; // Determinamos el sprite activo
            PlayerIsHurt(activeSprite); // llamamos la funcion para cambiar de color al personaje
            life -= 0.125f;
            lifeFill.fillAmount = life;
            Debug.Log("Vida " + lifeFill.fillAmount);
            if(lifeFill.fillAmount == 0 ) 
            {
                PAnimAR.SetBool("death", true);
                PAnimCQC.SetBool("Death", true);
                StartCoroutine("DeathScene");
            }
                
        }
    }

    private void PlayerIsHurt(SpriteRenderer spriteRendererActive){ 
        spriteRendererActive.color = new Color(239f,0f,0f,1f); // cambiamos el color del enemigo a un tono rojizo
        StartCoroutine("time", spriteRendererActive); // hacemos que pace un tiempo y despues vuelve a su color normal
    }

    private IEnumerator time(SpriteRenderer spriteRendererActive)
    {
        yield return new WaitForSeconds(.2f);
        spriteRendererActive.color = new Color(1f,1f,1f,1f);
    }
    public IEnumerator DeathScene()
    {
        yield return new WaitForSeconds(1.5f);
        Time.timeScale = 0f;
        gameOver.SetActive(true);
        Cursor.visible = true;
    }
    
}

