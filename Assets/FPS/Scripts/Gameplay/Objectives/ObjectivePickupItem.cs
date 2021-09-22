using System.Collections.Generic;
using Unity.FPS.Game;
using UnityEngine;

namespace Unity.FPS.Gameplay
{
    public class ObjectivePickupItem : Objective
    {
        [Tooltip("Item to pickup to complete the objective")]
        //public List<GameObject> ItemToPickup;
        public GameObject LeaveZone;
        public int NeededAmountOfFuel;
        public bool EnoughFuel = false;
        public int CurrentFuelCount;

        protected override void Start()
        {
            base.Start();
            UpdateObjective("Fuel " + NeededAmountOfFuel + "/" + CurrentFuelCount, "", Title);

            EventManager.AddListener<PickupEvent>(OnPickupEvent);
        }

        void OnPickupEvent(PickupEvent evt)
        {
            if (0 == evt.Fuel)
                return;

            CurrentFuelCount += evt.Fuel;

            evt.Fuel = 0;

            if (CurrentFuelCount >= NeededAmountOfFuel) EnoughFuel = true;

            //print(EnoughFuel);
            //Description = "Fuel " + NeededAmountOfFuel + "/" + CurrentFuelCount;
            UpdateObjective("Fuel " + NeededAmountOfFuel + "/" + CurrentFuelCount, "", Title);
            // this will trigger the objective completion
            // it works even if the player can't pickup the item (i.e. objective pickup healthpack while at full health)
            //CompleteObjective(string.Empty, string.Empty, "Objective complete : " + Title);

            /*if (gameObject)
            {
                Destroy(gameObject);
            }*/
        }

        public void Win() 
        {
            CompleteObjective(string.Empty, string.Empty, "Objective complete : " + Title);
        }

        void OnDestroy()
        {
            EventManager.RemoveListener<PickupEvent>(OnPickupEvent);
        }
    }
}