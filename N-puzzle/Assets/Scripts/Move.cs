using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using Debug = UnityEngine.Debug;

public class Move : MonoBehaviour
{
    public Image[] images;
    private static List<string> path =new List<string>();
    private float nextMoveTime = 0.0f;
    public float speed;
    private Boolean isMoving=false;
    private float deltaMoveTime = 0.5f;
    private string numbersArgs;  //用于存储输入的数字顺序，提交给jar包的args参数
    private static int index;
    
    //输入格局的panel
    public GameObject NumPanel;
    public InputField[] InputFields;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void Awake()
    {
        
       
       
    }

    // Update is called once per frame
    void Update()
    {
        MovePath();   
    }
    public static List<string> ReadPath()
    {
            // 读取文件的源路径及其读取流
            string strReadFilePath = @"path";
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

    public void MovePath()
    {
        if (Time.time > nextMoveTime && isMoving)
        {
            nextMoveTime = Time.time + deltaMoveTime;

            string currentState = path[index];   //当前状态的移动
            index++;

            //获取移动的坐标
            int oldX = Convert.ToInt32(currentState.Substring(0, 1));
            int oldY = Convert.ToInt32(currentState.Substring(1, 1));
            int newX = Convert.ToInt32(currentState.Substring(2, 1));
            int newY = Convert.ToInt32(currentState.Substring(3, 1));
            //string info = " ";
            //info = info + oldX + oldY + newX + newY;
            //Debug.Log(info);
            Image oldImage = images[oldX*4+oldY];
            Image newImage= images[newX*4+newY];
            Image tempImage = oldImage;          
            Vector3 tempPos = new Vector3();
            tempPos = oldImage.transform.position;
            //使用dotween插件移动
            oldImage.transform.DOMove(newImage.transform.position, 0.36f);
            newImage.transform.DOMove(tempPos, 0.36f);
	        //移动两个滑块，交换其位置
//            tempPos = oldImage.transform.localPosition;
            
//            oldImage.transform.localPosition = Vector3.MoveTowards(oldImage.transform.localPosition,
//                newImage.transform.localPosition, speed);
//            newImage.transform.localPosition = Vector3.MoveTowards(newImage.transform.localPosition,
//                tempPos, speed);
	        //在inspector面板中的位置顺序交换
            images[oldX * 4 + oldY] = newImage;
            images[newX * 4 + newY] = tempImage;
        }
    }
    
    
    //开始执行按钮，生成对应的棋局
    public void OnGoButtonClick()
    {
//        Cmd();
//        Thread.Sleep( 3600);
        SetNumber();
        
        NumPanel.SetActive(false);
        isMoving = true;
        path = ReadPath();
    }

    public void Return()
    {
        Application.LoadLevel("Main");
    }
    
    //读取输入的格局并存入到移动格局上
    public void SetNumber()
    {
        for (int i = 0; i < 16; i++)
        {
            string currentNum = InputFields[i].text;
       
            string imgName = "MainPanel/Image (" + currentNum + ")";
            if (currentNum=="0")
            {
                imgName = "MainPanel/Image";
            }
            Debug.Log(imgName);
            images[i] = GameObject.Find(imgName).GetComponent<Image>();
        }
    }

    
    //此方法用于将jar包嵌入到Unity程序中时，调用jar包得出路径
    public void Cmd()
    {
        
        for (int i = 0; i < 16; i++)
        {
            string currentNum = InputFields[i].text+" ";
            numbersArgs += currentNum;
        }
        Process p=new Process();
        //将编码方式设置为和脚本文件一致，避免控制台乱码问题
        System.Console.InputEncoding = Encoding.UTF8;
        //设置要启动的应用程序
        p.StartInfo.FileName = "cmd.exe";
        
        // 接受来自调用程序的输入信息
        p.StartInfo.RedirectStandardInput = true;
        p.StartInfo.UseShellExecute = false;
        // 输出错误
        p.StartInfo.RedirectStandardError = true;
        //不显示程序窗口
        //p.StartInfo.CreateNoWindow = true;
        //启动程序
        p.Start();

        //调用jar包命令
        string str = "java -jar Searching.jar ";
        string strCmd = str + numbersArgs;
        p.StandardInput.WriteLine(strCmd);
        //p.WaitForExit();
        p.Close();
    }
}
