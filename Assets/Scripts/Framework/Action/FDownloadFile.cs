using System.IO;
using System.Collections;
using UnityEngine;

namespace x1.Framework
{
    public class FDownloadFile : FAction
    {
        private string m_remoteURL;

        private string m_localURL;

        private UnityEngine.WWW m_request;

        public FDownloadFile (string remoteURL, string localURL)
        {
            m_remoteURL = remoteURL;
            m_localURL = localURL;
        }

        public override void start (System.Object obj)
        {
            m_request = new UnityEngine.WWW (m_remoteURL);
        }

        public override void stop ()
        {
            base.stop ();

            string dir = Path.GetDirectoryName (m_localURL);
            if (Directory.Exists (dir) == false)
                Directory.CreateDirectory (dir);
            
            File.WriteAllBytes (m_localURL, m_request.bytes);

            m_request.Dispose ();
        }

        public override bool isDone ()
        {
            return m_request.isDone;
        }
    }
}
