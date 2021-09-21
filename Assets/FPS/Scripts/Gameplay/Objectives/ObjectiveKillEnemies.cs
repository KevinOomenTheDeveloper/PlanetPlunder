using Unity.FPS.Game;
using UnityEngine;

namespace Unity.FPS.Gameplay
{
    public class ObjectiveKillEnemies : Objective
    {
        //[Tooltip("Chose whether you need to kill every enemies or only a minimum amount")]
        public int MinimumFuel = 10;

        //[Tooltip("If MustKillAllEnemies is false, this is the amount of enemy kills required")]
        public int StartingFuel = 0;

        [Tooltip("Start sending notification about remaining enemies when this amount of enemies is left")]
        public int NotificationRemainingFuelThreshold = 10;

        public bool LeaveRequirementsMet = false;

        int m_FuelTotal;

        protected override void Start()
        {
            base.Start();

            EventManager.AddListener<FuelPickUpEvent>(OnFuelPickedUp);

            // set a title and description specific for this type of objective, if it hasn't one
            if (string.IsNullOrEmpty(Title))
                Title = "Atleast get " + MinimumFuel.ToString() +
                        " more fuel!";

            //if (string.IsNullOrEmpty(Description))
            //    Description = GetUpdatedCounterAmount();
        }

        void OnFuelPickedUp(FuelPickUpEvent evt)
        {
            if (IsCompleted)
                return;

            m_FuelTotal++;

            int targetRemaining = MinimumFuel - m_FuelTotal;

            // update the objective text according to how many enemies remain to kill
            if (targetRemaining <= 0)
            {
                LeaveRequirementsMet = true;
            }
            else
            {
                // create a notification text if needed, if it stays empty, the notification will not be created
                string notificationText = NotificationRemainingFuelThreshold >= targetRemaining
                    ? targetRemaining + " Fuel left"
                    : string.Empty;

                UpdateObjective(string.Empty, GetUpdatedCounterAmount(), notificationText);
            }
        }

        string GetUpdatedCounterAmount()
        {
            return m_FuelTotal + " / " + MinimumFuel;
        }

        void OnDestroy()
        {
            EventManager.RemoveListener<FuelPickUpEvent>(OnFuelPickedUp);
        }
    }
}