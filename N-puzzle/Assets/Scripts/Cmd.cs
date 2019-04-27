using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using UnityEngine;

public class Cmd : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
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
        string numbers = "";
        p.StandardInput.WriteLine(str);
        p.WaitForExit();
       // p.Close();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    string ChangeEncoding(string text)
    {
        byte[] bs = Encoding.GetEncoding("UTF-8").GetBytes(text);
        bs = Encoding.Convert(Encoding.GetEncoding("UTF-8"), Encoding.GetEncoding("GB2312"), bs);
        return Encoding.GetEncoding("GB2312").GetString(bs);
    }
   
}
