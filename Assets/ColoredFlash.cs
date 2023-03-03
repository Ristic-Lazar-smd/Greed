using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColoredFlash : MonoBehaviour
    {  

        [Tooltip("Material to switch to during the flash.")]
        [SerializeField] private Material flashMaterial;
        // The SpriteRenderer that should flash.
        private SpriteRenderer spriteRenderer;
        // The material that was in use, when the script started.
        private Material originalMaterial;
        private Coroutine flashRoutine;
        public float duration = 0.5F;

    
        void Start()
        {
            spriteRenderer = GetComponent<SpriteRenderer>();
            originalMaterial = spriteRenderer.material;
            flashMaterial = new Material(flashMaterial);
        }

        /*--FLASH MULTIPLE TIMES START--*/
        public void FlashMultiple(Color color)
        {
            if (flashRoutine != null)
            {
                StopCoroutine(flashRoutine);
            }
            flashRoutine = StartCoroutine(FlashMultipleRoutine(color));
        }
        private IEnumerator FlashMultipleRoutine(Color color)
        {
            StartCoroutine(FlashMultipleRoutineHelper(color));
            yield return new WaitForSeconds(duration);
            StopAllCoroutines();
            spriteRenderer.material = originalMaterial;
            flashRoutine = null;
        }
        private IEnumerator FlashMultipleRoutineHelper(Color color){
            spriteRenderer.material = flashMaterial;
            flashMaterial.color = color;
            yield return new WaitForSeconds(0.1f);
            spriteRenderer.material = originalMaterial;
            yield return new WaitForSeconds(0.1f);
            StartCoroutine(FlashMultipleRoutineHelper(color));
        }
        /*--FLASH MULTIPLE TIMES END--*/

        /*--FLASH ONCE START--*/
        public void FlashOnce(Color color)
        {
            if (flashRoutine != null)
            {
                StopCoroutine(flashRoutine);
            }
            flashRoutine = StartCoroutine(FlashOnceRoutine(color));
        }
        private IEnumerator FlashOnceRoutine(Color color)
        {
            spriteRenderer.material = flashMaterial;
            flashMaterial.color = color;
            yield return new WaitForSeconds(duration);
            spriteRenderer.material = originalMaterial;
            flashRoutine = null;
        }
        /*--FLASH ONCE END--*/
      
}
