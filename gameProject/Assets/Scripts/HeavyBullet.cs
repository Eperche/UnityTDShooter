using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeavyBullet : MonoBehaviour
{
    public float speed;
    public float lifeTime;
    public int damage;

    void Start()
    {
        Invoke("DestoryProjectile", lifeTime); //lifeTime zaman sonrasi bunu cağırır.
    }
 // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }
    public void DestoryProjectile()
    {
        Destroy(gameObject);

    }
}
