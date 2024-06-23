using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIAnimation : MonoBehaviour
{
    //--- �i�[�p ---
    private Animator Anime;
    private GameManager gameManager;


    void Start()
    {
        gameManager = GameManager.Instance;     // GameManager���擾
        Anime = GetComponent<Animator>();       // Animator�����i�[
    }

    void Update()
    {
        //=== UI�A�j���[�V���� ===
        if (Anime != null)
        {
            //=== �U����� UI�A�j���[�V���� �؂�ւ� ===
            switch (gameManager.CurrentPlayerAttackMethod)
            {
                //--- �����U�� �A�j���[�V���� ---
                case GameManager.ePlayerAttackMethod.Physics:
                    if (!Anime.GetBool("Fist"))
                    {
                        Anime.SetBool("Fire", false);
                        Anime.SetBool("Water", false);
                        Anime.SetBool("Wind", false);
                        Anime.SetBool("Earth", false);
                        Anime.SetBool("Fist", true);
                    }

                    break;
                //=== ���@�U�� �A�j���[�V���� ===
                case GameManager.ePlayerAttackMethod.Magic:
                    if(Anime.GetBool("Fist"))
                    { Anime.SetBool("Fist", false); }

                    //--- �����ύX �A�j���[�V���� ---
                    switch (gameManager.CurrentPlayerAttributeState)
                    {
                        case GameManager.ePlayerAttributeState.Fire:
                            Anime.SetBool("Earth", false);
                            Anime.SetBool("Fire", true);

                            break;
                        case GameManager.ePlayerAttributeState.Water:
                            Anime.SetBool("Fire", false);
                            Anime.SetBool("Water", true);

                            break;
                        case GameManager.ePlayerAttributeState.Wind:
                            Anime.SetBool("Water", false);
                            Anime.SetBool("Wind", true);

                            break;
                        case GameManager.ePlayerAttributeState.Earth:
                            Anime.SetBool("Wind", false);
                            Anime.SetBool("Earth", true);

                            break;
                    }
                    break;
            }
        }
        else
        {
            Debug.Log("UIAnimation�FAnimetor��񂪂���܂���");
        }



    }
}
