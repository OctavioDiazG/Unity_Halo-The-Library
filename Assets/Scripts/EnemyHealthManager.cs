using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthManager : MonoBehaviour
{
    public araña_ia araña;
    public combatForm_ia flood;
    public kamizake_IA kamikaze;
    public float enemyHealth; // Cantidad de vida del enemigo
    private SpriteRenderer enemySprite;
    private SpawnSystem spawnSystem;
    public Animator IF_Anim;
    private Color colorOG;
    bool muerto = false;
    
    int rand;

    private void Start()
    {
        enemySprite = GetComponent<SpriteRenderer>();
        spawnSystem = FindObjectOfType<SpawnSystem>();
        flood = GetComponent<combatForm_ia>();
        araña = GetComponent<araña_ia>();
        kamikaze = GetComponent<kamizake_IA>();
        colorOG = enemySprite.color;
    }


    public void DamageEnemy(float damage) 
    {
        
        //rand = Random.Range(Rmin, Rmax);
        
        enemyHealth -= damage; // Le resta el daño recibido a la vida
        enemyHealth = (enemyHealth <= 0) ? 0: enemyHealth;
        if( enemyHealth == 0 && !muerto)
        {
            muerto = true; 
            healthCheck(); //revisamos cuanta vida le queda
        }
        enemySprite.color = new Color(239f,0f,0f,1f); // cambiamos el color del enemigo a un tono rojizo
        StartCoroutine("changeColor"); // hacemos que pace un tiempo y despues vuelve a su color normal
    }

    public IEnumerator changeColor()
    {
        yield return new WaitForSeconds(.2f);
        enemySprite.color = colorOG;
    }


    private void healthCheck() // Checa si la vida llega a 0 para destruir el objeto
    {
        rand = Random.Range(0,2); // hacemos un numero random para determinar el tipo de muerte del enemigo
        
        if (araña != true && kamikaze !=true) // combat form
        {
            this.flood.GetComponent<combatForm_ia>().enabled = false; // Desactivamos el codigo para que ya no te siga
            StartCoroutine("animatorOFF"); // Apagamos la animacion despues de cierto tiempo

            if (rand == 0)
            {

                Debug.Log("Muerte 1");
                flood.enemy.SetBool("dead", /*flood.muerte = */true);
                SoundManager.PlaySound("deathCombatForm");
            }
            if (rand == 1)
            {

                Debug.Log("Muerte 2");
                flood.enemy.SetBool("dead2", /*flood.muerte = */true);
                SoundManager.PlaySound("deathCombatForm2");
            }
            flood.GetComponent<BoxCollider2D>().enabled = false;
            flood.GetComponent<Rigidbody2D>().simulated = false;
            // Destroy(gameObject); Rifate un comtador bishop
        }
        else if(araña != true && flood !=true && kamikaze == true) { // kamikaze
            Debug.Log("kamikaze muerto");
            SoundManager.PlaySound("deathCombatForm");
            kamikaze.enabled = false;
            kamikaze.enemy.SetBool("punching", true);
        }
        else // Araña
        {
            SoundManager.PlaySound("deathCombatForm");
            Destroy(this.araña.gameObject);
            // Aqui va la animacion
            IF_Anim.SetBool("muerte", true);
        }
        

    }

    private IEnumerator animatorOFF(){
        yield return new WaitForSeconds(1f);
        spawnSystem.enemyDeaths++; // aumenta el contador de enemigos muertos
        spawnSystem.EnenyDeathsCheck(); // Checamos cuantas muertes llevamos
        
        this.flood.GetComponent<Animator>().enabled = false; // Desactivamos el codigo para que ya no te siga
    }
}
