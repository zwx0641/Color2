using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using LitJson;
using DG.Tweening;

public class ScoreManager : MonoBehaviour
{
    public GameObject itemObj;
    private List<Score> List = new List<Score>();
    public GameObject parentPanel;
    private Image panelImage;
    // Start is called before the first frame update
    void Start()
    {
        CreateJson();
        panelImage = parentPanel.GetComponent<Image>();
        //UpdateJson("11", 150);
    }
    private void CreateJson()
    {
        StreamReader sr = new StreamReader(Application.persistentDataPath + "/json.txt");
        string nextLine;
        while ((nextLine = sr.ReadLine()) != null)
        {
            List.Add(JsonUtility.FromJson<Score>(nextLine));
        }
        sr.Close();//将所有存储的分数全部存到list中    }
    }
    public void UpdateJson(string name, int score)
    {
        List.Add(new Score(name, score));//分数名字直接调变量，不用给出细节
    }
    private void ReadJson()
    {
        List.Sort();
        StreamWriter sw = new StreamWriter(Application.persistentDataPath + "/json.txt");
        if (List.Count > 7) for (int i = 7; i < List.Count; i++) List.RemoveAt(i);
        for (int i = 0; i < List.Count; i++)
        {
            sw.WriteLine(JsonUtility.ToJson(List[i]));
        }
        sw.Close();
    }

    public void UpdateScore()
    {
        if (parentPanel.activeSelf)
        {
            parentPanel.transform.DOScale(new Vector3(0.01f, 0.01f, 1), 0.5f);
            parentPanel.SetActive(false);
        }
        else
        {
            //UpdateJson(GetInput.name, 100);
            ReadJson();
            parentPanel.SetActive(true);

            for (int i = 0; i < 7; i++)
            {
                if (List[i] == null)
                {
                    break;
                }
                GameObject item = Instantiate(itemObj);
                item.gameObject.SetActive(true);
                item.transform.SetParent(parentPanel.transform);
                item.transform.localScale = new Vector3(0.9f, 0.9f, 0.45f);
                item.GetComponent<RectTransform>().position = new Vector3(0, 0, 0);
                item.transform.GetChild(0).GetComponent<Text>().text = (i + 1).ToString();
                item.transform.GetChild(1).GetComponent<Text>().text = List[i].name;
                item.transform.GetChild(2).GetComponent<Text>().text = List[i].score.ToString();
            }
        }
    }
}

public class Score : System.IComparable<Score>
{
    /// <summary>
    /// 玩家名字
    /// </summary>
    public string name;
    /// <summary>
    /// 玩家分数
    /// </summary>
    public int score;

    public Score(string n, int s) { name = n; score = s; }

    /// <summary>
    /// 实现接口 用于score的比较
    /// </summary>
    /// <param name="other"></param>
    /// <returns></returns>
    public int CompareTo(Score other)
    {
        if (other == null)
        {
            return 0;
        }
        int value = other.score - score;
        
        return value;
    }

    /// <summary>
    /// 重写tostring
    /// </summary>
    /// <returns></returns>
    public override string ToString()
    {
        return name + ":" + score;
    }
}
