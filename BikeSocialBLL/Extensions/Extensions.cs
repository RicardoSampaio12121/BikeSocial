using BikeSocialDTOs;
using BikeSocialEntities;
namespace BikeSocialBLL.Extensions;

public static class Extensions
{
    public static Users AsUser(this GetUserRegisterDto dto)
    {
        Users user = new();

        user.username = dto.username;
        user.email = dto.email;
        user.password = dto.password;
        user.birthDate = dto.birthdate;
        user.contact = dto.contact;
        user.PlacesId = dto.placeId;
        user.UserTypesId = dto.userTypeId;
        
        return user;
    }

    public static ReturnProfileDto AsReturnProfile(this Profile profile)
    {
        ReturnProfileDto profileDto = new();
        
        profileDto.userId = profile.UsersId;
        profileDto.description = profile.description;

        return profileDto;
    }

    public static ReturnResultsDto AsReturnResults(this RaceResults results)
    {
        ReturnResultsDto resultsDto = new();
        resultsDto.atheleteId = results.AthletesId;
        resultsDto.result = results.Position;

        return resultsDto;
    }
    public static Friend AsNewFriend(this CreateFriendDto friendDto, int userId)
    {
        Friend friend = new();

        friend.solicitorId = userId;
        friend.recieptientId = friendDto.recieptientId;
        friend.status = false;
        friend.timeSent = friendDto.timeSent;

        return friend;
    }

    //    public static Friend AsFriend(this GetFriendDto friendDto)
    //    {
    //        Friend friend = new();

    //        friend.solicitorId = friendDto.solicitorId;
    //        friend.recieptientId = friendDto.recieptientId;
    //        friend.status = friendDto.status;
    //        friend.timeSent = friendDto.timeSent;

    //        return friend;
    //    }
    public static Trainings AsTraining(this CreateTrainingDto trainingDto, int teamId)
    {
        Trainings train = new();

        train.TeamsId = teamId;
        train.Name = trainingDto.name;
        train.dateTime = trainingDto.dateTime;
        train.EstimatedTime = trainingDto.estimatedTime;
        train.Distance = trainingDto.distance;
        train.PlacesId = trainingDto.placeId;
        train.TrainingTypesId = trainingDto.trainingTypeId;

        return train;
    }


    public static Races AsRace(this CreateRaceDto raceDto)
    {
        Races race = new();

        race.description = raceDto.description;
        race.distance = raceDto.distance;
        race.estimateTime = raceDto.estimatedTime;
        race.dateTime = raceDto.dateTime;
        race.FederationsId = raceDto.FederationId;
        race.RaceTypesId = raceDto.RaceTypeId;
        race.PlacesId = raceDto.placeId;
        race.State = "Active";

        return race;
    }

    public static Routes AsRoute(this CreateRouteDto createRouteDto, int userId)
    {
        Routes route = new();

        route.UsersId = userId;
        route.Public = createRouteDto.Public;
        route.Description = createRouteDto.Description;
        route.dateTime = createRouteDto.dateTime;
        route.EstimatedTime = createRouteDto.estimatedTime;
        route.Distance= createRouteDto.distance;
        route.PlacesId = createRouteDto.placeId;
        route.RouteTypesId = createRouteDto.routeTypeId;

        return route;

    }

    public static Routes AsRoute(this CreateRoutePeopleDto createRouteDto, int userId)
    {
        Routes route = new();

        route.UsersId = userId;
        route.Public = createRouteDto.Public;
        route.Description = createRouteDto.Description;
        route.dateTime = createRouteDto.dateTime;
        route.EstimatedTime = createRouteDto.estimatedTime;
        route.Distance = createRouteDto.distance;
        route.PlacesId = createRouteDto.placeId;
        route.RouteTypesId = createRouteDto.routeTypeId;

        return route;

    }

    public static List<RouteInvites> AsListRoutePeopleInvited(this CreateRoutePeopleDto dto, int routeId)
    {
        List<RouteInvites> output = new();

        var list = dto.people;

        foreach (var person in list)
        {
            output.Add(new RouteInvites()
            {
                UsersId = person,
                RoutesId = routeId
            });
        }

        return output;
    }

    public static Athletes AsAthlete(this CreateAthleteDto athleteDto)
    {
        Athletes athlete = new();

        athlete.UsersId = athleteDto.userId;
        athlete.TeamsId = athleteDto.teamId;
        athlete.AthleteParentsId = athleteDto.parentId;
        athlete.AthleteTypesId = athleteDto.athleteTypeId;
        athlete.FederationsId = athleteDto.federationId;

        return athlete;
    }

