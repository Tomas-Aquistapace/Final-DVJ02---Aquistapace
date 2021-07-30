using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopUpDamage : MonoBehaviour
{
    public int damageindicator = 10;

    private new Camera camera;
    void Start()
    {
        camera = GameObject.FindObjectOfType<Camera>();

        transform.LookAt(camera.transform, transform.forward);

        //transform.GetComponent<TextMesh>().text = damageString.ToString();
    }

    void Update()
    {
        
    }
}
