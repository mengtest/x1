using System;
using System.IO;
using System.Reflection;
using System.Collections.Generic;
using UnityEngine;

namespace x1.Framework
{
    public static class Util
    {
        public static System.Type getType (string classname)
        {
            System.Type t = null;
            try {
                Assembly assb = Assembly.GetExecutingAssembly ();
                t = assb.GetType (classname);
                if (t == null) {
                    assb = Assembly.Load ("UnityEngine");
                    t = assb.GetType (classname);
                }
                if (t == null) {
                    assb = Assembly.Load ("Assembly-CSharp-firstpass");
                    t = assb.GetType (classname);
                }

            } catch (Exception ex) {
                Debug.LogError (ex);
            }
            return t;
        }

        public static double getTimestamp ()
        {
            TimeSpan ts = DateTime.UtcNow - new DateTime (1970, 1, 1, 0, 0, 0, 0);
            return ts.TotalSeconds;
        }

        /// <summary>
        /// 读取外部文件
        /// </summary>
        /// <returns>The external file.</returns>
        public static byte[] readBytesFromExternal (string path)
        {
            return System.IO.File.ReadAllBytes (path);
        }

        /// <summary>
        /// 读取外部文件
        /// </summary>
        /// <returns>The text from external.</returns>
        /// <param name="path">Path.</param>
        public static string readTextFromExternal (string path)
        {
            byte[] bytes = readBytesFromExternal (path);
            string text = System.Text.Encoding.ASCII.GetString (bytes);
            return text;
        }

        /// <summary>
        /// 读取安装包内部文件
        /// </summary>
        /// <returns>The internal file.</returns>
        public static byte[] readBytesFromInternal (string path)
        {
#if UNITY_EDITOR || UNITY_STANDALONE_WIN
            return readBytesFromExternal (path); // 编辑器下所有文件都是外部文件
#else
            using (WWW w = new WWW (path)) {
                while (w.isDone == false)
                    ; // 这样简单粗暴
                if (string.IsNullOrEmpty (w.error) == false)
                    Debug.LogError (w.error);
                return w.bytes;
            }
#endif
        }

        /// <summary>
        /// 读取安装包内部文件
        /// </summary>
        /// <returns>The text from internal.</returns>
        /// <param name="path">Path.</param>
        public static string readTextFromInternal (string path)
        {
            byte[] bytes = readBytesFromInternal (path);
            string text = System.Text.Encoding.ASCII.GetString (bytes);
            return text;
        }

        /// <summary>
        /// 删除后缀名
        /// </summary>
        /// <returns>The extension.</returns>
        /// <param name="path">Path.</param>
        public static string removeExtension (string path)
        {
            string filename = path;
            int minPos = path.LastIndexOf ('/');
            int maxPos = path.LastIndexOf ('.');
            if (maxPos > minPos)
                filename = path.Remove (maxPos);
            return filename;
        }

        public static void copyDierctory (string source, string dest)
        {
            string[] files = Directory.GetFiles (source, "*", SearchOption.AllDirectories);

            for (int i = 0; i < files.Length; i++) {
                string str = files [i].Remove (0, source.Length);
                string path = dest + "/" + str;
                string dir = Path.GetDirectoryName (path);
                Directory.CreateDirectory (dir);
                File.Copy (files [i], path, true);
            }
        }
    }
}

