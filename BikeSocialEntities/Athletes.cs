﻿namespace BikeSocialEntities
{
    public class Athletes
    {
        public int Id { get; set; }
        public int? UsersId { get; set; }
        public int? TeamsId { get; set; }
        public int? AthleteParentsId { get; set; }
        public int AthleteTypesId { get; set; }
        public int? FederationsId { get; set; }
        public int? TrainingsId { get; set; }
        public int? PlansId { get; set; }


        public List<TeamInviteAthletes> TeamInviteAthletes { get; set; }
        public List<RaceInvites> RaceInvites { get; set; }
        public List<RaceResults> RaceResults { get; set; }
        public List<TrainingInvites> TrainingInvites { get; set; }
        public List<AthleteFederationRequests> AthleteFederationRequests { get; set; }
        public List<AthleteAchievements> AthleteAchievements { get; set; }
    }
}
