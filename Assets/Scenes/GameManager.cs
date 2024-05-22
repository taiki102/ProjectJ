using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    private void Awake()
    {
        instance = this; 
    }

    private void Start()
    {
        foreach (Transform child in BillParent.transform)
        {
            bill.Add(child.gameObject);
        }
    }

    [SerializeField]
    GameObject BillParent;

    [SerializeField]
    Transform Character;

    List<GameObject> bill = new List<GameObject>();

    public GameObject GetBillObj()
    {
        if (bill.Count <= 0) return null;
        int targetNum = 0;
        float x = Vector3.Distance(Character.position, bill[0].transform.position);
        for (int i = 0; i < bill.Count; i++)
        {
            float z = Vector3.Distance(Character.position, bill[i].transform.position);
            if (x > z)
            {
                x = z;
                targetNum = i;
            }
        }
        return bill[targetNum];
    }

    public GameObject GetBillObj(int a)
    {
        if (bill.Count <= 0) return null;

        int targetNum = 0;
        float closestDistance = Vector3.Distance(Character.position, bill[0].transform.position);

        for (int i = 1; i < bill.Count; i++)  // Start loop from 1, as we have already checked index 0
        {
            float currentDistance = Vector3.Distance(Character.position, bill[i].transform.position);
            if (currentDistance < closestDistance)
            {
                closestDistance = currentDistance;
                targetNum = i;
            }
        }
        return bill[targetNum];
    }

    public void DestroyBill()
    {
        if (bill.Count < 0) return;
        GameObject target = GetBillObj();
        bill.Remove(target);
        Destroy(target);
    }

}