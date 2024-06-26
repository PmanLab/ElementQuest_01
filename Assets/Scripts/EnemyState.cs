using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static GameManager;

public class EnemyState : MonoBehaviour
{

    //=== �񋓌^��` ===
    //--- �G�̐������ ���Ǘ������ ---
    private enum eEnemyState
    {
        Survival = 0,
        Death,
        MAX_ENEMYSTATE,
    }

    //--- ���@�ڐG���̑������� ���Ǘ������ ---
    private enum eHitMagicAttribute
    {
        Normal = 0,
        Fire,
        Water,
        Wind,
        Earth,
        MAX_HITMAGICATTRIBUTE,

    }
    
    //--- �G���� ���Ǘ������ ---
    private enum eEnemyAttribute
    {
        Fire = 0,
        Water,
        Wind,
        Earth,
        MAX_ENEMYATTRIBUTE,
    }

    //--- �G��ނ��Ǘ������
    public enum eEnemyType
    {
        Slime = 0,
        MAX_ENEMYTYPE,
    }

    //--- �i�[�p�C���X�^���X ---
    private GameManager gameManager;

    //=== �ϐ��錾 ===
    private eEnemyState CurrentEnemyState = eEnemyState.Survival;
    private eHitMagicAttribute hitMagicAttribute;
    [SerializeField, Header("�G ��� �I��")] public eEnemyType EnemyType;
    [SerializeField, Header("�G ���� �I��")] private eEnemyAttribute EnemyAttribute;
    [SerializeField, Header("�G HP ����")] private float fEnemyLives = 15.0f;

    //=== ���������� ===
    void Start()
    {
        gameManager = GameManager.Instance;                 // GameManager���擾
    }

    //=== �X�V���� ===
    void Update()
    {
    }

    //=== �ڐG ���� ===
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //--- ���� �U�������������� ---
        if (PlayerAttack.bIsAttack &&
            gameManager.CurrentPlayerAttackMethod == 
            ePlayerAttackMethod.Physics && 
            collision.gameObject.CompareTag("Player"))
        { LoseLife(eHitMagicAttribute.Normal); }

        //--- �� ���@������������ ---
        if (collision.gameObject.CompareTag("Fire_Beginner")) { LoseLife(eHitMagicAttribute.Fire); }
        if (collision.gameObject.CompareTag("Fire_Intermediate")) { LoseLife(eHitMagicAttribute.Fire); }
        if (collision.gameObject.CompareTag("Fire_Advanced")) { LoseLife(eHitMagicAttribute.Fire); }

        //--- �� ���@������������ ---
        if (collision.gameObject.CompareTag("Water_Beginner")) { LoseLife(eHitMagicAttribute.Water); }
        if (collision.gameObject.CompareTag("Water_Intermediate")) { LoseLife(eHitMagicAttribute.Water); }
        if (collision.gameObject.CompareTag("Water_Advanced")) { LoseLife(eHitMagicAttribute.Water); }

        //--- �� ���@������������ ---
        if (collision.gameObject.CompareTag("Wind_Beginner")) { LoseLife(eHitMagicAttribute.Wind); }
        if (collision.gameObject.CompareTag("Wind_Intermediate")) { LoseLife(eHitMagicAttribute.Wind); }
        if (collision.gameObject.CompareTag("Wind_Advanced")) { LoseLife(eHitMagicAttribute.Wind); }

        //--- �y ���@������������ ---
        if (collision.gameObject.CompareTag("Earth_Beginner")) { LoseLife(eHitMagicAttribute.Earth); }
        if (collision.gameObject.CompareTag("Earth_Intermediate")) { LoseLife(eHitMagicAttribute.Earth); }
        if (collision.gameObject.CompareTag("Earth_Advanced")) { LoseLife(eHitMagicAttribute.Earth); }

    }

    //=== ���상�\�b�h ===
    //--- �G�̐�����Ԃ�ݒ� ---
    private void SetEnemyState(eEnemyState newState)
    {
        CurrentEnemyState = newState;
        
        if(CurrentEnemyState == eEnemyState.Death)
        {
            Destroy(this.gameObject);
        }
    }

    //--- ���C�t�����������郁�\�b�h ---
    private void LoseLife(eHitMagicAttribute newState)
    {
        hitMagicAttribute = newState;

        //--- ���������`�F�b�N ---
        switch(hitMagicAttribute)
        {
            // ���� �U�����󂯂��Ƃ�
            case eHitMagicAttribute.Normal:
                fEnemyLives -= (PlayerAttack.fAttackLevel / 4.0f);
                break;
            // �� �������@���󂯂��Ƃ�
            case eHitMagicAttribute.Fire:
                switch (EnemyAttribute)
                {
                    case eEnemyAttribute.Fire:
                        fEnemyLives -= (PlayerAttack.fAttackLevel);
                        break;
                    case eEnemyAttribute.Water:
                        fEnemyLives -= (PlayerAttack.fAttackLevel / 2.0f);
                        break;
                    case eEnemyAttribute.Wind:
                        fEnemyLives -= (PlayerAttack.fAttackLevel * 2.0f);
                        break;
                    case eEnemyAttribute.Earth:
                        fEnemyLives -= (PlayerAttack.fAttackLevel / 1.5f);
                        break;
                }
                break;
            // �� �������@���󂯂��Ƃ�
            case eHitMagicAttribute.Water:
                switch (EnemyAttribute)
                {
                    case eEnemyAttribute.Fire:
                        fEnemyLives -= (PlayerAttack.fAttackLevel * 2.0f);
                        break;
                    case eEnemyAttribute.Water:
                        fEnemyLives -= (PlayerAttack.fAttackLevel);
                        break;
                    case eEnemyAttribute.Wind:
                        fEnemyLives -= (PlayerAttack.fAttackLevel / 2.0f);
                        break;
                    case eEnemyAttribute.Earth:
                        fEnemyLives -= (PlayerAttack.fAttackLevel / 1.5f);
                        break;
                }
                break;
            // �� �������@���󂯂��Ƃ�
            case eHitMagicAttribute.Wind:
                switch (EnemyAttribute)
                {
                    case eEnemyAttribute.Fire:
                        fEnemyLives -= (PlayerAttack.fAttackLevel / 2.0f);
                        break;
                    case eEnemyAttribute.Water:
                        fEnemyLives -= (PlayerAttack.fAttackLevel * 2.0f);
                        break;
                    case eEnemyAttribute.Wind:
                        fEnemyLives -= (PlayerAttack.fAttackLevel);
                        break;
                    case eEnemyAttribute.Earth:
                        fEnemyLives -= (PlayerAttack.fAttackLevel / 1.5f);
                        break;
                }
                break;
            // �y �������@���󂯂��Ƃ�
            case eHitMagicAttribute.Earth:
                switch (EnemyAttribute)
                {
                    case eEnemyAttribute.Fire:
                        fEnemyLives -= (PlayerAttack.fAttackLevel * 1.5f);
                        break;
                    case eEnemyAttribute.Water:
                        fEnemyLives -= (PlayerAttack.fAttackLevel / 1.5f);
                        break;
                    case eEnemyAttribute.Wind:
                        fEnemyLives -= (PlayerAttack.fAttackLevel * 1.5f);
                        break;
                    case eEnemyAttribute.Earth:
                        fEnemyLives -= (PlayerAttack.fAttackLevel);
                        break;
                }
                break;
        }

        if (fEnemyLives <= 0)
        {
            SetEnemyState(eEnemyState.Death);
        }


    }



}
