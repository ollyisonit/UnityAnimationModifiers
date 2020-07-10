using System.Collections;
using UnityEngine;

namespace dninosores.UnityAnimationModifiers
{
    [DefaultExecutionOrder(999999)]
    public abstract class LateUpdateModifier<T> : MonoBehaviour
    {
        public bool additive = true;
        public bool syncOnAwake = true;
        public float intensity = 1;
        protected T originalValue;
        protected float time;


        protected virtual void Reset()
        {
            additive = true;
            intensity = 1;
        }


        protected virtual void Awake()
        {
			if (syncOnAwake)
			{
                Sync();
            }
        }


        protected abstract T GetValue();

        protected abstract void SetValue(T value);

        protected abstract T GetModifiedValue(T originalValue);

        void LateUpdate()
        {
            if (isActiveAndEnabled)
            {
                if (additive)
                {
                    originalValue = GetValue();
                    StartCoroutine(SetValueBack());
                }
                SetValue(GetModifiedValue(GetValue()));
                time += Time.deltaTime;
            }
        }

        private IEnumerator SetValueBack()
        {
            yield return new WaitForEndOfFrame();
            if (additive)
            {
                SetValue(originalValue);
            }
        }


        /// <summary>
        /// Starts playing modifier from where it left off.
        /// </summary>
        public void Play()
        {
            this.enabled = true;
        }


        /// <summary>
        /// Pauses modifier and maintains current value.
        /// </summary>
        public void Pause()
        {
            this.enabled = false;
        }


        /// <summary>
        /// Stops modifier and resets it back to its starting value.
        /// </summary>
        public void Stop()
        {
            this.enabled = false;
            time = 0;
        }


        /// <summary>
        /// Sets modifier to RealtimeSinceStartup, which syncs its time with all other modifiers for which Sync has been called.
        /// </summary>
        public void Sync()
        {
            time = Time.realtimeSinceStartup;
        }
    }
}
