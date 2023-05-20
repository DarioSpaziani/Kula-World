
using UnityEngine;

public class SkinManager : MonoBehaviour
{
    public static int skinSelected;
    public GameObject[] selectors;
    

    private void Start()
    {
        selectors[0].SetActive(true);
        skinSelected = 0;
    }

    public void SetSkin(int skinNumber) {
        skinSelected = skinNumber;
        selectors[skinNumber].SetActive(true);

        for (int i = 0; i < selectors.Length; i++) {
            if (i != skinNumber) {
                selectors[i].SetActive(false);
            }
        }
    }
}
