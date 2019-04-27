using System.Collections;
using System.Collections.Generic;
using System.IO;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class Move2 : MonoBehaviour
{
    public Image[] Images;
    //用于存取每次变化的状态
    private static List<string> path =new List<string>();

    //比较两次不同的位置的列表，如果有不同位置，则获取两个下标存入列表
    static List<int> differentIndexList=new List<int>();
    private static int index = 0;

    private float nextMoveTime = 0;

    private float deltaMoveTime = 0.5f;

    private bool isMoving = true;
    // Start is called before the first frame update
    void Start()
    {
        path=ReadPath();
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > nextMoveTime && isMoving)
        {
            nextMoveTime = Time.time + deltaMoveTime;
            MovePos();

        }

    }

    public void MovePos()
    {
        
        //每次移动位置后路径的下标加一，循环每次比较当前状态和下一状态的不同元素的位置下标，用于交换位置
        for (int i = 0; i < 37; i++)
        {
            //每次只从状态中取一个字符，如果不同则说明该位置即将发生移动
            string char1 = path[index].Substring(i, 1);
            string char2=  path[index+1].Substring(i, 1);
            if (!char1.Equals(char2))
            {
                differentIndexList.Add(i);
            }
        }

        
        index++;
        Image oldImage = Images[differentIndexList[0]];
        Image newImage = Images[differentIndexList[1]];
        Image tempImage = oldImage;
        Vector3 tempPos = new Vector3();
        tempPos = oldImage.transform.position;
        //移动位置
        oldImage.transform.DOMove(newImage.transform.position, 0.36f);
        newImage.transform.DOMove(tempPos, 0.5f);
        Images[differentIndexList[0]] = newImage;
        Images[differentIndexList[1]] = tempImage;
        differentIndexList.Clear();
    }
    public static List<string> ReadPath()
    {
        // 读取文件的源路径及其读取流
        string strReadFilePath = @"path2";
        StreamReader srReadFile = new StreamReader(strReadFilePath);
        
        
        // 读取流直至文件末尾结束
        while (!srReadFile.EndOfStream)
        {
            string strReadLine = srReadFile.ReadLine(); //读取每行数据
            
            path.Add(strReadLine);
        }
        
        // 关闭读取流文件
        srReadFile.Close();
           
        
        return path;
    }
    public void Return()
    {
        Application.LoadLevel("Main");
    }
}
