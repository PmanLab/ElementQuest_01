using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicBullet : MonoBehaviour
{
    //=== ���������� ===
    void Start()
    {
        
    }

    //=== �X�V���� ===
    void Update()
    {
        // �J�����̃r���[�|�[�g���W���擾
        Vector3 viewportPosition = Camera.main.WorldToViewportPoint(transform.position);
        if (viewportPosition.x < 0 || viewportPosition.x > 1 || viewportPosition.y < 0 || viewportPosition.y > 1)
        {
            Destroy(gameObject);
        }
       
    }

    //=== �ڐG ���� ===
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground")   ||
            collision.gameObject.CompareTag("Scaffold") ||
            collision.gameObject.CompareTag("Wall")     ||
            collision.gameObject.CompareTag("Enemy")) 
        { Destroy(gameObject); }
    }
}
