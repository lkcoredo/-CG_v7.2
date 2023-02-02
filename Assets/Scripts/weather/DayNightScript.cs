using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayNightScript : MonoBehaviour
{
    public GameObject directLight;
    public float speed = 5;
    public float angle = 0;

    void ChangeAngle() {
        angle += speed;
        Quaternion rot = Quaternion.Euler(angle, 100, 0);
        directLight.transform.rotation = rot;
    }



    void Start()
    {
        //sun = GetComponent<Light>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        ChangeAngle();
        //sun.transform.Rotate(Vector3.left * speed * Time.deltaTime);
    }
}
