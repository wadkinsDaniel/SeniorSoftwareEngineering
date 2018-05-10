using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HotDogExplosion : MonoBehaviour
{
    public ParticleSystem explosion;
    public bool shake = false;
    public bool stop = false;
    float amount = 0f;


    private void Start()
    {
        explosion.Stop();
    }
    private void Update()
    {
        if (shake && !stop)
        {
            amount += 0.1f;
            Vector3 newpos = Random.insideUnitSphere * (Time.deltaTime * amount);
            newpos.x += transform.localPosition.x;
            newpos.y = transform.localPosition.y;
            newpos.z = transform.localPosition.z;

            transform.localPosition = newpos;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!stop)
        {
            
            shake = true;
            if (other.tag == "Player")
            {
                StartCoroutine(countDown());
            }
        }
    }

    IEnumerator countDown()
    {
        yield return new WaitForSeconds(2f);
        Explode();
        StopAllCoroutines();
    }

    void Explode()
    {
        explosion.Play();
        Destroy(gameObject);
    }


}
