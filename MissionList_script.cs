using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LevelManagement.Missions
{
    [CreateAssetMenu(fileName ="Missions", menuName ="Missions/Create MissionList", order =1)]
    public class MissionList_script : ScriptableObject
    {

        #region Inspector
        [SerializeField] private List<MissionSpecs> _missions;
        #endregion


        #region Properties
        public int Total_Missions => _missions.Count;
        #endregion



        public MissionSpecs GetMission(int index_)
        {
            return _missions[index_];
        }
    } 
}
