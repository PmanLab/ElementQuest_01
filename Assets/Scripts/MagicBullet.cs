using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicBullet : MonoBehaviour
{
    //=== ‰Šú‰»ˆ— ===
    void Start()
    {
        
    }

    //=== XVˆ— ===
    void Update()
    {
        
    }

    //=== ÚG ˆ— ===
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground")   ||
            collision.gameObject.CompareTag("Scaffold") ||
            collision.gameObject.CompareTag("Wall")     ||
            collision.gameObject.CompareTag("Enemy")) 
        { Destroy(gameObject); }
    }
}
