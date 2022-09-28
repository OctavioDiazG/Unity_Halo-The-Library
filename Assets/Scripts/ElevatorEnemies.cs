using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorEnemies : MonoBehaviour
{
    private bool onGround = false;
    public araña_ia araña;
    public combatForm_ia combatForm;
    private EnemyHealthManager enemyHealthManager;
    bool activo = false;


    // Update is called once per frame
    void Update()
    {
        if(transform.position.y >= -2 && !onGround) // hace el efecto de caer moviendolo a la posicion deseada
            transform.Translate(Vector3.down * Time.deltaTime *10f);
        else
        {
            onGround = true;
            if(araña = GetComponent<araña_ia>()) // detecta si es una araña o un combat form para activar el codigo correspondiente
            {
                if(!activo)
                    araña.enabled = true;
                activo = true;
            }
            if(combatForm = GetComponent<combatForm_ia>()) 
            {
                if(!activo)
                    combatForm.enabled = true;
                activo = true;
            }
        }
    }
}
