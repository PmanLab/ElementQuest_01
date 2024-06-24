using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMagicAttack : MonoBehaviour
{
    //=== 変数宣言 ===

    //--- 情報格納用インスタンス ---
    private GameObject playerObj;

    //--- 魔法Prefab格納用 ---
    [SerializeField, Header("火 魔法 初級 Prefab")] private GameObject Fire_Beginner;           // 火 初級
    [SerializeField, Header("火 魔法 中級 Prefab")] private GameObject Fire_Intermediate;       // 火 中級
    [SerializeField, Header("火 魔法 上級 Prefab")] private GameObject Fire_Advanced;           // 火 上級

    [SerializeField, Header("水 魔法 初級 Prefab")] private GameObject Water_Beginner;          // 水 初級
    [SerializeField, Header("水 魔法 中級 Prefab")] private GameObject Water_Intermediate;      // 水 中級
    [SerializeField, Header("水 魔法 上級 Prefab")] private GameObject Water_Advanced;          // 水 上級

    [SerializeField, Header("風 魔法 初級 Prefab")] private GameObject Wind_Beginner;           // 風 初級
    [SerializeField, Header("風 魔法 中級 Prefab")] private GameObject Wind_Intermediate;       // 風 中級
    [SerializeField, Header("風 魔法 上級 Prefab")] private GameObject Wind_Advanced;           // 風 上級

    [SerializeField, Header("土 魔法 初級 Prefab")] private GameObject Earth_Beginner;          // 土 初級
    [SerializeField, Header("土 魔法 中級 Prefab")] private GameObject Earth_Intermediate;      // 土 中級
    [SerializeField, Header("土 魔法 上級 Prefab")] private GameObject Earth_Advanced;          // 土 上級

    //--- 魔法 生成座標格納用 ---
    [SerializeField, Header("魔法 生成位置 左向き：X ] 座標調整")] private float fLeftOffSetX = 0.5f;         // 魔法 発射位置調整 X座標
    [SerializeField, Header("魔法 生成位置 右向き：X ] 座標調整")] private float fRightOffSetX = -0.5f;         // 魔法 発射位置調整 X座標
    [SerializeField, Header("魔法 生成位置 左向き：Y ] 座標調整")] private float fLeftOffSetY = 1.5f;         // 魔法 発射位置調整 Y座標
    [SerializeField, Header("魔法 生成位置 右向き：Y ] 座標調整")] private float fRightOffSetY = 1.5f;         // 魔法 発射位置調整 Y座標
    [SerializeField, Header("魔法 生成位置 左向き：Z ] 座標調整")] private float fLeftOffSetZ = 0.0f;         // 魔法 発射位置調整 Z座標
    [SerializeField, Header("魔法 生成位置 右向き：Z ] 座標調整")] private float fRightOffSetZ = 0.0f;         // 魔法 発射位置調整 Z座標

    //--- 魔法 ステータス情報 ---
    [SerializeField, Header("魔法の移動速度")] private float fSpeed = 2.0f;                     // 魔法 速度
    [SerializeField, Header("魔法の消滅時間")] private float fDestroyTime = 2.0f;               // 魔法の消滅時間

    private Vector3 offset; // プレイヤーの高さを考慮してオフセットを設定
    private Vector2 force;
    private Vector2 direction;

    //=== 初期化 ===
    private void Start()
    {
        playerObj = gameObject; // このスクリプトがアタッチされているオブジェクトをプレイヤーとする
        
        //--- プレイヤーの向きに合わせて生成位置を調整する ---
        if (playerObj.transform.localScale.x < 0)
        {
            offset = new Vector3(fLeftOffSetX, fLeftOffSetY, fLeftOffSetZ); // オフセットの調整
        }
        else
        {
            offset = new Vector3(fRightOffSetX, fRightOffSetY, fRightOffSetZ); // オフセットの調整
        }
    }

    private void Update()
    {
        //--- プレイヤーの向きに合わせて生成位置を調整する ---
        if (playerObj.transform.localScale.x < 0)
        {
            offset = new Vector3(fLeftOffSetX, fLeftOffSetY, fLeftOffSetZ); // オフセットの調整
        }
        else
        {
            offset = new Vector3(fRightOffSetX, fRightOffSetY, fRightOffSetZ); // オフセットの調整
        }
    }

    //=== 自作メソッド ===
    //--- 火魔法 ---
    public void FireBeginnerAttack()
    {
        // 魔法の複製 
        GameObject bullet = Instantiate(Fire_Beginner);

        // 弾丸の位置を調整
        bullet.transform.position = playerObj.transform.position + offset;

        // プレイヤーの向きに合わせて速度を設定
        Vector2 direction = playerObj.transform.localScale.x < 0 ? Vector2.right : Vector2.left;
        Vector2 force = direction * fSpeed;

        // プレイヤーが左を向いている場合はPrefabを反転させる
        if (playerObj.transform.localScale.x > 0)
        {
            bullet.transform.localScale = new Vector3(-bullet.transform.localScale.x, bullet.transform.localScale.y, bullet.transform.localScale.z);
        }

        // Rigidbody2Dに力を加えて発射
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.AddForce(force, ForceMode2D.Impulse);
        }

        // 指定した秒数後に弾丸を削除
        Destroy(bullet, fDestroyTime);
    }
    public void FireIntermediateAttack()
    {
        // 魔法の複製 
        GameObject bullet = Instantiate(Fire_Intermediate);

        // 弾丸の位置を調整
        bullet.transform.position = playerObj.transform.position + offset;

        // プレイヤーの向きに合わせて速度を設定
        Vector2 direction = playerObj.transform.localScale.x < 0 ? Vector2.right : Vector2.left;
        Vector2 force = direction * fSpeed;

        // プレイヤーが左を向いている場合はPrefabを反転させる
        if (playerObj.transform.localScale.x > 0)
        {
            bullet.transform.localScale = new Vector3(-bullet.transform.localScale.x, bullet.transform.localScale.y, bullet.transform.localScale.z);
        }

        // Rigidbody2Dに力を加えて発射
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.AddForce(force, ForceMode2D.Impulse);
        }

        // 指定した秒数後に弾丸を削除
        Destroy(bullet, fDestroyTime);
    }
    public void FireAdvancedAttack()
    {
        // 魔法の複製 
        GameObject bullet = Instantiate(Fire_Advanced);

        // 弾丸の位置を調整
        bullet.transform.position = playerObj.transform.position + offset;

        // プレイヤーの向きに合わせて速度を設定
        Vector2 direction = playerObj.transform.localScale.x < 0 ? Vector2.right : Vector2.left;
        Vector2 force = direction * fSpeed;

        // プレイヤーが左を向いている場合はPrefabを反転させる
        if (playerObj.transform.localScale.x > 0)
        {
            bullet.transform.localScale = new Vector3(-bullet.transform.localScale.x, bullet.transform.localScale.y, bullet.transform.localScale.z);
        }

        // Rigidbody2Dに力を加えて発射
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.AddForce(force, ForceMode2D.Impulse);
        }

        // 指定した秒数後に弾丸を削除
        Destroy(bullet, fDestroyTime);
    }

    //--- 水魔法 ---
    public void WaterBeginnerAttack()
    {
        // 魔法の複製 
        GameObject bullet = Instantiate(Water_Beginner);

        // 弾丸の位置を調整
        bullet.transform.position = playerObj.transform.position + offset;

        // プレイヤーの向きに合わせて速度を設定
        Vector2 direction = playerObj.transform.localScale.x < 0 ? Vector2.right : Vector2.left;
        Vector2 force = direction * fSpeed;

        // プレイヤーが左を向いている場合はPrefabを反転させる
        if (playerObj.transform.localScale.x > 0)
        {
            bullet.transform.localScale = new Vector3(-bullet.transform.localScale.x, bullet.transform.localScale.y, bullet.transform.localScale.z);
        }

        // Rigidbody2Dに力を加えて発射
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.AddForce(force, ForceMode2D.Impulse);
        }

        // 指定した秒数後に弾丸を削除
        Destroy(bullet, fDestroyTime);
    }
    public void WaterIntermediateAttack()
    {
        // 魔法の複製 
        GameObject bullet = Instantiate(Water_Intermediate);

        // 弾丸の位置を調整
        bullet.transform.position = playerObj.transform.position + offset;

        // プレイヤーの向きに合わせて速度を設定
        Vector2 direction = playerObj.transform.localScale.x < 0 ? Vector2.right : Vector2.left;
        Vector2 force = direction * fSpeed;

        // プレイヤーが左を向いている場合はPrefabを反転させる
        if (playerObj.transform.localScale.x > 0)
        {
            bullet.transform.localScale = new Vector3(-bullet.transform.localScale.x, bullet.transform.localScale.y, bullet.transform.localScale.z);
        }

        // Rigidbody2Dに力を加えて発射
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.AddForce(force, ForceMode2D.Impulse);
        }

        // 指定した秒数後に弾丸を削除
        Destroy(bullet, fDestroyTime);
    }
    public void WaterAdvancedAttack()
    {
        // 魔法の複製 
        GameObject bullet = Instantiate(Water_Advanced);

        // 弾丸の位置を調整
        bullet.transform.position = playerObj.transform.position + offset;

        // プレイヤーの向きに合わせて速度を設定
        Vector2 direction = playerObj.transform.localScale.x < 0 ? Vector2.right : Vector2.left;
        Vector2 force = direction * fSpeed;

        // プレイヤーが左を向いている場合はPrefabを反転させる
        if (playerObj.transform.localScale.x > 0)
        {
            bullet.transform.localScale = new Vector3(-bullet.transform.localScale.x, bullet.transform.localScale.y, bullet.transform.localScale.z);
        }

        // Rigidbody2Dに力を加えて発射
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.AddForce(force, ForceMode2D.Impulse);
        }

        // 指定した秒数後に弾丸を削除
        Destroy(bullet, fDestroyTime);
    }

    //--- 風魔法 ---
    public void WindBeginnerAttack()
    {
        // 魔法の複製 
        GameObject bullet = Instantiate(Wind_Beginner);

        // 弾丸の位置を調整
        bullet.transform.position = playerObj.transform.position + offset;

        // プレイヤーの向きに合わせて速度を設定
        Vector2 direction = playerObj.transform.localScale.x < 0 ? Vector2.right : Vector2.left;
        Vector2 force = direction * fSpeed;

        // プレイヤーが左を向いている場合はPrefabを反転させる
        if (playerObj.transform.localScale.x > 0)
        {
            bullet.transform.localScale = new Vector3(-bullet.transform.localScale.x, bullet.transform.localScale.y, bullet.transform.localScale.z);
        }

        // Rigidbody2Dに力を加えて発射
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.AddForce(force, ForceMode2D.Impulse);
        }

        // 指定した秒数後に弾丸を削除
        Destroy(bullet, fDestroyTime);
    }
    public void WindIntermediateAttack()
    {
        // 魔法の複製 
        GameObject bullet = Instantiate(Wind_Intermediate);

        // 弾丸の位置を調整
        bullet.transform.position = playerObj.transform.position + offset;

        // プレイヤーの向きに合わせて速度を設定
        Vector2 direction = playerObj.transform.localScale.x < 0 ? Vector2.right : Vector2.left;
        Vector2 force = direction * fSpeed;

        // プレイヤーが左を向いている場合はPrefabを反転させる
        if (playerObj.transform.localScale.x > 0)
        {
            bullet.transform.localScale = new Vector3(-bullet.transform.localScale.x, bullet.transform.localScale.y, bullet.transform.localScale.z);
        }

        // Rigidbody2Dに力を加えて発射
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.AddForce(force, ForceMode2D.Impulse);
        }

        // 指定した秒数後に弾丸を削除
        Destroy(bullet, fDestroyTime);
    }
    public void WindAdvancedAttack()
    {
        // 魔法の複製 
        GameObject bullet = Instantiate(Wind_Advanced);

        // 弾丸の位置を調整
        bullet.transform.position = playerObj.transform.position + offset;

        // プレイヤーの向きに合わせて速度を設定
        Vector2 direction = playerObj.transform.localScale.x < 0 ? Vector2.right : Vector2.left;
        Vector2 force = direction * fSpeed;

        // プレイヤーが左を向いている場合はPrefabを反転させる
        if (playerObj.transform.localScale.x > 0)
        {
            bullet.transform.localScale = new Vector3(-bullet.transform.localScale.x, bullet.transform.localScale.y, bullet.transform.localScale.z);
        }

        // Rigidbody2Dに力を加えて発射
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.AddForce(force, ForceMode2D.Impulse);
        }

        // 指定した秒数後に弾丸を削除
        Destroy(bullet, fDestroyTime);
    }
    //--- 土魔法 ---
    public void EarthBeginnerAttack()
    {
        // 魔法の複製 
        GameObject bullet = Instantiate(Earth_Beginner);

        // 弾丸の位置を調整
        bullet.transform.position = playerObj.transform.position + offset;

        // プレイヤーの向きに合わせて速度を設定
        Vector2 direction = playerObj.transform.localScale.x < 0 ? Vector2.right : Vector2.left;
        Vector2 force = direction * fSpeed;

        // プレイヤーが左を向いている場合はPrefabを反転させる
        if (playerObj.transform.localScale.x > 0)
        {
            bullet.transform.localScale = new Vector3(-bullet.transform.localScale.x, bullet.transform.localScale.y, bullet.transform.localScale.z);
        }

        // Rigidbody2Dに力を加えて発射
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.AddForce(force, ForceMode2D.Impulse);
        }

        // 指定した秒数後に弾丸を削除
        Destroy(bullet, fDestroyTime);
    }
    public void EarthIntermediateAttack()
    {
        // 魔法の複製 
        GameObject bullet = Instantiate(Earth_Intermediate);

        // 弾丸の位置を調整
        bullet.transform.position = playerObj.transform.position + offset;

        // プレイヤーの向きに合わせて速度を設定
        Vector2 direction = playerObj.transform.localScale.x < 0 ? Vector2.right : Vector2.left;
        Vector2 force = direction * fSpeed;

        // プレイヤーが左を向いている場合はPrefabを反転させる
        if (playerObj.transform.localScale.x > 0)
        {
            bullet.transform.localScale = new Vector3(-bullet.transform.localScale.x, bullet.transform.localScale.y, bullet.transform.localScale.z);
        }

        // Rigidbody2Dに力を加えて発射
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.AddForce(force, ForceMode2D.Impulse);
        }

        // 指定した秒数後に弾丸を削除
        Destroy(bullet, fDestroyTime);
    }
    public void EarthAdvancedAttack()
    {
        // 魔法の複製 
        GameObject bullet = Instantiate(Earth_Advanced);

        // 弾丸の位置を調整
        bullet.transform.position = playerObj.transform.position + offset;

        // プレイヤーの向きに合わせて速度を設定
        Vector2 direction = playerObj.transform.localScale.x < 0 ? Vector2.right : Vector2.left;
        Vector2 force = direction * fSpeed;

        // プレイヤーが左を向いている場合はPrefabを反転させる
        if (playerObj.transform.localScale.x > 0)
        {
            bullet.transform.localScale = new Vector3(-bullet.transform.localScale.x, bullet.transform.localScale.y, bullet.transform.localScale.z);
        }

        // Rigidbody2Dに力を加えて発射
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.AddForce(force, ForceMode2D.Impulse);
        }

        // 指定した秒数後に弾丸を削除
        Destroy(bullet, fDestroyTime);
    }
}
