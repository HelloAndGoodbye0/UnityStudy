using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UnityEngine
{
    // 自定义一个工具类
    public class SpriteTool
    {
        // 加载Resources文件下的Sprite图片
        public static Sprite ResourcesSprite(string path)
        {
            return Resources.Load<Sprite>(path);
        }
        public static GameObject ResourcesGameObject(string path)
        {
            return Resources.Load<GameObject>(path);
        }
    }
    public class GameObjectTool
    {
        // 加载Resources文件下的游戏物体
        public static GameObject ResourcesGameObject(string path)
        {
            return Resources.Load<GameObject>(path);
        }
    }

}
