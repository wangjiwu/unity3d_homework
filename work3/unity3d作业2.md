# unity学习笔记2 

## 1.参考 Fantasy Skybox FREE 构建自己的游戏场景

![image](https://wx4.sinaimg.cn/mw690/b41a0581ly1fq7yr9n5cqj20rl0fv1kx.jpg)

![image](https://wx3.sinaimg.cn/mw690/b41a0581ly1fq7yr9u0jij20qm0fd1kx.jpg)

使用的资源而且添加了背景音

![image](https://wx4.sinaimg.cn/mw690/b41a0581ly1fq7yz3xpduj20em093gly.jpg)

## 2.写一个简单的总结，总结游戏对象的使用

（1）游戏对象是游戏中的每一个对象，每一个游戏对象都是一种容器。他们可以为空，可以是素材贴图，可以是其他对象的组成部分   
（2）游戏对象方我们进行游戏开发，我们可以在c#脚本里方便的创建，获取，删除游戏对象，而且也可以实现游戏对象的操作以及改变游戏对象的属性，实现游戏逻辑 

游戏对象总结
基本游戏对象类型有：  

Empty  
Camera摄像机  
Light光线  
3D物体  
Audio声音  

### Empty  
不显示却是最常用对象之一，所有游戏对象都有的属性： Active（标志是否活动，是否调用update()）
Name（对象的名字）Tag（字串可用来表示主摄像机）Layer（分组，选择性渲染）


### Camera摄像机  

观察游戏世界的窗口
1.使用透视视图和正交视图，可以改变视角   
常用参数：Background， 2.Culling Mask （剔除遮罩。用于指定摄像机所作用的层(Layer)）,Size, Depth(相机呈现先后属性)， ClippingPlanes（相机范围）Viewport Rect（屏幕坐标系）
3. 多摄像机 相关属性Clear Flag，
Culling mask， Depth

### Light光线  
光与影是让游戏世界富有魅力

1.相关属性——类型
灯光类型（type）
平行光（类似太阳光，一般默认就是这个）
聚光灯（spot）
点光源（point）
区域光（area，仅烘培用）
阴影（shallow）
剪影（cookies）


### 3D物体  
1. 网格与物体   

 所有物体包括立方体，圆都是网格
 
 2.显示组件
 Mesh 组件（物体表面三角网格）Mesh Renderer（表面渲染器）
 
3. 材质与着色器
Texture（纹理选择） Material（材质选择， 里面包括 meta-data设置材料的光线吸收、透明度、反射与漫反射、折射、自发
光、眩光等特性）

### Audio声音 

组件属性 AudioClip（音源）
loop， play（播放时机）




