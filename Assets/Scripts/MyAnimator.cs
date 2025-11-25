using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class MyAnimator : MonoBehaviour
{

    public int numberOfHits = 0;

    public GameObject source;
    public GameObject target;

    public float duration;


    public void Punch()
    {
        var originalPosition = new Vector3(source.transform.localPosition.x, source.transform.localPosition.y);
        var inbound = source.transform.DOLocalMove(target.transform.localPosition, duration);

        inbound.SetEase(Ease.Linear);

        inbound.OnComplete(() =>
        {
            numberOfHits++;

            for (int i = 0; i < target.transform.childCount; i++)
                target.transform.GetChild(i).gameObject.SetActive(i == numberOfHits || (numberOfHits >= target.transform.childCount && i == target.transform.childCount - 1));


            source.transform.DOLocalMove(originalPosition, duration * 2);
        });
        
    }
}
