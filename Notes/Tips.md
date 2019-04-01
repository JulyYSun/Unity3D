## 在update函数中实现隔一定时间调用一次方法
```
private float nextMoveTime = 0.0f;
private float deltaMoveTime = 1.0f;
void update(){
    if (Time.time > nextMoveTime)
    {
        nextMoveTime = Time.time + deltaMoveTime;
        //调用函数方法
    }

}
```
即可每一秒钟调用一次函数方法