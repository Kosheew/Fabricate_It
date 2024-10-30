using Buildings;
using BuildingState;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace BuildingState
{
    public class MoveState : IBuildingState
    {
        public void Enter(BuildingContext context)
        {
            Debug.Log("Start Move");
        }

        public void Exit(BuildingContext context)
        {
           
        }

        public void ShowPanel(BuildingContext context)
        {
            
        }

        public void Update(BuildingContext context)
        {
            
        }

       
    }
}