using BikeSocialDTOs;
using BikeSocialEntities;
namespace BikeSocialBLL.Extensions;

public static class Extensions
{
    //public static User AsUserDto(this GetUserDto gud)
    //{
    //    return new User(gud.username, gud.password);
    //}

    public static Trainings AsTraining(this CreateTrainingDto trainingDto)
    {
        Trainings train = new();

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
}