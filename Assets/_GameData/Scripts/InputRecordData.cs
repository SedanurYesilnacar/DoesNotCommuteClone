using System;
using System.Collections.Generic;

namespace _GameData.Scripts
{
    [Serializable]
    public class InputRecordData
    {
        public List<int> recordedData;
        
        public InputRecordData() => recordedData = new List<int>();

        public void SaveData(int data) => recordedData.Add(data);
    }
}