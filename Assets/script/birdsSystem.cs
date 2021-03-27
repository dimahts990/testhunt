using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class birdsSystem : MonoBehaviour
{
    Animator _anim;
    Rigidbody rb;    
    Sequence Seq;
    [SerializeField]
    Transform target0Transform, target1Transform;

    public float DurationFloat;

    private void Start()
    {
        _anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();

        moveBurd();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
            Die();
    }

    public void Die()
    {
        Seq.Kill();
        _anim.SetBool("die", true);
        GetComponent<BoxCollider>().isTrigger = false;
        rb.useGravity = true;
        PlayerMove.StartStopPlayer(true);
        UISystem.addProgress();
    }

    void moveBurd()
    {
        Seq = DOTween.Sequence();
        Seq.Append(transform.DOMove(target1Transform.position, DurationFloat, false));
        Seq.Join(transform.DORotate(target1Transform.rotation.eulerAngles, DurationFloat, RotateMode.Fast));
        Seq.Append(transform.DOMove(target0Transform.position, DurationFloat, false));
        Seq.Join(transform.DORotate(target0Transform.rotation.eulerAngles, DurationFloat, RotateMode.Fast));
        Seq.OnComplete(moveBurd);
    }
}
