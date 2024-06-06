using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameTest : MonoBehaviour
{
    //[SerializeField]
    //UIManager uIManager;

    [SerializeField]
    TextMeshProUGUI[] SlectionText = new TextMeshProUGUI[3];

    [SerializeField]
    TextMeshProUGUI MainText = new TextMeshProUGUI();

    public void Start()
    {
        MainText.text = "�琬�Q�[���@�v���g";
        //SetQuestion();
    }

    [SerializeField]
    GameObject a;

    public void StartButton()
    {
        MainText.text = "���t��I�����悤";
        a.gameObject.SetActive(false);
        SetQuestion();
    }

    public void Pushed(int x)
    {
        CheckCorrent(question[x]);
    }

    private void Update()
    {
        if (TurnEnd)
        {
            if (Count > 9)
            {
                //string text = string.Empty;
                for(int i =0; i< seleceted.Length; i++)
                {
                   Debug.Log(seleceted[i] + "\n");
                }
                MainText.fontSize = 50;
                MainText.text = $"Score : {Score}";
                return;
            }
            TurnEnd = false;
            SetQuestion();
        }
    }

    int CheckStringsPoint(string test)
    {
        if (CheckStrings(home, test))
        {
            return 10;
        }
        else if (CheckStrings(homenai, test))
        {
            return 5;
        }
        else
        {
            return 1;
        }
    }

    bool CheckStrings(string[] b,string c) 
    {
        foreach(string a in b)
        {
            if (a == c)
            {
                return true;
            }
        }
        return false;
    }

    void SetQuestion()
    {
        ToggleDisplay(true);

        question = new string[] { SetText(home), SetText(homenai), SetText(nai) };

        for (int i = 0; i < 10; i++)
        {
            int x = Random.Range(0, 3);
            string temp = question[x];
            question[x] = question[0];
            question[0] = temp;
        }

        for (int j = 0; j < 3; j++)
        {
            SlectionText[j].text = question[j];
        }
    }

    string[] question;
    string[] seleceted = new string[10];
    int Count = 0;

    bool TurnEnd = false;
    int Score = 0;

    public void CheckCorrent(string test)
    {
        seleceted[Count] = test;
        Count++;

        Score += CheckStringsPoint(test);

        TurnEnd = true;
        ToggleDisplay(false);
    }

    string SetText(string[] target)
    {
        List<string> pool = new List<string>();
        foreach(string a in target){
            pool.Add(a);
        }
        return pool[Random.Range(0, pool.Count)];
    }

    public void ToggleDisplay(bool IsOn)
    {
        if (IsOn)
        {
            for (int j = 0; j < SlectionText.Length; j++)
            {
                Vector3 pos = SlectionText[j].gameObject.transform.parent.localPosition;
                pos.y = 0f;
                SlectionText[j].gameObject.transform.parent.localPosition = pos;
            }
        }
        else
        {
            for (int j = 0; j < SlectionText.Length; j++)
            {
                Vector3 pos = SlectionText[j].gameObject.transform.parent.localPosition;
                pos.y = -600f;
                SlectionText[j].gameObject.transform.parent.localPosition = pos;
            }
        }
    }

    string[] home =
    {
        "�f���炵���d���ł���",
        "�w�͂��������т܂�����",
        "�ƂĂ��N���G�C�e�B�u�ł���",
        "��������ɂ��Ă��܂�",
        "�{���ɑf���炵���A�C�f�A�ł�",
        "���Ȃ��̂������ŏ�����܂���",
        "�ו��܂Œ��J�ł���",
        "�������������܂�����",
        "���Ȃ��̏�M���`����Ă��܂�",
        "�������ł�"
    };

    string[] homenai =
    {
        "�܂��܂��ǂ�������",
        "����������Ȃ���",
        "�撣�����ˁA�v�������",
        "�悭������ˁA���܂ɂ�",
        "���҂��ĂȂ��������ǁA������",
        "�܂��܂��̏o������",
        "�z���ȏゾ������",
        "�����͂�����������",
        "����Ȃ�ɗǂ�������",
        "�撣�����ˁA�ӊO��"
    };

    string[] nai =
    {
        "���������撣���Ă�",
        "���͂����Ɨǂ��ł���͂�",
        "�܂��A����Ȃ���",
        "����ŏI���H",
        "���������H�v���ė~����������",
        "���҂��Ă����́c",
        "���Ȃ��炵�����ʂł���",
        "���[��A���ʂ���",
        "����Ɋ��҂��Ă܂�",
        "�����͂Ȃ����ǁc"
    };
}
