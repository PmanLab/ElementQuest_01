using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMagicAttack : MonoBehaviour
{
    //=== �ϐ��錾 ===

    //--- ���i�[�p�C���X�^���X ---
    private GameObject playerObj;

    //--- ���@Prefab�i�[�p ---
    [SerializeField, Header("�� ���@ ���� Prefab")] private GameObject Fire_Beginner;           // �� ����
    [SerializeField, Header("�� ���@ ���� Prefab")] private GameObject Fire_Intermediate;       // �� ����
    [SerializeField, Header("�� ���@ �㋉ Prefab")] private GameObject Fire_Advanced;           // �� �㋉

    [SerializeField, Header("�� ���@ ���� Prefab")] private GameObject Water_Beginner;          // �� ����
    [SerializeField, Header("�� ���@ ���� Prefab")] private GameObject Water_Intermediate;      // �� ����
    [SerializeField, Header("�� ���@ �㋉ Prefab")] private GameObject Water_Advanced;          // �� �㋉

    [SerializeField, Header("�� ���@ ���� Prefab")] private GameObject Wind_Beginner;           // �� ����
    [SerializeField, Header("�� ���@ ���� Prefab")] private GameObject Wind_Intermediate;       // �� ����
    [SerializeField, Header("�� ���@ �㋉ Prefab")] private GameObject Wind_Advanced;           // �� �㋉

    [SerializeField, Header("�y ���@ ���� Prefab")] private GameObject Earth_Beginner;          // �y ����
    [SerializeField, Header("�y ���@ ���� Prefab")] private GameObject Earth_Intermediate;      // �y ����
    [SerializeField, Header("�y ���@ �㋉ Prefab")] private GameObject Earth_Advanced;          // �y �㋉

    //--- ���@ �������W�i�[�p ---
    [SerializeField, Header("���@ �����ʒu �������FX ] ���W����")] private float fLeftOffSetX = 0.5f;         // ���@ ���ˈʒu���� X���W
    [SerializeField, Header("���@ �����ʒu �E�����FX ] ���W����")] private float fRightOffSetX = -0.5f;         // ���@ ���ˈʒu���� X���W
    [SerializeField, Header("���@ �����ʒu �������FY ] ���W����")] private float fLeftOffSetY = 1.5f;         // ���@ ���ˈʒu���� Y���W
    [SerializeField, Header("���@ �����ʒu �E�����FY ] ���W����")] private float fRightOffSetY = 1.5f;         // ���@ ���ˈʒu���� Y���W
    [SerializeField, Header("���@ �����ʒu �������FZ ] ���W����")] private float fLeftOffSetZ = 0.0f;         // ���@ ���ˈʒu���� Z���W
    [SerializeField, Header("���@ �����ʒu �E�����FZ ] ���W����")] private float fRightOffSetZ = 0.0f;         // ���@ ���ˈʒu���� Z���W

    //--- ���@ �X�e�[�^�X��� ---
    [SerializeField, Header("���@�̈ړ����x")] private float fSpeed = 2.0f;                     // ���@ ���x
    [SerializeField, Header("���@�̏��Ŏ���")] private float fDestroyTime = 2.0f;               // ���@�̏��Ŏ���

    private Vector3 offset; // �v���C���[�̍������l�����ăI�t�Z�b�g��ݒ�
    private Vector2 force;
    private Vector2 direction;

    //=== ������ ===
    private void Start()
    {
        playerObj = gameObject; // ���̃X�N���v�g���A�^�b�`����Ă���I�u�W�F�N�g���v���C���[�Ƃ���
        
        //--- �v���C���[�̌����ɍ��킹�Đ����ʒu�𒲐����� ---
        if (playerObj.transform.localScale.x < 0)
        {
            offset = new Vector3(fLeftOffSetX, fLeftOffSetY, fLeftOffSetZ); // �I�t�Z�b�g�̒���
        }
        else
        {
            offset = new Vector3(fRightOffSetX, fRightOffSetY, fRightOffSetZ); // �I�t�Z�b�g�̒���
        }
    }

    private void Update()
    {
        //--- �v���C���[�̌����ɍ��킹�Đ����ʒu�𒲐����� ---
        if (playerObj.transform.localScale.x < 0)
        {
            offset = new Vector3(fLeftOffSetX, fLeftOffSetY, fLeftOffSetZ); // �I�t�Z�b�g�̒���
        }
        else
        {
            offset = new Vector3(fRightOffSetX, fRightOffSetY, fRightOffSetZ); // �I�t�Z�b�g�̒���
        }
    }

    //=== ���상�\�b�h ===
    //--- �Ζ��@ ---
    public void FireBeginnerAttack()
    {
        // ���@�̕��� 
        GameObject bullet = Instantiate(Fire_Beginner);

        // �e�ۂ̈ʒu�𒲐�
        bullet.transform.position = playerObj.transform.position + offset;

        // �v���C���[�̌����ɍ��킹�đ��x��ݒ�
        Vector2 direction = playerObj.transform.localScale.x < 0 ? Vector2.right : Vector2.left;
        Vector2 force = direction * fSpeed;

        // �v���C���[�����������Ă���ꍇ��Prefab�𔽓]������
        if (playerObj.transform.localScale.x > 0)
        {
            bullet.transform.localScale = new Vector3(-bullet.transform.localScale.x, bullet.transform.localScale.y, bullet.transform.localScale.z);
        }

        // Rigidbody2D�ɗ͂������Ĕ���
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.AddForce(force, ForceMode2D.Impulse);
        }

        // �w�肵���b����ɒe�ۂ��폜
        Destroy(bullet, fDestroyTime);
    }
    public void FireIntermediateAttack()
    {
        // ���@�̕��� 
        GameObject bullet = Instantiate(Fire_Intermediate);

        // �e�ۂ̈ʒu�𒲐�
        bullet.transform.position = playerObj.transform.position + offset;

        // �v���C���[�̌����ɍ��킹�đ��x��ݒ�
        Vector2 direction = playerObj.transform.localScale.x < 0 ? Vector2.right : Vector2.left;
        Vector2 force = direction * fSpeed;

        // �v���C���[�����������Ă���ꍇ��Prefab�𔽓]������
        if (playerObj.transform.localScale.x > 0)
        {
            bullet.transform.localScale = new Vector3(-bullet.transform.localScale.x, bullet.transform.localScale.y, bullet.transform.localScale.z);
        }

        // Rigidbody2D�ɗ͂������Ĕ���
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.AddForce(force, ForceMode2D.Impulse);
        }

        // �w�肵���b����ɒe�ۂ��폜
        Destroy(bullet, fDestroyTime);
    }
    public void FireAdvancedAttack()
    {
        // ���@�̕��� 
        GameObject bullet = Instantiate(Fire_Advanced);

        // �e�ۂ̈ʒu�𒲐�
        bullet.transform.position = playerObj.transform.position + offset;

        // �v���C���[�̌����ɍ��킹�đ��x��ݒ�
        Vector2 direction = playerObj.transform.localScale.x < 0 ? Vector2.right : Vector2.left;
        Vector2 force = direction * fSpeed;

        // �v���C���[�����������Ă���ꍇ��Prefab�𔽓]������
        if (playerObj.transform.localScale.x > 0)
        {
            bullet.transform.localScale = new Vector3(-bullet.transform.localScale.x, bullet.transform.localScale.y, bullet.transform.localScale.z);
        }

        // Rigidbody2D�ɗ͂������Ĕ���
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.AddForce(force, ForceMode2D.Impulse);
        }

        // �w�肵���b����ɒe�ۂ��폜
        Destroy(bullet, fDestroyTime);
    }

    //--- �����@ ---
    public void WaterBeginnerAttack()
    {
        // ���@�̕��� 
        GameObject bullet = Instantiate(Water_Beginner);

        // �e�ۂ̈ʒu�𒲐�
        bullet.transform.position = playerObj.transform.position + offset;

        // �v���C���[�̌����ɍ��킹�đ��x��ݒ�
        Vector2 direction = playerObj.transform.localScale.x < 0 ? Vector2.right : Vector2.left;
        Vector2 force = direction * fSpeed;

        // �v���C���[�����������Ă���ꍇ��Prefab�𔽓]������
        if (playerObj.transform.localScale.x > 0)
        {
            bullet.transform.localScale = new Vector3(-bullet.transform.localScale.x, bullet.transform.localScale.y, bullet.transform.localScale.z);
        }

        // Rigidbody2D�ɗ͂������Ĕ���
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.AddForce(force, ForceMode2D.Impulse);
        }

        // �w�肵���b����ɒe�ۂ��폜
        Destroy(bullet, fDestroyTime);
    }
    public void WaterIntermediateAttack()
    {
        // ���@�̕��� 
        GameObject bullet = Instantiate(Water_Intermediate);

        // �e�ۂ̈ʒu�𒲐�
        bullet.transform.position = playerObj.transform.position + offset;

        // �v���C���[�̌����ɍ��킹�đ��x��ݒ�
        Vector2 direction = playerObj.transform.localScale.x < 0 ? Vector2.right : Vector2.left;
        Vector2 force = direction * fSpeed;

        // �v���C���[�����������Ă���ꍇ��Prefab�𔽓]������
        if (playerObj.transform.localScale.x > 0)
        {
            bullet.transform.localScale = new Vector3(-bullet.transform.localScale.x, bullet.transform.localScale.y, bullet.transform.localScale.z);
        }

        // Rigidbody2D�ɗ͂������Ĕ���
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.AddForce(force, ForceMode2D.Impulse);
        }

        // �w�肵���b����ɒe�ۂ��폜
        Destroy(bullet, fDestroyTime);
    }
    public void WaterAdvancedAttack()
    {
        // ���@�̕��� 
        GameObject bullet = Instantiate(Water_Advanced);

        // �e�ۂ̈ʒu�𒲐�
        bullet.transform.position = playerObj.transform.position + offset;

        // �v���C���[�̌����ɍ��킹�đ��x��ݒ�
        Vector2 direction = playerObj.transform.localScale.x < 0 ? Vector2.right : Vector2.left;
        Vector2 force = direction * fSpeed;

        // �v���C���[�����������Ă���ꍇ��Prefab�𔽓]������
        if (playerObj.transform.localScale.x > 0)
        {
            bullet.transform.localScale = new Vector3(-bullet.transform.localScale.x, bullet.transform.localScale.y, bullet.transform.localScale.z);
        }

        // Rigidbody2D�ɗ͂������Ĕ���
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.AddForce(force, ForceMode2D.Impulse);
        }

        // �w�肵���b����ɒe�ۂ��폜
        Destroy(bullet, fDestroyTime);
    }

    //--- �����@ ---
    public void WindBeginnerAttack()
    {
        // ���@�̕��� 
        GameObject bullet = Instantiate(Wind_Beginner);

        // �e�ۂ̈ʒu�𒲐�
        bullet.transform.position = playerObj.transform.position + offset;

        // �v���C���[�̌����ɍ��킹�đ��x��ݒ�
        Vector2 direction = playerObj.transform.localScale.x < 0 ? Vector2.right : Vector2.left;
        Vector2 force = direction * fSpeed;

        // �v���C���[�����������Ă���ꍇ��Prefab�𔽓]������
        if (playerObj.transform.localScale.x > 0)
        {
            bullet.transform.localScale = new Vector3(-bullet.transform.localScale.x, bullet.transform.localScale.y, bullet.transform.localScale.z);
        }

        // Rigidbody2D�ɗ͂������Ĕ���
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.AddForce(force, ForceMode2D.Impulse);
        }

        // �w�肵���b����ɒe�ۂ��폜
        Destroy(bullet, fDestroyTime);
    }
    public void WindIntermediateAttack()
    {
        // ���@�̕��� 
        GameObject bullet = Instantiate(Wind_Intermediate);

        // �e�ۂ̈ʒu�𒲐�
        bullet.transform.position = playerObj.transform.position + offset;

        // �v���C���[�̌����ɍ��킹�đ��x��ݒ�
        Vector2 direction = playerObj.transform.localScale.x < 0 ? Vector2.right : Vector2.left;
        Vector2 force = direction * fSpeed;

        // �v���C���[�����������Ă���ꍇ��Prefab�𔽓]������
        if (playerObj.transform.localScale.x > 0)
        {
            bullet.transform.localScale = new Vector3(-bullet.transform.localScale.x, bullet.transform.localScale.y, bullet.transform.localScale.z);
        }

        // Rigidbody2D�ɗ͂������Ĕ���
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.AddForce(force, ForceMode2D.Impulse);
        }

        // �w�肵���b����ɒe�ۂ��폜
        Destroy(bullet, fDestroyTime);
    }
    public void WindAdvancedAttack()
    {
        // ���@�̕��� 
        GameObject bullet = Instantiate(Wind_Advanced);

        // �e�ۂ̈ʒu�𒲐�
        bullet.transform.position = playerObj.transform.position + offset;

        // �v���C���[�̌����ɍ��킹�đ��x��ݒ�
        Vector2 direction = playerObj.transform.localScale.x < 0 ? Vector2.right : Vector2.left;
        Vector2 force = direction * fSpeed;

        // �v���C���[�����������Ă���ꍇ��Prefab�𔽓]������
        if (playerObj.transform.localScale.x > 0)
        {
            bullet.transform.localScale = new Vector3(-bullet.transform.localScale.x, bullet.transform.localScale.y, bullet.transform.localScale.z);
        }

        // Rigidbody2D�ɗ͂������Ĕ���
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.AddForce(force, ForceMode2D.Impulse);
        }

        // �w�肵���b����ɒe�ۂ��폜
        Destroy(bullet, fDestroyTime);
    }
    //--- �y���@ ---
    public void EarthBeginnerAttack()
    {
        // ���@�̕��� 
        GameObject bullet = Instantiate(Earth_Beginner);

        // �e�ۂ̈ʒu�𒲐�
        bullet.transform.position = playerObj.transform.position + offset;

        // �v���C���[�̌����ɍ��킹�đ��x��ݒ�
        Vector2 direction = playerObj.transform.localScale.x < 0 ? Vector2.right : Vector2.left;
        Vector2 force = direction * fSpeed;

        // �v���C���[�����������Ă���ꍇ��Prefab�𔽓]������
        if (playerObj.transform.localScale.x > 0)
        {
            bullet.transform.localScale = new Vector3(-bullet.transform.localScale.x, bullet.transform.localScale.y, bullet.transform.localScale.z);
        }

        // Rigidbody2D�ɗ͂������Ĕ���
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.AddForce(force, ForceMode2D.Impulse);
        }

        // �w�肵���b����ɒe�ۂ��폜
        Destroy(bullet, fDestroyTime);
    }
    public void EarthIntermediateAttack()
    {
        // ���@�̕��� 
        GameObject bullet = Instantiate(Earth_Intermediate);

        // �e�ۂ̈ʒu�𒲐�
        bullet.transform.position = playerObj.transform.position + offset;

        // �v���C���[�̌����ɍ��킹�đ��x��ݒ�
        Vector2 direction = playerObj.transform.localScale.x < 0 ? Vector2.right : Vector2.left;
        Vector2 force = direction * fSpeed;

        // �v���C���[�����������Ă���ꍇ��Prefab�𔽓]������
        if (playerObj.transform.localScale.x > 0)
        {
            bullet.transform.localScale = new Vector3(-bullet.transform.localScale.x, bullet.transform.localScale.y, bullet.transform.localScale.z);
        }

        // Rigidbody2D�ɗ͂������Ĕ���
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.AddForce(force, ForceMode2D.Impulse);
        }

        // �w�肵���b����ɒe�ۂ��폜
        Destroy(bullet, fDestroyTime);
    }
    public void EarthAdvancedAttack()
    {
        // ���@�̕��� 
        GameObject bullet = Instantiate(Earth_Advanced);

        // �e�ۂ̈ʒu�𒲐�
        bullet.transform.position = playerObj.transform.position + offset;

        // �v���C���[�̌����ɍ��킹�đ��x��ݒ�
        Vector2 direction = playerObj.transform.localScale.x < 0 ? Vector2.right : Vector2.left;
        Vector2 force = direction * fSpeed;

        // �v���C���[�����������Ă���ꍇ��Prefab�𔽓]������
        if (playerObj.transform.localScale.x > 0)
        {
            bullet.transform.localScale = new Vector3(-bullet.transform.localScale.x, bullet.transform.localScale.y, bullet.transform.localScale.z);
        }

        // Rigidbody2D�ɗ͂������Ĕ���
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.AddForce(force, ForceMode2D.Impulse);
        }

        // �w�肵���b����ɒe�ۂ��폜
        Destroy(bullet, fDestroyTime);
    }
}
