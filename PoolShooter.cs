using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolShooter : MonoBehaviour
{
    public float fireRate = 1f;

    float tempotiro;

    int estado;

    float force = 200;

    public Transform target,spawn;

    private void Start()
    {
        //InvokeRepeating("Fire", fireRate, fireRate);
    }

  

    private void Update()
    {
        

        print(1f / Time.deltaTime);
        tempotiro += Time.deltaTime;

        if (tempotiro>0.2f)
        {
            tempotiro = 0;

            estado = Random.Range(0, 1);

            Fire();

        }
        spawn.transform.Rotate(0, 0, 8);

        transform.rotation = Quaternion.LookRotation(target.position-transform.position);
    }


    void Fire()
    {
        GameObject obj = PoolerScript.current.GetPooledObject();

        if (obj == null) return;


        if (estado == 1)
        {
            obj.transform.rotation = transform.rotation;
            force = 200f;
        }
        else if (estado == 0)
        {
            obj.transform.rotation = transform.rotation;
            transform.rotation = Quaternion.identity;
            force = 500f;
        }


        obj.transform.position = transform.position;
        obj.SetActive(true);
        if (obj.GetComponent<Rigidbody>().velocity == Vector3.zero)
            obj.GetComponent<Rigidbody>().AddForce(transform.up * force);



    }
}
