using System;
using UnityEngine;

namespace NormalLib.Library
{
    [Serializable]
    public class Timer
    {
        [SerializeField] private float timerDuration;
        private float timerCurrent;
        public float NormalizedTime => NormalizeTime();
        
        public Timer(float timerDuration)
        {
            this.timerDuration = timerDuration;
            timerCurrent = 0f;
        }

        private float NormalizeTime()
        {
            return timerCurrent / timerDuration;
        }

        public float GetCurrent()
        {
            return timerCurrent;
        }

        public void ForceDone()
        {
            timerCurrent += timerDuration;
        }
        
        public bool TimerDone()
        {
            if (timerCurrent >= timerDuration)
            {
                return true;
            }
            return false;
        }

        public bool ControlUpdate(float updateAmount)
        {
            timerCurrent += Mathf.Abs(updateAmount);
            return TimerDone();
        }
        
        public void Update(float updateAmount)
        {
            timerCurrent += Mathf.Abs(updateAmount);
        }

        public void Restart()
        {
            timerCurrent = 0;
        }

        public void Restart(float newDuration)
        {
            timerDuration = newDuration;
            timerCurrent = 0f;
        }
        
    }
}