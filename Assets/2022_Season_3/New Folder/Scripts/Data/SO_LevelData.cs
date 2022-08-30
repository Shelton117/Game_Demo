using _2022_Season_3.New_Folder.Scripts.Utilities;
using System.Collections.Generic;
using UnityEngine;

namespace _2022_Season_3.New_Folder.Scripts.Data
{
    [CreateAssetMenu(fileName = "SO_LevelData", menuName = "Level Data/SO_LevelData")]
    public class SO_LevelData : ScriptableObject
    {
        public List<CommandID> commandID;
        public int times;
    }
}