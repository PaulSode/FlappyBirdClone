#if PLATFORM_ANDROID
using System.Collections;
using System.Threading;
using UnityEngine;
using UnityEngine.Serialization;

public class FrameRateManager : MonoBehaviour
{

    

    [Header("Frame Settings")]
    
    [SerializeField] private int maxRate = 150;
    [SerializeField] private float targetFrameRate = 60.0f;
    private float _currentFrameTime;
    
    void Awake()
    {
        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = maxRate;
        _currentFrameTime = Time.realtimeSinceStartup;
        StartCoroutine("WaitForNextFrame");
    }
    IEnumerator WaitForNextFrame()
    {
        while (true)
        {
            yield return new WaitForEndOfFrame();
            _currentFrameTime += 1.0f / targetFrameRate;
            var t = Time.realtimeSinceStartup;
            var sleepTime = _currentFrameTime - t - 0.01f;
            if (sleepTime > 0)
                Thread.Sleep((int)(sleepTime * 1000));
            while (t < _currentFrameTime)
                t = Time.realtimeSinceStartup;
        }
    }
}
#endif