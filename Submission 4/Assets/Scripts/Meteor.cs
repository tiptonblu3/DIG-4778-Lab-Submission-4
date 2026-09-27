using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meteor : MonoBehaviour
{
    public bool falling = true;

    public static event Action OnPlayerHit;
    public static event Action OnMeatorDestroyedByLaser;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CheckBounds();
        Fall();
    }

    private void Fall()
    {
        transform.Translate(Vector3.down * Time.deltaTime * 2f);
    }

    private void CheckBounds()
    {
        if (transform.position.y < -11f)
            {
                Destroy(this.gameObject);
            }
    }


    private void OnTriggerEnter2D(Collider2D whatIHit)
    {
        if (whatIHit.tag == "Player")
        {
            //GameObject.Find("GameManager").GetComponent<GameManager>().gameOver = true;
            OnPlayerHit?.Invoke();
            Destroy(whatIHit.gameObject);
            Destroy(this.gameObject);
        } else if (whatIHit.tag == "Laser")
        {
            //GameObject.Find("GameManager").GetComponent<GameManager>().meteorCount++;
            OnMeatorDestroyedByLaser?.Invoke();
            Destroy(whatIHit.gameObject);
            Destroy(this.gameObject);
        }
    }
}
