using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AudioPeer : MonoBehaviour
{
    AudioSource audioSource;
    public static float[] samples = new float[512];
    public static float[] frequencyBand = new float[8];

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        GetSpectrumAudioSource();
        CreateFrequencyBands();
    }

    private void GetSpectrumAudioSource()
    {
        audioSource.GetSpectrumData(samples, 0, FFTWindow.Blackman);
    }

    private void CreateFrequencyBands()
    {
        /*
         * 22050 / 512 = 43 hertz per sample
         * 
         * 20 - 60 herts
           60 - 250 herts
           250 - 500 herts
           500 - 2000 herts
           2000 - 4000 herts
           4000 - 6000 herts
           6000 - 20000 herts
         * 
         * 0 - 2 = 86 herts
         * 1 - 4 = 172 herts - 87-258
         * 2 - 8 = 344 herts - 259-602
         * 3 - 16 = 688 herts - 603-1290
         * 4 - 32 = 1376 herts - 1291-2666
         * 5 - 64 = 2752 herts - 2667-5418
         * 6 - 128 = 5504 herts - 5419-10922
         * 7 - 256 = 11008 herts - 10923-21930
         * 510
         */

        int count = 0;

        for (int i = 0; i < 8; i++)
        {
            float average = 0f;
            int sampleCount = (int) Mathf.Pow(2, i) * 2;

            if(i==7)
            {
                sampleCount += 2;
            }

            for (int j = 0; j < sampleCount; j++)
            {
                average += samples[count] * (count + 1);
                count++;
            }

            average /= count;
            frequencyBand[i] = average * 10f;
        }
    }
}
