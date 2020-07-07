using System.Collections;
using UnityEngine;

namespace dninosores.UnityAnimationModifiers
{
    [DefaultExecutionOrder(999999)]
    public abstract class LateUpdateModifier<T> : MonoBehaviour
    {
        public bool additive = true;
        public float intensity = 1;
        protected T originalValue;


        protected virtual void Reset()
        {
            additive = true;
            intensity = 1;
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


        public void PlayPreview()
        {

        }


        public void StopPreview()
        {

        }
    }
}
