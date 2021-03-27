using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletSystem : MonoBehaviour
{
    [SerializeField]
    float speed = 10f;

    private void Start() =>
        StartCoroutine(timer());
    

    private void Update() =>
                transform.position += transform.forward * speed * Time.deltaTime;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 3)
            other.GetComponent<birdsSystem>().Die();
    }

    private IEnumerator timer()
    {
        yield return new WaitForSeconds(5);
        Destroy(gameObject);
    }
}
