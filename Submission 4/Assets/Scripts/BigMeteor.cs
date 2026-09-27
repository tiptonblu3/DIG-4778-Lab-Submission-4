using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigMeteor : MonoBehaviour
{
    private int hitCount = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Fall();
        CheckBounds();
        HealthCheck();
    }

    private void Fall()
    {
        transform.Translate(Vector3.down * Time.deltaTime * 0.5f);
    }

    private void CheckBounds()
    {
        if (transform.position.y < -11f)
        {
            Destroy(this.gameObject);
        }
    }

    private void HealthCheck()
    {
        if (hitCount >= 5)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D whatIHit)
    {
        if (whatIHit.tag == "Player")
        {
            GameObject.Find("GameManager").GetComponent<GameManager>().gameOver = true;
            Destroy(whatIHit.gameObject);
        }
        else if (whatIHit.tag == "Laser")
        {
            hitCount++;
            Destroy(whatIHit.gameObject);
        }
    }
}
