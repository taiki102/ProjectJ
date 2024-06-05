using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player; // プレイヤーのTransform
    public Vector3 offset; // カメラとプレイヤーの相対位置
    public float followSpeed = 5f; // カメラの追従速度

    void Start()
    {
        if (player == null)
        {
            Debug.LogError("プレイヤーのTransformが指定されていません！");
            return;
        }

        // 初期オフセットを計算
        offset = transform.position - player.position;
    }

    void LateUpdate()
    {
        if (player == null) return;

        // カメラの目標位置を計算
        Vector3 targetPosition = player.position + offset;

        // カメラをスムーズに移動させる
        transform.position = Vector3.Lerp(transform.position, targetPosition, followSpeed * Time.deltaTime);

        // 常にプレイヤーの方向を向く
        transform.LookAt(player);
    }
}
