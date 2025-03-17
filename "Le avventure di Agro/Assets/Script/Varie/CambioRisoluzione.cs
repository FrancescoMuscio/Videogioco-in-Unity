using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CambioRisoluzione : MonoBehaviour
{
    Resolution[] Risoluzioni;
    public Dropdown DropdownRisoluzione;
    private void Start()
    {
        int RisoluzioneCorrente = 0;
        Risoluzioni = Screen.resolutions;
        DropdownRisoluzione.ClearOptions();
        List<string> op = new List<string>();
        for (int i = 0; i < Risoluzioni.Length; i++)
        {
            string opzione = Risoluzioni[i].width + " x " + Risoluzioni[i].height;
            if(!op.Contains(opzione)){
                op.Add(opzione);
            }
            
            if (Risoluzioni[i].width == Screen.currentResolution.width && Risoluzioni[i].height == Screen.currentResolution.height)
            {
                RisoluzioneCorrente = i;
            }
        }
        DropdownRisoluzione.AddOptions(op);
        DropdownRisoluzione.value = RisoluzioneCorrente;
        DropdownRisoluzione.RefreshShownValue();
    }
    public void SetRisoluzione(int IndexRisoluzione)
    {
        
        if (IndexRisoluzione < 0 || IndexRisoluzione >= Risoluzioni.Length) return;

        Resolution res = Risoluzioni[IndexRisoluzione];
        QualitySettings.SetQualityLevel(5, true);
        Screen.SetResolution(res.width, res.height, FullScreenMode.FullScreenWindow);
        
        
        
        
        
        
        /*Resolution res = Risoluzioni[IndexRisoluzione];
        Screen.SetResolution(res.width, res.height, Screen.fullScreen);*/
        //
    }
}