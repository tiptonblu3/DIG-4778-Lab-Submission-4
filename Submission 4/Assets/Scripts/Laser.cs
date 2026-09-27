using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        DestroyLaser();
        Move();
        
    }

    private void DestroyLaser()
    {
        if (transform.position.y > 11f)
        {
            Destroy(this.gameObject);
        }
    }
    
    private void Move()
    {
        transform.Translate(Vector3.up * Time.deltaTime * 8f);
    }

}
