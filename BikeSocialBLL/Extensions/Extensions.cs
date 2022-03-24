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
}