using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player; // �v���C���[��Transform
    public Vector3 offset; // �J�����ƃv���C���[�̑��Έʒu
    public float followSpeed = 5f; // �J�����̒Ǐ]���x

    void Start()
    {
        if (player == null)
        {
            Debug.LogError("�v���C���[��Transform���w�肳��Ă��܂���I");
            return;
        }

        // �����I�t�Z�b�g���v�Z
        offset = transform.position - player.position;
    }

    void LateUpdate()
    {
        if (player == null) return;

        // �J�����̖ڕW�ʒu���v�Z
        Vector3 targetPosition = player.position + offset;

        // �J�������X���[�Y�Ɉړ�������
        transform.position = Vector3.Lerp(transform.position, targetPosition, followSpeed * Time.deltaTime);

        // ��Ƀv���C���[�̕���������
        transform.LookAt(player);
    }
}
