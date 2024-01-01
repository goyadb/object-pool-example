using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Bullet : MonoBehaviour
{
    public BulletPool BulletPool;
    Rigidbody rigidbody;
    float force = 1500f;
    float time = 0;
    float killTime = 3;

    private void Awake()
    {
        this.rigidbody = GetComponent<Rigidbody>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;

        if (time > killTime) 
        {
            this.gameObject.SetActive(false);
        }
    }

    public void Shoot()
    {
        rigidbody.AddForce(transform.forward * force);
    }

    private void OnTriggerEnter(Collider other)
    {
        this.gameObject.SetActive(false);
    }

    private void OnEnable()
    {
        this.transform.position = Vector3.zero;
    }

    private void OnDisable()
    {
        this.time = 0;
        rigidbody.velocity = Vector3.zero;
        BulletPool.AddBulletToPool(this);
    }
}
