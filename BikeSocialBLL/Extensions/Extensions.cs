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
}