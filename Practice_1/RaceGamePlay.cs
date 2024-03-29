﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace Practice_1
{
    class RaceGamePlay
    {
        public delegate void OutputInfo(string message);
        public event OutputInfo Notify;

        public Race LetStartRace(List<RaceCar> raceCars, RequirementsForRace requirementForRace)
        {
            var result = new Race();
            if (this.ValidateCarsForRace(requirementForRace, raceCars))
            {
                result = DetermineWinner(raceCars);
            }
            else
            {
                result.IsSuccess = false;
                result.FailedRaceInformation = ("Not all race cars met the criteria to start race. Check his Max Speed or Car's year.");
            }
            return result;
        }

        private Race DetermineWinner(List<RaceCar> raceCars)
        {

            var result = new Race();
            if (raceCars.Capacity != 0)
            {
                var racingCars = new List<RaceCar>(raceCars);

                var winningCar = racingCars.OrderByDescending(c => c.MaxSpeed).ToList()[0];
                var sameSpeedCars = racingCars.Where(c => c.MaxSpeed == winningCar.MaxSpeed && c.Driver.Name != winningCar.Driver.Name).ToList();               
                //Notify?.Invoke($"On start are {raceCar1.Driver.Name} on {raceCar1.ModelOfCar.ToString()}({raceCar1.MaxSpeed}) VS {raceCar2.Driver.Name} on {raceCar2.ModelOfCar.ToString()}({raceCar2.MaxSpeed})");
                if (sameSpeedCars.Any())
                {
                    result.IsSuccess = true;
                    result.IsTie = true;
                    var tiedCars = new List<RaceCar>();
                    tiedCars.Add(winningCar);
                    tiedCars.AddRange(sameSpeedCars);
                    result.raceCarsList = tiedCars;
                }
                else
                {
                    result.IsSuccess = true;
                    result.IsTie = false;
                    result.WinningRaceCar = winningCar;
                }
                return result;
            }
            else
            {
                result.IsSuccess = false;
                result.FailedRaceInformation = "There needs to be 2 cars to race.No race occurred.";
            }
            return result;
        }

        private bool ValidateCarsForRace(RequirementsForRace requirements, List<RaceCar> raceCars)
        {
            var result = true;
            try
            {
                var inValidCars = raceCars.Where(c => c.MaxSpeed < requirements.MinSpeedForCar |
                                                      c.Year < requirements.MinYearForCar).ToList();
                result = inValidCars.Any() == false;
            }
            catch (Exception ex)
            {
                Notify?.Invoke($"{ex.Message}");
            }
            return result;
        }
    }
}