    public static Teams AsTeam(this CreateEquipaDto equipaDto, int clubId)
    {
        Teams equipa = new();

        equipa.Name = equipaDto.name;
        equipa.PlacesId = equipaDto.placeId;
        equipa.ClubsId = clubId;

        return equipa;
    }

    public static TeamInviteAthletes AsTeamAthleteInvite(this CreateConvAtletaEquiDto conviteAE, int teamId)
    {
        TeamInviteAthletes conAtletaEqui = new();

        conAtletaEqui.TeamsId = teamId;
        conAtletaEqui.AthletesId = conviteAE.id_athelete;

        return conAtletaEqui;
    }

    public static TeamInviteCoaches AsTeamInviteCoaches(this CreateConvCoachEquiDto conviteTE)
    {
        TeamInviteCoaches conCoachEqui = new();

        conCoachEqui.TeamsId = conviteTE.idEquipa;
        conCoachEqui.CoachesId = conviteTE.idCoach;

        return conCoachEqui;

    }

    public static RaceInvites AsRaceInvite(this GetRaceInviteDto adicionarAR)
    {
        RaceInvites invite = new();

        invite.AthletesId = adicionarAR.id_atleta;
        invite.RacesId = adicionarAR.raceId;
        invite.Confirmation = false;

        return invite;

    }

    public static RouteInvites AsRouteInvite(this GetInviteToRouteDto dto)
    {
        RouteInvites output = new();

        output.UsersId = dto.userId;
        output.RoutesId = dto.routeId;

        return output;
    }

    public static Trainings AsTrainingD(this CreateTrainingWithInvitesDto trainingDto, int teamId)
    {
        Trainings train = new();

        train.TeamsId = teamId;
        train.Name = trainingDto.name;
        train.dateTime = trainingDto.dateTime;
        train.EstimatedTime = trainingDto.estimatedTime;
        train.Distance = trainingDto.distance;
        train.PlacesId = trainingDto.placeId;
        train.TrainingTypesId = trainingDto.trainingTypeId;

        return train;
    }

    public static List<TrainingInvites> AsListTrainingInvites(this CreateTrainingWithInvitesDto dto, int trainingId)
    {
        List<TrainingInvites> output = new();

        var list = dto.athleteId;

        foreach (var athleteId in list)
        {
            output.Add(new TrainingInvites()
            {
                TrainingsId = trainingId,
                AthletesId = athleteId,
                Confirmation = false
            });
        }

        return output;
    }

    public static TrainingInvites AsTrainingAthletesInvite(this GetInviteToTrainingDto dto)
    {
        TrainingInvites output = new();

        output.TrainingsId = dto.trainingId;
        output.AthletesId = dto.athleteId;

        return output;
    }

    public static List<RaceResults> AsListRaceResult(this GetPublishResultsDto dto)
    {
        List<RaceResults> results = new();

        var dtoResults = dto.placements;

        foreach (KeyValuePair<int, int> result in dtoResults)
        {
            results.Add(new RaceResults()
            {
                RacesId = dto.raceId,
                AthletesId = result.Key,
                Position = result.Value
            });
        }

        return results;
    }
    
    public static Prizes AsPrize(this CreatePrizeDto prizeDto)
    {
        Prizes prize = new();

        prize.Name = prizeDto.name;

        return prize;
    }
    
    public static ReturnAchievementDto AsReturnAchievement(this Achievements achievement)
    {
        ReturnAchievementDto achievementDto = new();

        achievementDto.AchievementTypeId = achievement.AchievementTypesId;
        achievementDto.achievementTime = achievement.achievementTime;
        achievementDto.date = achievement.date;
        achievementDto.PlacesId = achievement.PlacesId;

        return achievementDto;
    }

    //public static AthleteFederationRequests AsAthleteFederationRequest(this GetAthleteFederationRequestDto dto, int athleteId)
    
    public static Achievements AsAchievement(this ReturnAchievementDto achievementDto)
    {
        Achievements achievement = new();

        achievement.Name = achievementDto.Name;
        achievement.AchievementTypesId = achievementDto.AchievementTypeId;
        achievement.achievementTime = achievementDto.achievementTime;
        achievement.date = achievementDto.date;
        achievement.PlacesId = achievementDto.PlacesId;

        return achievement;
    }
    public static Plans AsPlan(this CreatePlanDto planDto)
    {
        Plans plan = new();

        plan.description = planDto.description;
        plan.startTime = planDto.startTime;
        plan.finishTime = planDto.finishTime;
        plan.EstimatedTime = planDto.estimatedTime;

        return plan;
    }

