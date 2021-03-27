using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Dreamteck.Splines;
using DG.Tweening;

public class PlayerMove : MonoBehaviour
{
    static SplineFollower followerPlayer;
    RaycastHit Po;
    [SerializeField]
    Transform gun, bulletSpawnTransform, bulletPrefabTransform;

    public Vector3 temp;

    private void Start()
    {
        followerPlayer = GetComponent<SplineFollower>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && !followerPlayer.follow)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            int layer = 1 << 3;
            Physics.Raycast(ray, out Po);
            temp = Po.point;
            Sequence seqTemp = DOTween.Sequence();
            seqTemp.Append(gun.DOLookAt(Po.point, 0.3f));
            seqTemp.OnComplete(fier);
        }
    }

    public static void StartStopPlayer(bool _bool) => 
        followerPlayer.follow = _bool;
    
    private void fier()
    {
        Transform _bullet = Instantiate(bulletPrefabTransform, bulletSpawnTransform.position, Quaternion.Euler(bulletSpawnTransform.rotation.eulerAngles));
    }
}
