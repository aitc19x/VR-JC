# VR-JC 项目

[日本語](README.ja.md) [English](README.md) [한국어](README.kr.md)

---

## 介绍

最近，VR 成为了一项流行的技术，让我们可以足不出户地体验不同的地点。为了推动中日友谊和双方技术交流，我们启动了此项目。

三个学生组织，日本明石高专信息工学研究社、江西师大附中信息技术社、Crystal 日本文化研究小组合作为观看者提供更好的体验。

此项目使用 Google Cardboard、Google ARCore 和 Unity C#。并且国际化工作包含日文、英文、中文和韩文。

欢迎使用并基于 GPL v3 协议向我们的项目作出贡献。

关于进度，请浏览“Project”标签。

---

## 开发环境

推荐使用 Unity 2019.4 LTS，并要求使用 Unity 2019.3.12 或更新的版本。

在编译项目之前请确保导入了 [arcore-unity-sdk-1.15.0.unitypackage](https://github.com/google-ar/arcore-unity-sdk/releases/download/v1.18.0/arcore-unity-sdk-1.15.0.unitypackage)。

将 ```/Packages/manifest.json.tmpl``` 改为 ```/Packages/manifest.json``` 来安装必要的包。

#### 对于在中国内的开发者

解压 [cardboard-xr-plugin-master.zip](https://github.com/googlevr/cardboard-xr-plugin/archive/master.zip) 并修改 ```/Packages/manifest.json``` 的第三行为如下格式：

```json
"com.google.xr.cardboard": "file:/path/to/cardboard-xr-plugin-master",
```

#### 对于在中国外的开发者

```/Packages/manifest.json``` 的第三行应为：

```json
"com.google.xr.cardboard": "https://github.com/googlevr/cardboard-xr-plugin.git",
```

---

## 联系

明石高专信息工学研究社（日本）的推特：https://twitter.com/jyoken/

江西师大附中中美国际学校（中国）信息技术社的官网：https://aitc.cstu.xyz/

Crystal日本文化研究小组（中国）的官网：https://cnk.cstu.xyz/
