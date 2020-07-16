
using UnityEngine;

namespace dninosores.UnityAnimationModifiers
{
    /// <summary>
    /// MonoBehaviour container for a modifier of type T. This allows modifiers to be attached to gameObjects and show up in-editor.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class MonoAnimationModifier<T> : MonoBehaviour
    {
        [Tooltip("Should the modifier be synced with the time since startup on awake?")]
        public bool syncOnAwake;
        /// <summary>
        /// Returns the contained modifier.
        /// </summary>
        public abstract Modifier<T> modifier {get;}

        protected virtual void Reset()
        {
            syncOnAwake = true;
        }

        protected virtual void LateUpdate()
        {
            modifier.LateUpdate(this);
        }


        protected virtual void Awake()
        {
            if (syncOnAwake)
            {
                Sync();
            }
            modifier.Awake();
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
            modifier.time = 0;
        }


        /// <summary>
        /// Sets modifier to RealtimeSinceStartup, which syncs its time with all other modifiers for which Sync has been called.
        /// </summary>
        public void Sync()
        {
            modifier.time = Time.realtimeSinceStartup;
        }
    }
}
