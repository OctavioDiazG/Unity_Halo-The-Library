using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeWeapon : MonoBehaviour
{

   /* public GameObject playerCQC;
    public GameObject playerAR; */
    public Animator pc;
    public Animator pa;
    public SpriteRenderer pcSprite;
    public SpriteRenderer paSprite;
    bool change = false;


    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Y))
        {
            
            change = !change;
           /* playerAR.SetActive(!change);
            playerCQC.SetActive(change); */
            paSprite.enabled = !change;
            pcSprite.enabled = change;
            pa.enabled = !change;
            pc.enabled = change;
        }
    }
}
