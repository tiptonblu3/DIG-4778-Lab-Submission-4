using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meteor : MonoBehaviour
{
    public bool falling = true;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (falling)
        {
            transform.Translate(Vector3.down * Time.deltaTime * 2f);

            if (transform.position.y < -11f)
            {
                Destroy(this.gameObject);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D whatIHit)
    {
        if (whatIHit.tag == "Player")
        {
            GameObject.Find("GameManager").GetComponent<GameManager>().gameOver = true;
            Destroy(whatIHit.gameObject);
            Destroy(this.gameObject);
        } else if (whatIHit.tag == "Laser")
        {
            GameObject.Find("GameManager").GetComponent<GameManager>().meteorCount++;
            Destroy(whatIHit.gameObject);
            Destroy(this.gameObject);
        }
    }
}
