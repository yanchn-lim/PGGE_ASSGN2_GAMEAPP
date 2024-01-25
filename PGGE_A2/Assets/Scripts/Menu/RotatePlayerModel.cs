using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatePlayerModel : MonoBehaviour
{
    public float rotateSpeed;

    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(RotateModel());
    }

    IEnumerator RotateModel()
    {
        while (true)
        {
            transform.Rotate(new(0, rotateSpeed, 0));

            yield return null;
        }
    }

    private void OnDestroy()
    {
        StopAllCoroutines();
    }
}
