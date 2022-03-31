using BikeSocialDTOs;
using BikeSocialEntities;
namespace BikeSocialBLL.Extensions;

public static class Extensions
{
    public static User AsUser(this GetUserDto userDto)
    {
        User user = new();

        user.username = userDto.username;
        user.password = userDto.password;
        
        return user;
    }

    public static Friend AsNewFriend(this CreateFriendDto friendDto)
    {
        Friend friend = new();

        friend.solicitorId = friendDto.solicitorId;
        friend.recieptientId = friendDto.recieptientId;
        friend.status = false;
        friend.timeSent = friendDto.timeSent;

        return friend;
    }

    public static Friend AsFriend(this GetFriendDto friendDto)
    {
        Friend friend = new();

        friend.solicitorId = friendDto.solicitorId;
        friend.recieptientId = friendDto.recieptientId;
        friend.status = friendDto.status;
        friend.timeSent = friendDto.timeSent;

        return friend;
    }
    public static Trainings AsTraining(this CreateTrainingDto trainingDto)
    {
        Trainings train = new();

        train.Equipaid = trainingDto.teamId;
        train.Coachid = trainingDto.trainerId;
        train.name = trainingDto.name;
        train.dateTime = trainingDto.dateTime;
        train.EstimatedTime = trainingDto.estimatedTime;
        train.Distance = trainingDto.distance;
        train.PlaceId = trainingDto.placeId;
        train.TrainingTypeId = trainingDto.trainingTypeId;
        train.PlanId = trainingDto.planId;

        return train;
    }

    
    public static Race AsRace(this CreateRaceDto raceDto)
    {
        Race race = new();

        race.Description = raceDto.description;
        race.Distance = raceDto.distance;
        race.EstimatedTime = raceDto.estimatedTime;
        race.dateTime = raceDto.dateTime;
        race.FederationId = raceDto.FederationId;
        race.RaceTypeId = raceDto.RaceTypeId;
        race.PlaceId = raceDto.placeId;

        return race;
    }

    public static Route AsRoute(this CreateRouteDto createRouteDto)
    {
        Route route = new();

        route.userId = createRouteDto.userId;
        route.description = createRouteDto.Description;
        route.placeId = createRouteDto.placeId;
        route.routeTypeId = createRouteDto.routeTypeId;
        route.dateTime = createRouteDto.dateTime;
        route.estimatedTime = createRouteDto.estimatedTime;
        route.distance = createRouteDto.distance;

        return route;

    }
    
    public static Athlete AsAthlete(this CreateAthleteDto athleteDto)
    {
        Athlete athlete = new();

        athlete.name = athleteDto.name;
        athlete.birthdate = athleteDto.birthdate;
        athlete.contact = athleteDto.contact;
        athlete.ParentId = athleteDto.parentId;
        athlete.AthleteTypeId = athleteDto.athleteTypeId;
        athlete.PlaceId = athleteDto.placeId;
        athlete.UserId = athleteDto.userId;
        athlete.CoachId = athleteDto.coachId;
        athlete.FederationId = athleteDto.federationId;
        athlete.PlanId = athleteDto.planId;

        return athlete;
    }

    public static Equipa CEquipa(this CreateEquipa equipaDto)
    {
        Equipa equipa = new();  

        equipa.name = equipaDto.name; 
        equipa.local = equipaDto.local;
        equipa.coachId = equipaDto.coachId;
        equipa.clubId = equipaDto.clubeId;


        return equipa;
    }

    public static ConAtletaEqui ConAtEq(this CreateConvAtletaEquiDto conviteAE)
    {
        ConAtletaEqui conAtletaEqui = new();

        conAtletaEqui.IdEquipa = conviteAE.id_equipa;
        conAtletaEqui.IdAthlete = conviteAE.id_athelete;

        return conAtletaEqui;

    }

    public static ConCoachEqui ConCoachEq(this CreateConvCoachEquiDto conviteTE)
    {
        ConCoachEqui conCoachEqui = new();

        conCoachEqui.IdEquipa = conviteTE.idEquipa;
        conCoachEqui.IdCoach = conviteTE.idCoach;

        return conCoachEqui;

    }

    public static AddAtletaRace AddAtR(this CreateAddAtletaRaceDto adicionarAR)
    {
        AddAtletaRace addAtletaRace = new();

        addAtletaRace.IdAtleta = adicionarAR.id_atleta;
        addAtletaRace.RaceId = adicionarAR.raceId;

        return addAtletaRace;

    }

    public static Route AsRoute(this CreateRoutePeopleDto dto)
    {
        Route output = new();

        output.userId = dto.userId;
        output.description = dto.Description;
        output.placeId = dto.placeId;
        output.routeTypeId = dto.routeTypeId;
        output.dateTime = dto.dateTime;
        output.estimatedTime = dto.estimatedTime;
        output.distance = dto.distance;

        return output;
    }

    public static List<RoutePeopleInvited> AsListRoutePeopleInvited(this CreateRoutePeopleDto dto, int routeId)
    {
        List<RoutePeopleInvited> output = new();
        
        var list = dto.people;

        foreach(var person in list)
        {
            output.Add(new RoutePeopleInvited()
            {
                userId = person,
                routeId = routeId
            });
        }

        return output;
    }

    public static RoutePeopleInvited AsRoutePeopleInvite(this GetInviteToRouteDto dto)
    {
        RoutePeopleInvited output = new();

        output.userId = dto.userId;
        output.routeId = dto.routeId;

        return output;
    }

    public static Trainings AsTraining(this CreateTrainingWithInvitesDto trainingDto)
    {
        Trainings train = new();

        train.Equipaid = trainingDto.teamId;
        train.Coachid = trainingDto.trainerId;
        train.name = trainingDto.name;
        train.dateTime = trainingDto.dateTime;
        train.EstimatedTime = trainingDto.estimatedTime;
        train.Distance = trainingDto.distance;
        train.PlaceId = trainingDto.placeId;
        train.TrainingTypeId = trainingDto.trainingTypeId;
        train.PlanId = trainingDto.planId;

        return train;
    }

    public static List<TrainingInvites> AsListTrainingInvites(this CreateTrainingWithInvitesDto dto , int trainingId)
    {
        List<TrainingInvites> output = new();

        var list = dto.athleteId;

        foreach (var athleteId in list)
        {
            output.Add(new TrainingInvites()
            {
                TrainingsId = trainingId,
                athleteId = athleteId,
                confirmation = false
            });
        }

        return output;
    }

    public static TrainingInvites AsTrainingAthletesInvite(this GetInviteToTrainingDto dto)
    {
        TrainingInvites output = new();

        output.TrainingsId = dto.trainingId;
        output.athleteId = dto.athleteId;

        return output;
    }

}