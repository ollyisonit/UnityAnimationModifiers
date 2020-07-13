using dninosores.UnityAccessors;
using System;
using System.Collections;
using UnityEngine;

namespace dninosores.UnityAnimationModifiers
{
    [Serializable]
    public abstract class LateUpdateModifier<T>
    {
        public bool additive = true;
        public bool syncOnAwake = true;
        public float intensity = 1;
        protected T originalValue;
        [HideInInspector]
        public float time;


        public virtual void Reset(GameObject gameObject)
        {
            ResetAccessors.Reset(this, gameObject);
            additive = true;
            intensity = 1;
        }

		public virtual void Awake()
		{
		}


        protected abstract T GetValue();

        protected abstract void SetValue(T value);

        protected abstract T GetModifiedValue(T originalValue);

        public void LateUpdate(bool isActiveAndEnabled, MonoBehaviour mb)
        {
            if (isActiveAndEnabled)
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
