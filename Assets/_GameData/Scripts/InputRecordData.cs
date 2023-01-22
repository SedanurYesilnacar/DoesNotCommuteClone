using System;
using System.Collections.Generic;
using UnityEngine;

namespace _GameData.Scripts
{
    [Serializable]
    public class CarRecordData
    {
        public List<RecordData> recordedData;
        
        public CarRecordData() => recordedData = new List<RecordData>();

        public void SaveData(RecordData data) => recordedData.Add(data);
    }

    public struct RecordData
    {
        public Vector3 position;
        public Vector3 rotation;
        public Vector3 velocity;
    }
}