using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    float count = 0f;
    bool IsAttack = false;
    float AttackCount = 0f;
    float speed = 50.0f;

    GameObject TargetObj;

    [SerializeField]
    Animator Animator;

    void Update()
    {
        if (IsAttack)
        {
            AttackCount += Time.deltaTime;
            if (AttackCount > 1.0f)
            {
                AttackCount = 0f;
                IsAttack = false;
                Animator.SetBool("Punch", false);

                GameManager.instance.DestroyBill();
            }
        }
        else
        {
            count += Time.deltaTime;
            if (count > 1.0f)
            {
                count = 0;
                TargetObj = GameManager.instance.GetBillObj();
            }
        }

        if (TargetObj != null)
        {
            Vector3 pos = transform.position;
            Vector3 plus = (TargetObj.transform.position - pos).normalized * speed * Time.deltaTime;

            transform.rotation = Quaternion.LookRotation(TargetObj.transform.position - pos);

            plus.y = 0f;
            transform.position = pos + plus;


            Collider[] hitColliders = Physics.OverlapSphere(pos, 25.0f);

            foreach (var hitCollider in hitColliders)
            {
                TargetObj = null;
                Animator.SetBool("Punch", true);
                count = 0;
                IsAttack = true;
            }
        }
    }
}
