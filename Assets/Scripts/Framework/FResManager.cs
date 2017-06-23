using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace berry
{
    /// <summary>
    /// 资源类型id
    /// </summary>
    public class FResID
    {
        /// <summary>
        /// AssetBundle
        /// </summary>
        public const int ASSETBUNDLE = 1;

        /// <summary>
        /// prefab
        /// </summary>
        public const int PREFAB = 2;

        /// <summary>
        /// texture
        /// </summary>
        public const int TEXTURE = 3;

        /// <summary>
        /// UGUI Sprite
        /// </summary>
        public const int SPRITE = 4;

        /// <summary>
        /// font
        /// </summary>
        public const int FONT = 5;

        /// <summary>
        /// audio
        /// </summary>
        public const int AUDIO = 6;

        /// <summary>
        /// fx
        /// </summary>
        public const int FX = 6;
    }

    public class FResManager
    {
        private static FResManager m_inst;

        /// <summary>
        /// 包含当前每个类型的一个对象
        /// </summary>
        private Dictionary<int, UnityEngine.Object> m_resDict;

        public static FResManager getInstance ()
        {
            if (m_inst == null)
                m_inst = new FResManager ();
            return m_inst;
        }

        private FResManager ()
        {
            m_resDict = new Dictionary<int, Object> ();
        }

        /// <summary>
        /// Gets the res.
        /// </summary>
        /// <returns>资源对象</returns>
        /// <param name="id">FResID中的常量.</param>
        public UnityEngine.Object getRes (int resId)
        {
            UnityEngine.Object res = null;
            if (m_resDict.TryGetValue (resId, out res) == false || res == null)
                Debug.LogError ("id 为 {" + resId + "} 的资源未加载");
            return res;
        }

        /// <summary>
        /// 设置一个类型的资源对象
        /// </summary>
        /// <param name="id">FResID中的常量</param>
        /// <param name="res">资源对象</param>
        public void setRes (int resId, UnityEngine.Object res)
        {
            m_resDict [resId] = res;
        }
    }
}
