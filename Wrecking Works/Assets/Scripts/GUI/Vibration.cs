using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Lofelt.NiceVibrations;

public static class Vibration
{
    public static void VibrationFunc()
    {
        HapticPatterns.PlayPreset(HapticPatterns.PresetType.LightImpact);
    }
}
