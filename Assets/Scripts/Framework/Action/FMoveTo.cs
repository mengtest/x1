﻿using UnityEngine;
using System.Collections;

namespace x1.Framework
{
    public class FMoveTo : FTransformAction
    {
        private Vector3 m_fromPos;
        private Vector3 m_deltaPos;

        public FMoveTo (float duration, Vector3 targetPos)
        {
            m_deltaPos = targetPos;
            setDuration (duration);
        }

        public override void start (System.Object obj)
        {
            base.start (obj);

            Transform transform = getTransform ();
            if (transform)
                m_fromPos = transform.localPosition;
        }

        public override void update (float percent)
        {
            base.update (percent);

            Transform transform = getTransform ();
            if (transform)
                transform.localPosition = Vector3.Lerp (m_fromPos, m_deltaPos, percent);
        }
    }
}
