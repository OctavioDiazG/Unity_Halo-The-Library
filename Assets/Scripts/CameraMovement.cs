using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public float FollowSpeed = 2f;
    public float yOffset =1f;
    public Transform target;
    public Camera mainCamera;
    public bool elevator = false;
    public GameObject fakeF, fakeFE;
    private float startSize, startyOffSet;
    
    
    

    private void Start()
    {
        mainCamera = GetComponent<Camera>();
        startSize = mainCamera.orthographicSize;
        startyOffSet = yOffset;
    }

    // Update is called once per frame
    void Update()
    {
        if(!elevator)
        {
            Vector3 newPos = new Vector3(target.position.x, yOffset ,-10f);
            transform.position = Vector3.Slerp(transform.position,newPos,FollowSpeed*Time.deltaTime);
        }
    }

    public void ElevatorVP()
    {
        Debug.Log("Elevador");
        if(elevator)
            fakeF.SetActive((false));
        fakeFE.SetActive((elevator) ? true : false); // activamos/desactivamos los bordes del elevador
        if(elevator)
            StartCoroutine("transition", .5f); // cambiamos la posicion
        else
            StartCoroutine("transition", -.5f); // cambiamos la posicion
         
    }

    public IEnumerator transition(float x) 
    {
        Debug.Log(x);
        yield return new WaitForSeconds(.05f);
        mainCamera.orthographicSize += x;
        transform.position = (elevator) ? new Vector3(160f,(yOffset+=x) ,-10f) : new Vector3(target.position.x,(yOffset+=x) ,-10f);

        yield return new WaitForSeconds(.05f);
        mainCamera.orthographicSize += x;
        transform.position = (elevator) ? new Vector3(160.3125f, (yOffset+=x) ,-10f) : new Vector3(target.position.x,(yOffset+=x) ,-10f);

        yield return new WaitForSeconds(.05f);
        mainCamera.orthographicSize += x;
        transform.position = (elevator) ? new Vector3(160.625f, (yOffset+=x) ,-10f) : new Vector3(target.position.x,(yOffset+=x) ,-10f);

        yield return new WaitForSeconds(.05f);
        mainCamera.orthographicSize += x;
        transform.position = (elevator) ? new Vector3(160.9375f, (yOffset+=x) ,-10f) : new Vector3(target.position.x,(yOffset+=x) ,-10f);

        yield return new WaitForSeconds(.05f);
        mainCamera.orthographicSize += x;
        transform.position = (elevator) ? new Vector3(161.25f, (yOffset+=x) ,-10f) : new Vector3(target.position.x,(yOffset+=x) ,-10f);

        yield return new WaitForSeconds(.05f);
        mainCamera.orthographicSize += x;
        transform.position = (elevator) ? new Vector3(161.5625f, (yOffset+=x) ,-10f) : new Vector3(target.position.x,(yOffset+=x) ,-10f);

        yield return new WaitForSeconds(.05f);
        mainCamera.orthographicSize += x;
        transform.position = (elevator) ? new Vector3(161.875f, (yOffset+=x) ,-10f) : new Vector3(target.position.x,(yOffset+=x) ,-10f);

        yield return new WaitForSeconds(.05f);
        mainCamera.orthographicSize += x;
        transform.position = (elevator) ? new Vector3(162.1875f, (yOffset+=x) ,-10f) : new Vector3(target.position.x,(yOffset+=x) ,-10f);
        
        yield return new WaitForSeconds(.05f);
        mainCamera.orthographicSize += x;
        transform.position = (elevator) ? new Vector3(162.5f, (yOffset+=x) ,-10f) : new Vector3(target.position.x,(yOffset+=x) ,-10f);
        yield return new WaitForSeconds(.05f);
        mainCamera.orthographicSize += x;

    }


    
}
