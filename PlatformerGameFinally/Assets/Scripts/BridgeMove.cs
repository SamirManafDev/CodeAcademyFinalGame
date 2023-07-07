using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BridgeMove : MonoBehaviour
{ 
    [SerializeField] Transform endTransform;
    [SerializeField] public Transform startTransform;
    public Tweener endTween;
    private void Start()
    {
        endTween=transform.DOMove(endTransform.position, 1f).SetEase(Ease.Linear).SetLoops(-1, LoopType.Yoyo);
    }

}
