using UnityEngine;
using System;
using System.Security;
using System.Collections;
using Mono.Xml;

namespace x1.Framework
{
    public static class FXmlHelper
    {
        //        public static SecurityElement loadXMLWithFile ()
        //        {
        //        }
        //
        public static SecurityElement loadXML (string content)
        {
            try {
                SecurityParser sp = new SecurityParser ();
                sp.LoadXml (content);
                return sp.ToXml ();
            } catch (Exception ex) {
                Debug.LogError (ex);
                return null;
            }
        }


    }
}
