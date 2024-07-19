using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{

    //=== �ϐ��錾 ===
    [SerializeField, Header("�G�̈ړ����x")] private float fSpeed = 2.0f;
    [SerializeField, Header("�G �W�����v�� ����")] private float fJumpForce = 5.0f;
    [SerializeField, Header("�G �W�����v�̊Ԋu ����")] private float fJumpInterval = 2.0f;
    [SerializeField, Header("�G ���̃W�����v�̎��� ����")] private float fNextJumpTime = 0f;
    //--- �i�[�p�C���X�^���X ---
    private GameObject playerObj;       // �v���C���[���i�[�p
    private Rigidbody2D rb;             // Rigidbody2D���i�[�p
    private EnemyState enemyState;      // �G��ޏ��i�[�p


    //--- ���m�p�t���O
    private bool bIsMove = false;      // �G������t���O
    private bool bIsGround = false;    // �n�ʐڐG�t���O

    //=== ���������� ===
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerObj = GameObject.FindGameObjectWithTag("Player"); // �v���C���[��T���Ċi�[
        enemyState = gameObject.GetComponent<EnemyState>();

    }

    //=== �X�V���� ===
    private void Update()
    {
        // �J�����̃r���[�|�[�g���W���擾
        Vector3 viewportPosition = Camera.main.WorldToViewportPoint(transform.position);

        // �G���J�����ɉf�������ǂ����𔻒�
        if (viewportPosition.x > 0 && viewportPosition.x < 1 && viewportPosition.y > 0 && viewportPosition.y < 1 && viewportPosition.z > 0)
        {
            bIsMove = true;             // �G�s���J�n  �t���OON
        }
        else
        {
            bIsMove = false;
            
        }

        // �G�������ꍇ�̏���
        if (bIsMove)
        {
            //--- �G �s���p�^�[�� ---
            switch (enemyState.EnemyType)
            { 
                // �X���C��
                case EnemyState.eEnemyType.Slime:
                    MoveTowardsPlayer();
                    if (bIsGround) { Jump(); }

                    break;
                default:
                    break;
            }
        }
        // �G�������Ȃ�ꍇ�̏���
        else
        {
            StopEnemy();
        }

    }

    //=== ���상�\�b�h ===
    //--- �G���E�����Ɉړ����� ---
    void MoveEnemy()
    {
        transform.Translate(Vector2.right * fSpeed * Time.deltaTime);
    }

    void MoveTowardsPlayer()
    {
        // �v���C���[�̈ʒu�Ɍ������Ĉړ�
        Vector2 direction = (playerObj.transform.position - transform.position).normalized;
        rb.velocity = new Vector2(direction.x * fSpeed, rb.velocity.y);
    }

    void StopEnemy()
    {
        // �G�̈ړ����~
        rb.velocity = Vector2.zero;
        rb.angularVelocity = 0f; // �p���x�����Z�b�g
    }

    void Jump()
    {
        // ���Ԋu�ŃW�����v����
        if (Time.time > fNextJumpTime)
        {
            rb.AddForce(Vector2.up * fJumpForce, ForceMode2D.Impulse);
            fNextJumpTime = Time.time + fJumpInterval;
            bIsGround = false;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // ���蔲���h�~�̂��߁A�n�ʂɐG��Ă��邩�ǂ����𔻒�
        if (collision.gameObject.CompareTag("Ground") ||
            collision.gameObject.CompareTag("Scaffold") ||
            collision.gameObject.CompareTag("Wall"))
        {
            bIsGround = true;
            rb.velocity = new Vector2(rb.velocity.x, 0);
        }
    }
}
