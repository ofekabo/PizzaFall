using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tabtale.TTPlugins;
using UnityEngine;

public class CLIKSdkManager : MonoBehaviour
{
    private void Awake()
    {
        TTPCore.Setup();
    }

    private async void Start()
    {
        await Task.Delay(3000);
        ReportMissionStart();
    }

    void ReportMissionStart()
    {
        TTPGameProgression.FirebaseEvents.MissionStarted(1, null);
    }
}
