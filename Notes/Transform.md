## LocalPosition和Position的区别
LocalPosition是inspector面板上显示的坐标  
position是世界坐标系内的坐标  
对于ui控件，移动其位置用LocalPosition,Vector3.MoveTowards方法
```
oldImage.transform.localPosition = Vector3.MoveTowards(oldImage.transform.localPosition,
                newImage.transform.localPosition, speed);
```