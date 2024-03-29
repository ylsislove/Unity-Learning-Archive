# Unity-Learning-Archive
本仓库记录自己在 Unity 中学习到的新知识，使用方法只需将 UnityPackage 包导入 Unity 项目中即可，不断完善~

## 更新日志
### LearningArchive 0.0.15
更新于 2023.06.24。具体更新如下：
1. 学习凉鞋老师的QFramework框架，实现
    1. IocContainer，负责依赖注入；BindableProperty，负责属性绑定；
    2. 四层架构，分别是Controller层、System层、Model层和Utility层，其中四层可执行的功能（Rule）如下图所示；
    3. 两种状态变化查询机制，分别是Command和Query，其中Command负责状态变化，Query负责状态查询；
    4. 两种消息机制，分别是EasyEvent和TypeEventSystem，其中EasyEvent是一种简单的消息机制，TypeEventSystem是一种类型化的消息机制；
2. 删除Tests，后续再完善测试相关的代码
3. 删除Playground

![](https://image.aayu.today/uploads/2023/06/24/202306241735845.png)

---

### LearningArchive 0.0.14
更新于 2023.06.15。实现 Simulation Mode 功能，其本质就是切换不同环境加载 API，而核心的管理功能（引用计数，ResMgr 等）不会受到影响。

#### Simulation Mode 功能
- 菜单切换 Simulation Mode
- 编辑器模式下 AssetBundleName 和 AssetName 对应关系收集
- 编辑器模式下 AssetBundle 依赖关系收集
- 加载 Assets 目录下的资源

#### Tests 库新增
- LoadAssetSyncTest
- LoadAssetAsyncTest

---

### LearningArchive 0.0.13
更新于 2023.05.15。知识库进行了细分：框架示例代码（默认位置），工具示例代码（放于 Util 子文件夹下），删除学习框架过程中的学习示例。测试示例代码迁移至 Tests 目录下。

#### 知识库修改
- 细分为框架示例代码（默认位置），工具示例代码（放于 Util 子文件夹下）

#### Tests 库新增
- ResKit 相关测试示例

---

### LearningArchive 0.0.12
更新于 2023.05.11。ResKit 支持从 AssetBundle 中加载资源。支持多个 AssetBundle 平台的 Build。AssetBundle 依赖问题进行了处理。

#### 知识库新增
- AssetBundleManifestExample
- LoadAsyncTest1 报错示例：`请不要在异步加载资源 square 时，进行 square 的同步加载`
- LoadAsyncTest2 测试 BigTexture 的异步加载
- LoadAsyncTest3 测试相同资源被异步加载时是否正常
- LoadDependencyAsyncExample 测试 AssetBundle 的依赖是否正常加载
- LoadABAssetExample 测试 AssetRes

#### 框架库修改
- 重构 AssetBundleRes、ResourcesRes 和 ResLoader，添加了加载状态判断

#### 框架库新增
- ResKitUtil 工具类负责自动拼接不同平台下的 AssetBundle 路径
- ResFactory 工厂模式：负责创建 Res
- AssetRes 负责加载 AssetBundle 中的资源

---

### LearningArchive 0.0.11
更新于 2023.05.11。

#### 框架库修改
- Res 改为抽象类

#### 框架库新增
- AssetBundleRes 负责加载 AssetBundle 资源
- ResourcesRes 负责加载 Resources 资源

---

### LearningArchive 0.0.10
更新于 2023.05.08。

#### 知识库新增
- prefab 的卸载支持示例
- 资源异步加载支持示例
- AssetBundle 学习加载示例

#### 框架库新增
- Res 和 ResLoader 工具类支持 prefab 卸载和异步加载

---

### LearningArchive 0.0.9
更新于 2023.05.08。

#### 知识库新增
- ResMgr 资源管理示例，并提供了调试信息

#### 框架库新增
- ResKit 资源管理框架添加 ResMgr

---

### LearningArchive 0.0.8
更新于 2023.05.08。

#### 知识库新增
- 资源管理示例 ResLoader
- 引用计数示例 SimpleRC

#### 框架库新增
- ResKit 资源管理框架，包括 Res 和 ResLoader
- SimpleRC 引用计数工具类

---

### LearningArchive 0.0.7
更新于 2023.05.08。

#### 知识库新增
- 卸载 Resources.Load 加载的资源示例

---


### LearningArchive 0.0.6
更新于 2021.05.23。知识库添加静态 This 扩展使用示例。修改和重命名 GameObjectSimplify 和 TransformSimplify 为静态 This 扩展类。

#### 知识库新增
- 静态 This 扩展使用示例

#### 修改功能
- 重命名 GameObjectSimplify 为 GameObjectExtension，并更改为静态 This 扩展类
- 重命名 TransformSimplify 为 TransformExtension，并更改为静态 This 扩展类

---

### LearningArchive 0.0.5
更新于 2021.05.23。学习单元测试的使用。将 AudioManager 应用单例模板。

#### 框架库新增
- 单元测试

#### 修改功能
- AudioManager 应用单例模板

---

### LearningArchive 0.0.4
更新于 2021.05.23。框架库新增单例模式抽象类。修复了 AudioManager 中存在的问题。

#### 框架库新增
- Singleton 单例模式抽象类
- MonoSingleton 继承 MonoBehaviour 的单例模式抽象类

#### 修复 Bug
- AudioManager 中 AudioListener 重复添加的问题

---

### LearningArchive 0.0.3
更新于 2021.05.22。框架库新增 Manager of Managers 脚本；知识库新增 Manager 脚本使用示例，和Shader 学习示例。

#### 框架库新增
- MainManager 开发环境管理脚本
- GUIManager 界面资源管理脚本
- AudioManager 音频资源管理脚本
- SimpleObjectPool 对象池管理脚本
- LevelManager 场景管理脚本

#### 知识库新增
- 对应管理脚本的使用示例
- Shader 基本属性、最简单的 Shader、输入结构体和输出结构体、属性块

---

### LearningArchive 0.0.2
更新于 2021.04.27，对库进行重构，划分为 Example 和 Framework。Example 为知识库，Framework 为框架库，主要由工具类 Utils 和管理类 Manager 组成。

#### 框架库新增
- MonoBehaviourSimplify 框架核心脚本
- MsgDispatcher 框架消息机制脚本
- Hide 框架自定义脚本

#### 知识库新增
- 自定义随机函数示例
- Hide 脚本示例
- 定时功能示例
- 简易消息机制示例
- 框架示例

#### 修改功能
- MathUtils 脚本

---

### LearningArchive 0.0.1
更新于 2021.04.26，新添功能如下。

- 自动导出 UnityPackage
- 拷贝文本到剪切板
- MenuItem 复用
- 屏幕宽高比判断
- Transform API 简化
- GameObject Active 简化
- 自定义概率函数
