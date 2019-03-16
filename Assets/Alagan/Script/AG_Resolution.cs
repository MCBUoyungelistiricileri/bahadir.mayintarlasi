using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class AG_Resolution : MonoBehaviour {
    [Range(0, 1)]
    public float tabletResolutionMatch;
    [Range(0,1)]
    public float phoneResolotionMatch;
    void Start () {

        if (Application.platform != RuntimePlatform.WindowsEditor)
        {
            if (IsTablet())
            {
                GetComponent<CanvasScaler>().matchWidthOrHeight = tabletResolutionMatch;
            }
            else
            {
                GetComponent<CanvasScaler>().matchWidthOrHeight = phoneResolotionMatch;
            }
        }
    }
    public static bool IsTablet()
    {

        float ssw;
        if (Screen.width > Screen.height) { ssw = Screen.width; } else { ssw = Screen.height; }

        if (ssw < 800) return false;

        if (Application.platform == RuntimePlatform.Android || Application.platform == RuntimePlatform.IPhonePlayer || Application.platform == RuntimePlatform.WindowsEditor)
        {
            float screenWidth = Screen.width / Screen.dpi;
            float screenHeight = Screen.height / Screen.dpi;
            float size = Mathf.Sqrt(Mathf.Pow(screenWidth, 2) + Mathf.Pow(screenHeight, 2));
            Debug.Log(size);
            if (size >= 6.5f) return true;
        }

        return false;
    }

    public static float DeviceDiagonalSizeInInches()
    {
        float screenWidth = Screen.width / Screen.dpi;
        float screenHeight = Screen.height / Screen.dpi;
        float diagonalInches = Mathf.Sqrt(Mathf.Pow(screenWidth, 2) + Mathf.Pow(screenHeight, 2));

        Debug.Log("Getting device inches: " + diagonalInches);

        return diagonalInches;
    }
}
