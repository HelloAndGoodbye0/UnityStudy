using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UnityEngine
{
    // �Զ���һ��������
    public class SpriteTool
    {
        // ����Resources�ļ��µ�SpriteͼƬ
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
        // ����Resources�ļ��µ���Ϸ����
        public static GameObject ResourcesGameObject(string path)
        {
            return Resources.Load<GameObject>(path);
        }
    }

}
