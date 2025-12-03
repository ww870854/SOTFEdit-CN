# SOTFEdit - 森林之子存档编辑器

![屏幕截图](https://abload.de/img/sotfeditfadso.jpg)

[![Build](https://github.com/codengine/SOTFEdit/actions/workflows/build.yaml/badge.svg)](https://github.com/codengine/SOTFEdit/actions/workflows/build.yaml)
[![GitHub release (latest by date)](https://img.shields.io/github/v/release/codengine/SOTFEdit)](https://github.com/codengine/SOTFEdit/releases)
[![GitHub all releases](https://img.shields.io/github/downloads/codengine/SOTFEdit/total)](https://github.com/codengine/SOTFEdit/releases)
![GitHub](https://img.shields.io/github/license/codengine/SOTFEdit)

《森林之子》存档编辑器

[![Discord](https://abload.de/img/discordc7csi.png)](https://discord.gg/867UDYvvqE)

- [SOTFEdit - 森林之子存档编辑器](#sotfedit---sons-of-the-forest-savegame-editor)
    - [免责声明](#免责声明)
    - [功能特性](#功能特性)
    - [下载](#下载)
    - [系统要求](#系统要求)
    - [使用方法](#使用方法)
    - [物品栏](#物品栏)
    - [仓储系统](#仓储系统)
    - [护甲系统](#护甲系统)
    - [NPC](#NPC)
    - [建筑](#建筑)
    - [地图](#地图)
    - [天气](#天气)
    - [复活](#复活)
    - [刷怪](#刷怪)
    - [故障排除](#故障排除)
    - [贡献指南](#贡献指南)
    - [结语](#结语)
    - [链接与鸣谢](#链接与鸣谢)
    - [致谢声明](#致谢声明)
    - [图标资源](#图标资源)

## 免责声明

本项目与游戏开发商没有任何关联。它仅是一个非商业性质的粉丝项目，
仅此而已，别无其他。

## 功能特性

- 编辑玩家属性（力量、最大生命值、当前生命值、饱腹度等）
- 将玩家传送至弗吉尼亚与凯尔文
- 编辑游戏设置（游戏模式、刷怪率、生存损伤等）
- 编辑物品栏（添加/移除物品、修改数量）
- 编辑护甲数据（添加护甲部件、修改耐久度）
  - 编辑天气数据（天气、季节...）
- 编辑游戏状态数据（游戏时长、门开闭状态、掩体启闭状态）
- 编辑存储数据（无限原木、木棍等资源）
- 编辑玩家对凯尔文与弗吉尼亚的影响值
- 编辑NPC角色
- 编辑建筑结构/蓝图
- 主题支持
- 点燃并补充所有火源燃料，同时降低燃料消耗速率
- 重置建筑损伤值
- 传送至并克隆世界物体（如滑翔翼和骑士V）
- 重置消耗物品
- 修改弗吉尼亚装备物品
- 更换弗吉尼亚与凯尔文的服装
- 生成弗吉尼亚与凯尔文的军队
- 多项实验功能
- 复活弗吉尼亚与凯尔文
- 设定弗吉尼亚与凯尔文的属性值
- 将Kelvin与Virginia传送至玩家身边或彼此身边
- 选择性再生树木（全部/已移除/半截/树桩）
- 重置洞穴及开放世界中的容器、箱子与拾取物
- 自动备份修改文件
- ...更多功能正在规划中

## 下载

- 您可以在[发布页面](https://github.com/codengine/SOTFEdit/releases)找到最新版本

## 系统要求

- Windows 8 及以上版本
- [.NET 6.0 Desktop Runtime installed](https://dotnet.microsoft.com/en-us/download/dotnet/6.0)

## 使用方法

- 使用 SOTFEdit.exe 启动应用程序
- 点击“文件” -> “打开存档”
- 选择您的存档文件
- 进行编辑
- 通过“文件” -> “保存”完成存储

## 物品栏

- 添加或移除物品时，请点击添加或移除按钮
- 其他按钮可便捷地修改当前数量
- 当前不可用的物品会被隐藏，但可在 data.json 中轻松启用
- 添加腿部/手臂部件时，默认采用烹饪处理的变体。此规则同样适用于已存在的
  腿部/手臂部件——仅增加数量时亦会应用该处理

## 仓储系统

- 仅支持存储功能的物品可存放。例如太阳能板无法存放于此
- 编辑器将遵循每个槽位物品数量上限规则

## 护甲系统

护甲能保护你免受大多数伤害。但你仍会因溺水或坠落伤害而死亡。

## NPC

游戏将部分敌人归类为“家族”。这些敌人通常不会互相攻击，而是联合袭击玩家。

关于修改NPC的注意事项：部分敌人位于洞穴/掩体中，拥有不同的图形遮罩（GraphMask）。
当选中此选项（仅限与当前角色处于同一区域）时，仅会修改处于相同“阶段”的敌人。

因此若只想移除洞穴中的幼崽，请勾选此选项；若需清除所有幼崽，则取消勾选。

生成器：目前尚未完全研究游戏对生成器的处理机制。删除生成器后，游戏会在下次存档时
重新生成它们
。这可作为增加敌人数量的一种方式。

## 建筑

此工具可让您“几乎”完成蓝图，将其设为“未完成”状态或直接移除。
为何说是“几乎”？因为蓝图转换为最终建筑过于复杂。因此本工具会将蓝图调整为仅需最后一项资源即可完成。

其妙处在于可轻松获取木材等资源：只需设置若干庇护所，将其标记为“几乎完成”，拆除后所有木材便会掉落地面。

另一妙用是用于洞穴或掩体建造。流程相同：放置蓝图→标记为“近乎完成”→拆除蓝图→利用资源建造新设施。

若要在洞穴或掩体内建造庇护所等大型结构，需先放置小型蓝图（如椅子），再修改其类型并保存。

## 地图

该地图将兴趣点的静态信息与直接从存档文件读取的动态信息相结合。
部分位置信息尚不完整，但未来可能会添加。

### 功能

- 显示/隐藏以下元素的信息：3D打印机、演员/NPC、弹药、掩体、营地、食人族村庄、洞穴、箱子、
  门、直升机、通用信息、物品、湖泊、笔记本电脑、玩家、建筑、补给品和村庄
- 将玩家及追随者传送至角色/NPC、玩家本体、滑索、建筑、洞穴、掩体、直升机
- 从地图移除滑索
- 在目标区域生成角色/NPC

### 选项

您可通过左上角的“选项”按钮启用或禁用图标。

关于筛选器的注意事项：

- “仅显示未收集物品”将显示/隐藏包含掩体和洞穴在内的未收集物品及其所在位置
- 区域 - 主要影响角色对象，或更广泛地说，影响我们拥有精确坐标的位置
- 要求 - 显示/隐藏可进入/不可进入的洞穴、掩体及物品

### 传送功能

您仅能传送至我们已掌握精确坐标的位置，这些坐标可能来自存档文件本身，或附属于特定兴趣点（POI）。

凯尔文和弗吉尼亚不会出现在地下区域，因此若目标位置位于地下，他们的传送功能将被禁用。

默认情况下目标位置会添加偏移量。此机制可避免玩家在敌人内部生成——否则会被弹射至高空导致死亡。
您可通过以下数值调整目标位置：X和Z代表经纬度，Y代表高度。

### 敌人生成

大多数敌人可在所有区域生成。弗吉尼亚和凯尔文仅能在地面区域生成。请注意，若生成过多敌人可能严重影响游戏性能，甚至导致游戏崩溃。

此外，游戏不会同时生成所有敌人。若生成200个敌人，游戏将先创建约25个敌人，待其被消灭后，经过一段时间将生成下一批约25个敌人。

## 天气

有一点非常重要。若仅更改季节，游戏进程推进时季节将立即恢复原状。
要解决此问题，还需在“游戏状态”中调整游戏时间。该时间基于季节长度计算。示例如下：

- 起始季节：春季
- 季节长度：长
- 游戏时间：31天

游戏内季节将显示为冬季，因为：

- 第0-9天 = 春季
- 第10-19天 = 夏季
- 第20-29天 = 秋季
- 第30-39天 = 冬季

因此若想将天气改为夏季，需将游戏时间调整至10至19天区间。

以下是不同赛季长度设置对应的季节天数列表：

- 短：？？？
- 默认（非自定义游戏）：5天
- 长：10天
- 真实：90天

## 复活

若需复活一名或两名随从，请注意以下事项：

- 若尸体完全消失，随从将出现在玩家所在位置
- 请确保身处建筑物外，否则可能出现卡入建筑的故障
- 复活的随从将拥有最高属性值，并对玩家保持友好态度
- 他们会携带你复活前选定的物品
- 弗吉尼亚复活时会像羔羊般羞怯。我尚未充分测试，但似乎需要像新游戏初始那样重新赢得她的信任。目前仍在研究影响她信任度的具体设置参数。

## 刷怪

此功能尚处于实验阶段，可实现克尔文与弗吉尼亚的复制。经测试发现，游戏因某些原因无法生成超过5个弗吉尼亚角色。若数值更高，它们将生成在无法到达的位置。

克尔文角色已成功测试至20个，故当前最大值亦为20。

若需突破此上限，需先存档，启动工具进行生成操作，再重新加载游戏。

```
请注意：此功能极可能导致性能严重下降，并可能损坏您的存档文件。
请务必启用备份功能！ 
```

## 故障排除

库存中的某件物品显示为“未知”？

- 请报告该物品的ItemId，以便我将其添加到已知物品列表中

我的游戏无法运行了？

- 若您在保存前选择了创建备份，只需删除旧文件并恢复后缀为“.bak*”的文件即可

出现错误且应用程序行为异常

- 请将日志上传至 https://pastebin.com 并创建问题报告

无法修改“凯文生死状态”或“弗吉尼亚生死状态”

- 需通过“追随者”界面中的专用按钮才能同时复活二人

程序无法启动

- 请确认已安装.NET 6.0 Desktop Runtime installed。若手动下载zip压缩包，请确保完整解压所有文件。最后检查防病毒软件是否阻断编辑器运行

防病毒软件（如Windows Defender、SmartScreen）发出警告

- 这是因为该程序为未签名的自主开发应用，可完全忽略警告，所有代码均托管于GitHub。

“无法加载文件或程序集”

- 请确保已安装.NET 6.0 Desktop Runtime installed (x86或x64)版本均可。

修改内容未生效或被撤销

- Steam云存档功能有时会覆盖SOTFEdit的修改，解决方法：先启动游戏（非游戏会话！），编辑存档文件，再启动游戏会话。

湖泊、河流等消失

- 洞穴传送后可能出现此现象，再次进行洞穴传送即可修复。

## 贡献指南

欢迎随时报告任何未知的项或提出功能需求，也欢迎提交PRs。

## 结语

特别感谢[Gronkh](https://gronkh.tv)多年来带来的“Influenz”。若非你的《森林》实况，我根本无从知晓
这款游戏的存在。

## 链接与鸣谢

- 翻译与校对
    - 波兰语：Mortennif
    - 德语：Hinterix
    - 中文: 870854
- 支持者与测试人员：Mortennif、M2THE49、feydrautha01

## 致谢声明

项目所用图标归属Endnight Games所有。

坐标点（POI）及截图均源自https://github.com/lmachens/sons-of-the-forest-map，该网站在收集所有数据方面确实做出了卓越贡献。

## 图标资源

- [小斧头图标由 Icons8 设计](https://icons8.com/icon/81685/kleine-axt)
- [诞生图标由 Freepik - Flaticon 创作](https://www.flaticon.com/free-icons/birth)
- [蝙蝠图标由 Vitaly Gorbachev - Flaticon 设计](https://www.flaticon.com/free-icons/bat)
- [鸟类图标由 monkik - Flaticon 设计](https://www.flaticon.com/free-icons/bird)
- [鸭子图标由smalllikeart设计 - Flaticon](https://www.flaticon.com/free-icons/duck)
- [鹰图标由Flat Icons设计 - Flaticon](https://www.flaticon.com/free-icons/eagle)
- [鱼类图标由 VectorPortal - Flaticon 设计](https://www.flaticon.com/free-icons/fish)
- [鸟类图标由 Mihimihi - Flaticon 设计](https://www.flaticon.com/free-icons/bird)
- [字母k图标由icon_small - Flaticon设计](https://www.flaticon.com/free-icons/letter-k)
- [字母v图标由icon_small - Flaticon设计](https://www.flaticon.com/free-icons/letter-v)
- [萨满图标由 Smashicons - Flaticon 设计](https://www.flaticon.com/free-icons/shaman)
- [驼鹿图标由 Freepik - Flaticon 设计](https://www.flaticon.com/free-icons/moose)
- [虎鲸图标由 Freepik - Flaticon 设计](https://www.flaticon.com/free-icons/orca)
- [问号图标由 Fathema Khanom - Flaticon 设计](https://www.flaticon.com/free-icons/question-mark)
- [兔子图标由 Mihimihi - Flaticon 创作](https://www.flaticon.com/free-icons/bunny)
- [海鸥图标由 surang - Flaticon 创作](https://www.flaticon.com/free-icons/seagull)
- [鲨鱼图标由 BZZRINCANTATION 创作 - Flaticon](https://www.flaticon.com/free-icons/shark)
- [松鼠图标由 Freepik 创作 - Flaticon](https://www.flaticon.com/free-icons/squirrel)
- [乌龟图标由 BZZRINCANTATION 创作 - Flaticon](https://www.flaticon.com/free-icons/turtle)
- [十字准星图标由 Freepik 创作 - Flaticon](https://www.flaticon.com/free-icons/crosshair)
- [狩猎图标由 Darius Dan - Flaticon 创作](https://www.flaticon.com/free-icons/hunt)
- [掩体图标由 Smashicons - Flaticon 创作](https://www.flaticon.com/free-icons/bunker)
- [洞穴图标由Freepik - Flaticon设计](https://www.flaticon.com/free-icons/cave)
- [笔记本电脑图标由Freepik - Flaticon设计](https://www.flaticon.com/free-icons/laptop)
- [帐篷图标由Freepik - Flaticon设计](https://www.flaticon.com/free-icons/tent)
- [村庄图标由Freepik - Flaticon设计](https://www.flaticon.com/free-icons/village)
- [直升机图标由Konkapp - Flaticon设计](https://www.flaticon.com/free-icons/helicopter)
- [信号图标由Smashicons - Flaticon设计](https://www.flaticon.com/free-icons/signaling)
- [徒步图标由 Freepik - Flaticon 创作](https://www.flaticon.com/free-icons/hiking)
- [门图标由 kerismaker - Flaticon 创作](https://www.flaticon.com/free-icons/door)
- [艺术与设计图标由 Hilmy Abiyyu A. - Flaticon 创作](https://www.flaticon.com/free-icons/art-and-design)
- [战利品图标由 Freepik - Flaticon 创作](https://www.flaticon.com/free-icons/loot)
- [箱子图标由 lapiyee 设计 - Flaticon](https://www.flaticon.com/free-icons/crate)
- [运输与配送图标由 Ida Desi Mariana 设计 - Flaticon](https://www.flaticon.com/free-icons/shipping-and-delivery)
- [子弹图标由 Freepik - Flaticon 设计](https://www.flaticon.com/free-icons/bullet)
- [美洲原住民图标由 Freepik - Flaticon 设计](https://www.flaticon.com/free-icons/native-american)
- [池塘图标由Mihimihi - Flaticon设计](https://www.flaticon.com/free-icons/pond)
- [木材图标由Nikita Golubev - Flaticon设计](https://www.flaticon.com/free-icons/wood)
- [庇护所图标由Muhammad_Usman设计 - Flaticon](https://www.flaticon.com/free-icons/shelter)
- [成长图标由Freepik设计 - Flaticon](https://www.flaticon.com/free-icons/grow)
- [滑翔机图标由Pop Vectors设计 - Flaticon](https://www.flaticon.com/free-icons/glider)
- [单轮车图标由Freepik设计 - Flaticon](https://www.flaticon.com/free-icons/monowheel)
- [钢管舞图标由Freepik - Flaticon设计](https://www.flaticon.com/free-icons/pole-dance)
- [高尔夫图标由Good Ware - Flaticon设计](https://www.flaticon.com/free-icons/golf)
- [书签图标由 Ian Anandara - Flaticon 设计](https://www.flaticon.com/free-icons/bookmark)
- [士兵图标由 ppangman - Flaticon 设计](https://www.flaticon.com/free-icons/soldier)
- [壁炉图标由 Vector Squad - Flaticon 设计](https://www.flaticon.com/free-icons/fireplace)
- [高尔夫球车图标由 surang - Flaticon 设计](https://www.flaticon.com/free-icons/golf-cart)
- [枪械图标由 Nikita Golubev - Flaticon 设计](https://www.flaticon.com/free-icons/gun)
- [熔炉图标由 amonrat rungreangfangsai - Flaticon 设计](https://www.flaticon.com/free-icons/furnace)
- [沙发图标由Stockio - Flaticon设计](https://www.flaticon.com/free-icons/couch)
- [浣熊图标由Icongeek26 - Flaticon设计](https://www.flaticon.com/free-icons/raccoon)
- [危险图标由 Smashicons - Flaticon 设计](https://www.flaticon.com/free-icons/dangerous)
- [传送图标由 Freepik - Flaticon 设计](https://www.flaticon.com/free-icons/teleportation)
- [木质图标Freepik - Flaticon 设计](https://www.flaticon.com/free-icons/wood)
- [收音机图标Eucalyp - Flaticon 设计](https://www.flaticon.com/free-icons/radio)
- [臭鼬图标由Freepik - Flaticon设计](https://www.flaticon.com/free-icons/skunk)
- [筏子图标Freepik - Flaticon创作](https://www.flaticon.com/free-icons/raft)
- [独轮车图标Freepik - Flaticon创作](https://www.flaticon.com/free-icons/unicycle)
- [鸟屋图标由 Smashicons - Flaticon 设计](https://www.flaticon.com/free-icons/bird-house)
- [系泊图标由 Freepik - Flaticon 设计](https://www.flaticon.com/free-icons/mooring)
