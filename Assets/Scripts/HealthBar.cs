using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Image lifeFill;
    public Image lifeIcon;

    // Update is called once per frame
    void Update()
    {
        if (lifeFill.fillAmount <= 0.5f && lifeFill.fillAmount > 0.25f)
        {
            lifeFill.color = new Color(1f,0.8549687f,0f,1f);
            lifeIcon.color = new Color(1f,0.8549687f,0f,1f);
            //Debug.Log("se pone verde");
        }
        else if (lifeFill.fillAmount <= 0.25f)
        {
            lifeFill.color = new Color(255f,0f,0f,1f);
            lifeIcon.color = new Color(255f,0f,0f,1f);
        }
        else
        {
            lifeFill.color = new Color(1f,0.4605794f,0f,1f);
            lifeIcon.color = new Color(1f,0.4605794f,0f,1f);
            
        }
    }
}
