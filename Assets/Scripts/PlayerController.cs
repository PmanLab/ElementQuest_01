using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PlayerController : MonoBehaviour
{
    //--- �C���X�^���X ---
    private PlayerInputSystem playerInputSystem;
    private GameManager gameManager;

    //--- �s���p ---
    private Vector2 inputAxis;

    //--- �V���A���C�Y�ϐ� ---
    [SerializeField, Header("�ړ��X�s�[�h")] public float walkSpeed = 5.0f;
    [SerializeField, Header("���s�X�s�[�h")] public float runSpeed = 10.0f;
    [SerializeField, Header("�W�����v��")] public float jumpForce = 10.0f;

    //--- ���W�b�g�{�f�B ---
    private Rigidbody2D rb;

    //--- ���m�t���O ---
    bool isJump = false;
    bool isRun = false;
    bool isWalk = false;

    bool isGround = false;
    bool facingRight = false; // �v���C���[�̌�����ǐՂ��邽�߂̃t���O

    public static bool isPaused = false;

    //=== ���������� ===
    void Start()
    {
        playerInputSystem = new PlayerInputSystem();        // �C���X�^���X���擾
        playerInputSystem.Enable();                         // ���͎�t�J�n
        rb = GetComponent<Rigidbody2D>();                   // ���W�b�g�{�f�B���擾
        Flip();                                             // ������ԁF�E����
    }

    //=== �X�V���� ===
    void Update()
    {
        inputAxis = playerInputSystem.Player.Move.ReadValue<Vector2>();

        // ���Z�b�g���
        isRun = false;
        isWalk = false;

        //--- ���E �ړ�(����ړ�) ---
        if (inputAxis.x < 0 && playerInputSystem.Player.Run.IsPressed())
        {
            isRun = true;
            MoveLeft(runSpeed);
            Debug.Log("�� �_�b�V���ړ�");
        }

        else if (inputAxis.x < 0)
        {
            isWalk = true;
            MoveLeft(walkSpeed);
            Debug.Log("�� �ړ�");

        }

        else if (inputAxis.x > 0 && playerInputSystem.Player.Run.IsPressed())
        {
            isRun = true;
            MoveRight(runSpeed);
            Debug.Log("�E �_�b�V���ړ�");

        }

        else if (inputAxis.x > 0)
        {
            isWalk = true;
            MoveRight(walkSpeed);
            Debug.Log("�E �ړ�");
        }
        else
        {
            // ���͂��Ȃ��ꍇ�A���x���[���ɂ���
            StopMovement();
        }

        //--- �W�����v ---
        if (playerInputSystem.Player.Jump.triggered && isGround)
        {
            isJump = true;
            Jump();
            Debug.Log("�W�����v���܂����B");
        }

        //--- �|�[�Y��� ---
        if (playerInputSystem.Player.Pause.triggered && !isPaused)
        {
            isPaused = true;
            gameManager.SetGameState(GameManager.eGameState.Paused);
            Debug.Log("�|�[�Y��ʂ��J���܂����B");
        }
        else if (playerInputSystem.Player.Pause.triggered && isPaused)
        {
            isPaused = false;
            gameManager.SetGameState(GameManager.eGameState.Playing);
            Debug.Log("�|�[�Y��ʂ���܂����A�Q�[���ɖ߂�܂��B");
        }

        // �v���C���[�̌������X�V
        UpdateFacingDirection(inputAxis.x);
    }

    //=== �֐� ===
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
        rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
        isGround = false; // �W�����v�����̂Œn�ʂɂ��Ȃ��ƃt���O�𗧂Ă�
    }

    // �v���C���[�̌������X�V���郁�\�b�h
    void UpdateFacingDirection(float horizontalInput)
    {
        if (horizontalInput < 0 && facingRight)
        {
            Flip();
        }
        else if (horizontalInput > 0 && !facingRight)
        {
            Flip();
        }
    }

    // �v���C���[�̌����𔽓]���郁�\�b�h
    void Flip()
    {
        facingRight = !facingRight;
        Vector3 scaler = transform.localScale;
        scaler.x *= -1;
        transform.localScale = scaler;
    }

    //=== �Փ˔��� ���� ===
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //--- �n�ʂɐG��Ă��鎞 ---
        if (collision.gameObject.CompareTag("Ground") ||
            collision.gameObject.CompareTag("Scaffold") ||
            collision.gameObject.GetComponent<TilemapCollider2D>() != null)
        {
            isJump = false;
            isGround = true;
            Debug.Log("�n�ʂɐڒn");
        }
    }
}
