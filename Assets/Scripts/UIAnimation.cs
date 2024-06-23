using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIAnimation : MonoBehaviour
{
    //--- 格納用 ---
    private Animator Anime;
    private GameManager gameManager;


    void Start()
    {
        gameManager = GameManager.Instance;     // GameManagerを取得
        Anime = GetComponent<Animator>();       // Animator情報を格納
    }

    void Update()
    {
        //=== 属性変更 アニメーション ===
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

    }
}
