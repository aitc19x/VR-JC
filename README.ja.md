# プロジェクト VR-JC

[English](README.md) [中文](README.zh.md) [한국어](README.kr.md)

---

## 紹介

最近、現地へ行かず Google Cardboard などのデバイスだけで現地で遊ぶように風景を見える技術として VR を流行っています。日中交流と両方の技術力を促進するために、このプロジェクトが設けられました。三つ組織、明石工業高等専門学校情報工学研究部（日本）・江西師範大学附属中米国際高校パソコン部（中国）・クリスタル日本文化研究グループ（中国）、を結んでより良い体験を伝えています。

この協力とは、次の三つステップに分けられます。日中両方はまずプログラミングをして、それぞれの国の文化が代表できるシーン・オブジェクトに取材して、対応するモデルを作って、プロジェクトにインポートします。その後、モデルに対して日本語・英語・中国語（余裕があれば、韓国語も）の解説文・音声を付けます。最後は、一緒にこのプロジェクトをレビューして UI などを改善して、Play Store で発表して、両校の文化祭で展示します。中国側も部活を参加している高校生です。それで、年齢はほぼ同じですから、交流でも親しさがあります。

このプロジェクトは Google Cardboard・Google ARCore・Unity C# を利用されて、国際化は日本語・英語・中国語・韓国語を含まれています。

このプロジェクトへようこそ。気軽に使ってみましょう。GPL v3 ライセンスを基づいて貢献するも大歓迎です。

進捗状況については、「Project」タブをご覧ください。

---

## 開発環境

Unity 2019.4 LTS を推奨しています。それとも Unity 2019.3.12 以上を使ってください。

プロジェクトをビルトの前に、[arcore-unity-sdk-1.15.0.unitypackage](https://github.com/google-ar/arcore-unity-sdk/releases/download/v1.18.0/arcore-unity-sdk-1.15.0.unitypackage) のインポートを確認してください。

```/Packages/manifest.json.tmpl``` を ```/Packages/manifest.json``` に変えて必要なパッケージをインストールしてください。

#### 中国以外に住んでいる開発者に

```Packages/manifest.json``` の第3行は以下と同じすべきです：

```json
"com.google.xr.cardboard": "https://github.com/googlevr/cardboard-xr-plugin.git",
```

#### 中国に住んでいる開発者に

[cardboard-xr-plugin-master.zip](https://github.com/googlevr/cardboard-xr-plugin/archive/master.zip) を展開して ```/Packages/manifest.json``` の第3行に以下と同じフォーマットをしてください：

```json
"com.google.xr.cardboard": "file:/path/to/cardboard-xr-plugin-master",
```

---

## 連絡先

明石工業高等専門学校（日本）情報工学研究部のTwitter： https://twitter.com/jyoken/

江西師範大学附属中米国際高校（中国）情報科学部の公式サイト： https://aitc.cstu.xyz/

クリスタル日本文化研究グループ（中国）の公式サイト： https://cnk.cstu.gq
