/// <summary>
/// 异步请求
/// </summary>

using System;

namespace x1.Framework
{
    public class FHttpRequest : FAction
    {
        private string m_url;

        private UnityEngine.WWW m_www;

        public FHttpRequest (string url)
        {
            m_url = url;
        }

        public override void start (System.Object obj)
        {
            m_www = new UnityEngine.WWW (m_url);
        }

        public override void stop ()
        {
            FNetworkManager.getInstance ().setRequest (m_url, m_www);
        }

        public override bool isDone ()
        {
            return m_www.isDone;
        }
    }
}

