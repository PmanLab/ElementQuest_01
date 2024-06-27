using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PlayerController : MonoBehaviour
{
    //--- �i�[�p�C���X�^���X ---
    private PlayerInputSystem playerInputSystem;
    private GameManager gameManager;

    //--- �s���p ---
    private Vector2 inputAxis;

    //--- �V���A���C�Y�ϐ� ---
    [SerializeField, Header("�ړ��X�s�[�h")] public float fWalkSpeed = 5.0f;
    [SerializeField, Header("���s�X�s�[�h")] public float fRunSpeed = 10.0f;
    [SerializeField, Header("�W�����v��")] public float fJumpForce = 10.0f;
    [SerializeField, Header("�_�Ŏ���")] public float fBlinkDuration = 1.0f;
    [SerializeField, Header("�_�ŊԊu")] public float fBlinkInterval = 0.1f;
    [SerializeField, Header("�ڐG���̒e���o����")] public float fKnockbackForce = 10.0f;

    //--- ���W�b�g�{�f�B ---
    private Rigidbody2D rb;

    //--- ���m�t���O ---
    public static bool bIsJump = false;      // �W�����v ���m�p
    public static bool bIsRun = false;       // ���� ���m�p
    public static bool bIsWalk = false;      // ���� ���m�p

    private bool bIsGround = false;
    private bool bIsFacingRight = false; // �v���C���[�̌�����ǐՂ��邽�߂̃t���O

    public static bool bIsPaused = false;

    //--- �_�ŏ����p ---
    private SpriteRenderer spriteRenderer;

    //=== ���������� ===
    void Start()
    {
        playerInputSystem = new PlayerInputSystem();        // �C���X�^���X���擾
        playerInputSystem.Enable();                         // ���͎�t�J�n
        rb = GetComponent<Rigidbody2D>();                   // ���W�b�g�{�f�B���擾
        gameManager = GameManager.Instance;                 // GameManager���擾
        spriteRenderer = GetComponent<SpriteRenderer>();    // �X�v���C�g�����_���[���擾
        Flip();                                             // ������ԁF�E����
    }

    //=== �X�V���� ===
    void Update()
    {
        inputAxis = playerInputSystem.Player.Move.ReadValue<Vector2>();

        // ���Z�b�g���
        bIsRun = false;
        bIsWalk = false;

        //--- �|�[�Y��� ---
        if (playerInputSystem.Player.Pause.triggered && !bIsPaused)
        {
            bIsPaused = true;
            gameManager.SetGameState(GameManager.eGameState.Paused);
            Debug.Log("�|�[�Y��ʂ��J���܂����B");
        }
        else if (playerInputSystem.Player.Pause.triggered && bIsPaused)
        {
            bIsPaused = false;
            gameManager.SetGameState(GameManager.eGameState.Playing);
            Debug.Log("�|�[�Y��ʂ���܂����A�Q�[���ɖ߂�܂��B");
        }

        //=== ��|�[�Y��ʎ� ���� ===
        if (!bIsPaused)
        {
            //--- ���E �ړ�(����ړ�) ---
            if (inputAxis.x < 0 && playerInputSystem.Player.Run.IsPressed())
            {
                bIsRun = true;
                MoveLeft(fRunSpeed);
                //Debug.Log("�� �_�b�V���ړ�");
            }
            else if (inputAxis.x < 0)
            {
                bIsWalk = true;
                MoveLeft(fWalkSpeed);
                //Debug.Log("�� �ړ�");
            }
            else if (inputAxis.x > 0 && playerInputSystem.Player.Run.IsPressed())
            {
                bIsRun = true;
                MoveRight(fRunSpeed);
                //Debug.Log("�E �_�b�V���ړ�");
            }
            else if (inputAxis.x > 0)
            {
                bIsWalk = true;
                MoveRight(fWalkSpeed);
                //Debug.Log("�E �ړ�");
            }
            else
            {
                // ���͂��Ȃ��ꍇ�A���x���[���ɂ���
                StopMovement();
            }

            //--- �W�����v ---
            if (playerInputSystem.Player.Jump.triggered && bIsGround)
            {
                bIsJump = true;
                Jump();
                //Debug.Log("�W�����v���܂����B");
            }

            // �v���C���[�̌������X�V
            UpdateFacingDirection(inputAxis.x);
        }
    }

    //=== ���상�\�b�h ===
    //--- ���ړ� ���� ---
    void MoveLeft(float speed)
    {
        rb.velocity = new Vector2(-speed, rb.velocity.y);
    }

    //--- �E�ړ� ���� ---
    void MoveRight(float speed)
    {
        rb.velocity = new Vector2(speed, rb.velocity.y);
    }

    //--- ��~ ���� ---
    void StopMovement()
    {
        rb.velocity = new Vector2(0, rb.velocity.y);
    }

    //--- �W�����v ���� ---
    void Jump()
    {
        rb.AddForce(new Vector2(0, fJumpForce), ForceMode2D.Impulse);
        bIsGround = false; // �W�����v�����̂Œn�ʂɂ��Ȃ��ƃt���O�𗧂Ă�
    }

    // �v���C���[�̌������X�V���郁�\�b�h
    void UpdateFacingDirection(float horizontalInput)
    {
        if (horizontalInput < 0 && bIsFacingRight)
        {
            Flip();
        }
        else if (horizontalInput > 0 && !bIsFacingRight)
        {
            Flip();
        }
    }

    // �v���C���[�̌����𔽓]���郁�\�b�h
    void Flip()
    {
        bIsFacingRight = !bIsFacingRight;
        Vector3 scaler = transform.localScale;
        scaler.x *= -1;
        transform.localScale = scaler;
    }

    //--- �G�ɐڐG���̏��������郁�\�b�h ---
    void EnemyContact(Collision2D collision)
    {
        // �v���C���[�̏�Ԃ��_���[�W��Ԃɐ؂�ւ�
        gameManager.SetPlayerState(GameManager.ePlayerState.TakeDamage);

        // �_�ŏ���
        StartCoroutine(BlinkEffect());

        // �_���[�W��������
        gameManager.LoseLife();

        // �G�ƂԂ��������ɏ����e����鏈��
    }

    //--- �_�ŏ��� ---
    IEnumerator BlinkEffect()
    {
        float endTime = Time.time + fBlinkDuration;
        while (Time.time < endTime)
        {
            spriteRenderer.enabled = !spriteRenderer.enabled;
            yield return new WaitForSeconds(fBlinkInterval);
        }
        // �_�ŏI����ɃX�v���C�g��\��
        spriteRenderer.enabled = true;

        // �v���C���[��Ԃ�ʏ�ɖ߂�
        gameManager.SetPlayerState(GameManager.ePlayerState.Normal);
    }

    //=== �Փ˔��� ���� ===
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // �n�ʂɐG��Ă��鎞
        if (collision.gameObject.CompareTag("Ground") ||
            collision.gameObject.CompareTag("Scaffold") ||
            collision.gameObject.GetComponent<TilemapCollider2D>() != null)
        {
            bIsJump = false;
            bIsGround = true;
        }

        // �G�ƐG��Ă��鎞
        if (!PlayerAttack.bIsAttack &&
            gameManager.CurrentPlayerState == 
            GameManager.ePlayerState.Normal &&
            collision.gameObject.CompareTag("Enemy"))
        {
            EnemyContact(collision);
        }
    }
}