using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicBullet : MonoBehaviour
{
    //=== 初期化処理 ===
    void Start()
    {
        
    }

    //=== 更新処理 ===
    void Update()
    {
        
    }

    //=== 接触 処理 ===
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground")   ||
            collision.gameObject.CompareTag("Scaffold") ||
            collision.gameObject.CompareTag("Wall")     ||
            collision.gameObject.CompareTag("Enemy")) 
        { Destroy(gameObject); }
    }
}
