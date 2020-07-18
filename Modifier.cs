using dninosores.UnityAccessors;
using System;
using System.Collections;
using UnityEngine;

namespace dninosores.UnityAnimationModifiers
{
    /// <summary>
    /// Modifies a value of type T over time according to some method.
    /// </summary>
    [Serializable]
    public abstract class Modifier<T>
    {
        [Tooltip("Should the modification be added on top of the original value?")]
        public bool additive = true;
        [Tooltip("How much should the modifier affect the target value? " +
            "An intensity of 1 will make the modifier have its full effect, and 0 will make it have no effect at all.")]
        public float intensity = 1;
        /// <summary>
        /// Stores what value was before it was modified.
        /// </summary>
        protected T originalValue;
        /// <summary>
        /// How much time has elapsed since the modifier started?
        /// </summary>
        [HideInInspector]
        public float time;


        /// <summary>
        /// Resets modifier back to its original values.
        /// </summary>
        /// <param name="gameObject">GameObject that modifier is associated with.</param>
        public virtual void Reset(MonoBehaviour mb)
        {
            ResetAccessors.Reset(this, mb);
            additive = true;
            intensity = 1;
        }


        /// <summary>
        /// Should be called before the first frame update.
        /// </summary>
		public virtual void Awake()
		{
		}


        /// <summary>
        /// Gets value that is being modified.
        /// </summary>
        protected abstract T GetValue();


        /// <summary>
        /// Sets value that is being modified.
        /// </summary>
        protected abstract void SetValue(T value);


        /// <summary>
        /// Given an original value, gets what the value should be modified to be.
        /// </summary>
        protected abstract T GetModifiedValue(T originalValue);


        /// <summary>
        /// Should be called in the Unity LateUpdate method.
        /// </summary>
        /// <param name="mb">Monobehaviour associated with the modifier.</param>
        public void LateUpdate(MonoBehaviour mb)
        {
            if (mb.isActiveAndEnabled)
            {
                if (additive)
                {
                    originalValue = GetValue();
                    mb.StartCoroutine(SetValueBack());
                }
                SetValue(GetModifiedValue(GetValue()));
                time += Time.deltaTime;
            }
        }


        /// <summary>
        /// Coroutine that sets the modified value back to its original value at the end of the frame.
        /// </summary>
        private IEnumerator SetValueBack()
        {
            yield return new WaitForEndOfFrame();
            if (additive)
            {
                SetValue(originalValue);
            }
        }


       
    }
}
