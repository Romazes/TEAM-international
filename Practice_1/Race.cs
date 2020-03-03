using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Practice_1
{
    class Race
    {
        public bool IsSuccess { get; set; }
        public string FailedRaceInformation { get; set; }
        public bool IsTie { get; set; }
        public RaceCar WinningRaceCar { get; set; }

        public List<RaceCar> raceCarsList;

        public Race()
        {
            raceCarsList = new List<RaceCar>();
        }
    }
}
