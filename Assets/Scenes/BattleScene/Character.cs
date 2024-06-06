using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    float count = 0f;
    bool IsMoving = true;
    bool IsAttack = false;
    float AttackCount = 0f;
    float speed = 40.0f;

    GameObject TargetObj;

    [SerializeField]
    Animator Animator;

    [SerializeField]
    Transform PunchPos;

    void Update()
    {
        if (IsAttack)
        {
            AttackCount += Time.deltaTime;
            if (AttackCount > 1.5f)
            {
                AttackCount = 0f;
                IsAttack = false;
                IsMoving = true;
                Animator.SetBool("Punch", false);


                RaycastHit hit = new RaycastHit();
                hit.point = PunchPos.position;
                TargetObj.GetComponent<SimplestarGame.VoronoiFragmenter>().Fragment(hit);

                GameManager.instance.DestroyBill(TargetObj);
                TargetObj = null;
            }
        }
        else if(IsMoving && TargetObj != null)
        {
            Vector3 pos = transform.position;
            Vector3 direction = (TargetObj.transform.position - pos).normalized;
            //Debug.Log(TargetObj.transform.position + "" + (TargetObj.transform.position - pos));

            Quaternion targetRotation = Quaternion.LookRotation(direction);
            targetRotation.x = 0f;
            targetRotation.z = 0f;
            transform.rotation = targetRotation;

            Vector3 movement = transform.forward * speed * Time.deltaTime;
            movement.y = 0f;
            transform.position = pos + movement;

            Collider[] hitColliders = Physics.OverlapSphere(transform.position, 40.0f);
            foreach (var hitCollider in hitColliders)
            {
                if (hitCollider.gameObject == TargetObj)
                {
                    Debug.Log("Get");

                    Animator.SetBool("Punch", true);
                    Quaternion rotation = transform.rotation;
                    rotation.y += 0.4f;
                    transform.rotation = rotation;

                    count = 0;

                    IsMoving = false;
                    IsAttack = true;
                    break; 
                }
            }

        }else
        {
            count += Time.deltaTime;
            if (count > 1.0f)
            {
                count = 0;
                TargetObj = GameManager.instance.GetBillObj();

                if (TargetObj != null) IsMoving = true;

                //Debug.Log(TargetObj.name +""+ TargetObj.transform.position);
            }
        }
    }
}
