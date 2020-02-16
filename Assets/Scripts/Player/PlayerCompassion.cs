using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCompassion : MonoBehaviour
{
    private Slider compassionMeter;
    private Image sliderFill;
    private Image heart;
    private Image brokenHeart;
    private float compassionValue = 50;

    // Fill colours
    private Color maxFill = new Color(1, 192f / 255f, 203f / 255f, 1); // (FF, C0, CB, FF) - RGBA
    private Color minFill = Color.black;

    // For testing 
    private int count = 0;
    private bool increase = true;

    // Start is called before the first frame update
    void Start()
    {
        var hud = GameObject.FindGameObjectWithTag("HUD").transform;

        // Find all necessary HUD components
        compassionMeter = hud.Find("Slider").GetComponent<Slider>();
        sliderFill = hud.Find("Slider").GetChild(1).GetChild(0).GetComponent<Image>();
        heart = hud.Find("Heart").GetComponent<Image>();
        brokenHeart = hud.Find("BrokenHeart").GetComponent<Image>();

        // Start with only heart enabled
        brokenHeart.enabled = false;

        // Start with half of bar filled
        compassionMeter.value = compassionMeter.maxValue / 2;
        compassionValue = compassionMeter.value;
    }

    // Update is called once per frame
    void Update()
    {
        // TestSliderUpdate();
    }

    // Tests the slider by incrementing then decrementing
    private void TestSliderUpdate() {
        count++;

        if (count >= 6) {
            count = 0;

            var delta = increase ? 1 : -1;
            ChangeCompassion(delta);

            if (compassionValue == compassionMeter.maxValue) {
                increase = false;
            }
            else if (compassionValue == compassionMeter.minValue) {
                increase = true;
            }
        }
    }

    // Increment or decrement compassion meter
    public void ChangeCompassion(float delta) {
        compassionValue += delta;
        compassionValue = Mathf.Clamp(compassionValue, compassionMeter.minValue, compassionMeter.maxValue);

        compassionMeter.value = compassionValue;

        // Have max colour at 80% of max fill
        var gradientVal = Mathf.Clamp(compassionValue / (compassionMeter.maxValue * 0.8f), 0f, 1f);
        sliderFill.color = Color.Lerp(minFill, maxFill, gradientVal);

        if (compassionValue <= 45) {
            heart.enabled = false;
            brokenHeart.enabled = true;
        }
        else {
            heart.enabled = true;
            brokenHeart.enabled = false;
        }
    }
}
