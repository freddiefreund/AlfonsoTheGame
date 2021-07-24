using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class TutorialUI : MonoBehaviour
{
    float endScale = 10f;
    [SerializeField]
    float stayTime = 10f;
    void Start()
    {
        transform.localScale = new Vector3(0.01f, 0.01f, 0.01f);
        transform.DOScale(new Vector3(endScale, endScale, endScale), 2)
            .SetEase(Ease.OutBounce);
        StartCoroutine(FadeOut());
    }

    IEnumerator FadeOut()
    {
        yield return new WaitForSeconds(stayTime);
        transform.DOScale(new Vector3(0f, 0f, 0f), 1)
            .SetEase(Ease.InQuad);
        Destroy(gameObject, 1.1f);
    }
}