    public static AthleteFederationRequests AsAthleteFederationRequest(this GetAthleteFederationRequestDto dto, int athleteId)
    {
        AthleteFederationRequests output = new();

        output.AthletesId = athleteId;
        output.FederationsId = dto.federationId;

        return output;
    }

    public static TeamFederationRequests AsTeamFederationRequest(this GetTeamFederationRequestDto dto)
    {
        TeamFederationRequests output = new();

        output.TeamsId = dto.teamId;
        output.FederationsId = dto.federationId;

        return output;
    }


    public static ReturnUserDto AsReturnUserDto(this Users user)
    {
        return new ReturnUserDto
        {
            id = user.Id,
            username = user.username,
            birthDate = user.birthDate.ToShortDateString(),
            contact = user.contact,
            placeId = user.PlacesId,
            userTypeId = user.UserTypesId,
            email = user.email
        };
    }

    public static ReturnConsultResultRaceDto AsReturnConsultResultRace(this RaceResults consultresultrace)
    {
        ReturnConsultResultRaceDto consultRRDto = new();

        consultRRDto.athletesId = consultresultrace.AthletesId;
        consultRRDto.racesId = (int)consultresultrace.RacesId;

        return consultRRDto;
    }

    //public static GetUserRegisterDto AsGetUserRegisterDto(this Users entity)
    //{
    //    GetUserRegisterDto output = new()
    //    {
    //        username = entity.username,
    //        email = entity.email,
    //        password = entity.password,
    //        birthdate = entity.birthDate,
    //        contact = entity.contact,
    //        placeId = entity.PlacesId,
    //        userTypeId = entity.UserTypesId
    //    };
    //    return output;
    //}

    public static ReturnAthleteDto AsReturnAthleteDto(this Athletes athlete)
    {
        return new ReturnAthleteDto
        {
            Id = athlete.Id,
            UserId = athlete.UsersId,
            TeamId = athlete.TeamsId,
            ParentId = athlete.AthleteParentsId,
            AthleteTypeId = athlete.AthleteTypesId,
            FederationId = athlete.FederationsId,
            PlanId = athlete.PlansId
        };
    }

    public static ReturnEquipaDto AsReturnTeamDto(this Teams team)
    {
        return new ReturnEquipaDto
        {
            id = team.Id,
            name = team.Name,
            placeId = team.PlacesId,
            clubeId = team.ClubsId,
            federationId = team.FederationsId
        };
    }

    public static ReturnPlanDto AsReturnPlanDto(this Plans plan)
    {
        return new ReturnPlanDto
        {
            Id = plan.Id,
            description = plan.description,
            startTime = plan.startTime,
            finishTime = plan.finishTime,
            EstimatedTime = plan.EstimatedTime
        };
    }

    public static ReturnPrizeDto AsReturnPrizeDto(this Prizes prize)
    {
        return new ReturnPrizeDto
        {
            Id = prize.Id,
            Name = prize.Name
        };
    }

    public static ReturnRaceDto AsReturnRaceDto(this Races race)
    {
        return new ReturnRaceDto
        {
            Id = race.Id,
            Description = race.description,
            Distance = race.distance,
            EstimatedTime = race.estimateTime,
            dateTime = race.dateTime,
            FederationId = race.FederationsId,
            RaceTypeId = race.RaceTypesId,
            PlaceId = race.PlacesId,
            State = race.State
        };
    }

    public static ReturnRouteDto AsReturnRouteDto(this Routes route)
    {
        return new ReturnRouteDto
        {
            Id = route.Id,
            UsersId = route.UsersId,
            Public = route.Public,
            Description = route.Description,
            DateTime = route.dateTime,
            EstimatedTime = route.EstimatedTime,
            Distance = route.Distance,
            PlacesId = route.PlacesId,
            RouteTypesId = route.RouteTypesId
        };
    }

    public static ReturnTrainingDto AsReturnTrainingDto(this Trainings training)
    {
        return new ReturnTrainingDto
        {
            Id = training.Id,
            teamId = training.TeamsId,
            name = training.Name,
            dateTime = training.dateTime,
            estimatedTime = training.EstimatedTime,
            distance = training.Distance,
            placesId = training.PlacesId,
            trainingTypesId = training.TrainingTypesId,
            plansId = training.PlacesId
        };
    }
}