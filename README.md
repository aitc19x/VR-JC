# Project VR-JC

[日本語](README.ja.md) [中文](README.zh.md) [한국어](README.kr.md)

---

## Introduction

Recently, VR becomes a popular technology, which enables us to explore without going to real places by devices such as Google Cardboard. In order to prolong the friendship between Japan and China, the project was proposed.

The three organizations, Akashi Jyoken, AMSJXNU IT Club, and Crystal Nippon Bunka Kenkyu Group, are cooperated in order to convey a better experience to viewers.

This project uses Google VR, Google ARCore, and Unity C#. And i18n of this project contains Japanese, English, Chinese, and Korean.

Welcome to use and contribute to our project along with GPL v3 license.

For the progress, please have a glance at the “Projects” tab.

---

## Environment

Suggested Unity version is 2019.4 LTS, and 2019.3.12 or later is required.

Make sure to import [arcore-unity-sdk-1.15.0.unitypackage](https://github.com/google-ar/arcore-unity-sdk/releases/download/v1.18.0/arcore-unity-sdk-1.15.0.unitypackage) before building.

Change ```/Packages/manifest.json.tmpl``` to ```/Packages/manifest.json``` to install required packages.

#### For developers outside of China

The third line of ```Packages/manifest.json``` should be:

```json
"com.google.xr.cardboard": "https://github.com/googlevr/cardboard-xr-plugin.git",
```

#### For developers inside of China

Extract [cardboard-xr-plugin-master.zip](https://github.com/googlevr/cardboard-xr-plugin/archive/master.zip) and change the third line of ```/Packages/manifest.json``` to the following format:

```json
"com.google.xr.cardboard": "file:/path/to/cardboard-xr-plugin-master",
```

---

## Contact

Akashi Jyoken (Japan)'s Twitter: https://twitter.com/jyoken/

AMSJXNU (China) IT Club's Website: https://aitc.cstu.xyz/

Crystal Japan Research (China)'s Website: https://cnk.cstu.xyz/
