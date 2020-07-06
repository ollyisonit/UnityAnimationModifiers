using System.Collections;
using System.Linq;
using UnityEngine;

namespace dninosores.UnityAnimationModifiers
{
    [DefaultExecutionOrder(999999)]
    public abstract class LateUpdateModifier<T> : MonoBehaviour
    {
        public bool additive = true;
        public float intensity = 1;
        protected T[] originalValues;

        protected abstract T[] GetValues();

        protected abstract void SetValues(T[] value);

        protected abstract T GetModifiedValue(T originalValue);

        void LateUpdate()
        {
            if (isActiveAndEnabled)
            {
                if (additive)
                {
                    originalValues = GetValues();
                    StartCoroutine(SetValueBack());
                }
                T[] outputValues = new T[originalValues.Length];
                for (int i = 0; i < outputValues.Length; i++)
                {
                    outputValues[i] = GetModifiedValue(originalValues[i]);
                }
                SetValues(outputValues);
            }
        }

        private IEnumerator SetValueBack()
        {
            yield return new WaitForEndOfFrame();
            if (additive)
            {
                SetValues(originalValues);
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
