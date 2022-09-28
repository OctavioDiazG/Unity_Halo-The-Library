using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class explosionFlood : MonoBehaviour
{
     private SpriteRenderer explosion; 
     private Transform tam; //el tamaño

    void Start()
    {
        explosion = GetComponent<SpriteRenderer>();
        tam = GetComponent<Transform>();
        StartCoroutine("afterExplosion");  
    }

    private IEnumerator afterExplosion() 
    {
        for (float i = 0.1f; i <= 1; i += 0.1f ){
        yield return new WaitForSeconds(0.02f);
        tam.localScale = new Vector3(i, i,1);
         }
        yield return new WaitForSeconds(0.2f);
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
    // Update is called once per frame
    void Update()
    {
        
    }
}
