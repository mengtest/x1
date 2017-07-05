using System;
using System.Collections.Generic;
using UnityEngine;

namespace x1.Framework
{
    public class FNetworkManager : IManager
    {
        private static FNetworkManager m_inst;

        private Dictionary<string, WWW> m_requestList;

        public static FNetworkManager getInstance ()
        {
            if (m_inst == null)
                m_inst = new FNetworkManager ();
            return m_inst;
        }

        public FNetworkManager ()
        {
        }

        public void init ()
        {
            m_requestList = new Dictionary<string, WWW> ();
        }

        public WWW getRequest (string url)
        {
            WWW w = null;
            if (m_requestList.TryGetValue (url, out w) == false) {
                Debug.LogError ("没有发送或未完成请求: " + url);
            }
            return w;
        }

        public void setRequest (string url, WWW w)
        {
            m_requestList.Add (url, w);
        }

        public void cleanRequest (string url)
        {
            WWW w = null;
            if (m_requestList.TryGetValue (url, out w)) {
                w.Dispose ();
                m_requestList.Remove (url);
            }
        }
    }
}

