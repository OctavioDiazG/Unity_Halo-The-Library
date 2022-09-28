using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Combo : MonoBehaviour
{
    public  PlayerCtrlr jugador;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Star_combo()
    {
        jugador.atacando = false;
        if (jugador.combos < 3)
        {
            jugador.combos++;
        }
    }
    public void Finish_combo()
    {
        jugador.combos = 0;
        jugador.atacando = false;
        jugador.noLoHagaCompa = false;
   
    }

}
