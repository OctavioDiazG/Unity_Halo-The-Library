using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoopingBackground : MonoBehaviour
{
    public float backgroundSpeed;
    public Renderer bakgroundRenderer;
    private CameraMovement cameraMovement;
    

   
    private void Start() {
        bakgroundRenderer = GetComponent<Renderer>();
        cameraMovement = FindObjectOfType<CameraMovement>();
    }

    private void Update()
    {
        if(cameraMovement.elevator)
            bakgroundRenderer.material.mainTextureOffset += new Vector2(0f, backgroundSpeed * Time.deltaTime);
    }

    public IEnumerator transition() 
    {
        yield return new WaitForSeconds(1f);
        backgroundSpeed -= .01f;

        yield return new WaitForSeconds(1f);
        backgroundSpeed -= .01f;

        yield return new WaitForSeconds(1f);
        backgroundSpeed -= .01f;

        yield return new WaitForSeconds(1f);
        backgroundSpeed -= .01f;

        yield return new WaitForSeconds(1f);
        backgroundSpeed -= .01f;

        yield return new WaitForSeconds(1f);
        backgroundSpeed -= .01f;

        yield return new WaitForSeconds(1f);
        backgroundSpeed -= .01f;

        yield return new WaitForSeconds(1f);
        backgroundSpeed -= .01f;

        yield return new WaitForSeconds(1f);
        backgroundSpeed -= .01f;

    }


    
}
