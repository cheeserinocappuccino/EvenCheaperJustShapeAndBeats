using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeacherCircleCirculate : MonoBehaviour {

    public int beatsEachCirculate;
    public int degreesEachTime;
    private int startbeat;

    private float originScale;
    public float scaleAmout;
	void Start () {
        startbeat = DJ.totalBeatCount;
        originScale = transform.localScale.x;
	}
	
	// Update is called once per frame
	void Update () {
        if (DJ.totalBeatCount - startbeat == beatsEachCirculate)
        {
            startbeat = DJ.totalBeatCount;
            //transform.Rotate(new Vector3(0, 0, degreesEachTime));
            StartCoroutine(Circulate(degreesEachTime, 3));
        }

        if (Input.GetKeyDown(KeyCode.K))
        {
            StartCoroutine(PopOut(scaleAmout,true));
            Debug.Log(originScale);
        }
	}

    IEnumerator Circulate(int _degrees, int _angleEachFrame)
    {
        if (_degrees > 0)
        {
            for (int i = _degrees / _angleEachFrame; i > 0; i--)
            {
                transform.Rotate(new Vector3(0, 0, _angleEachFrame));
                yield return null;
            }
        }
        else if (_degrees < 0)
        {
            for (int i = _degrees / _angleEachFrame; i < 0; i++)
            {
                transform.Rotate(new Vector3(0, 0, -_angleEachFrame));
                yield return null;
            }
        }
        // 先改成平滑的
    }

    public IEnumerator PopOut(float _scaleAmount, bool getBig)
    {
        float a = originScale;
        if (getBig == true)
        {
            while (a < _scaleAmount)
            {
                a += Time.deltaTime * 5;
                transform.localScale = new Vector3(a, a, a);

                yield return null;

            }
        }
        else
        {
            while (a > originScale)
            {
                a -= Time.deltaTime * 5;
                transform.localScale = new Vector3(a, a, a);

            }
        }

    }
}
