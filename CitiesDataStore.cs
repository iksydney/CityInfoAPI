using CityInfoAPI.Models;

namespace CityInfoAPI
{
    public class CitiesDataStore
    {
        public List<CityDto> Cities{ get; set; }
        //public static CitiesDataStore Current { get; } = new CitiesDataStore();
        public CitiesDataStore()
        {
            Cities = new List<CityDto>
            {
                new CityDto()
                {
                    Id = 1,
                    Name = "Umuahia",
                    Description = "The Abia Tower",
                    PointsOfInterest = new List<PointOfInterestDto>()
                    {
                        new PointOfInterestDto()
                        {
                            Id=1,
                            Name="The one that has round about",
                            Description="The most undecorated park in umuahia"
                        },
                        new PointOfInterestDto()
                        {
                            Id=2,
                            Name="The Market",
                            Description="The most unclean market in Nigeria",

                        },
                    }
                },
                new CityDto()
                {
                    Id = 2,
                    Name = "Lagos",
                    Description = "The Three wise men",
                    PointsOfInterest = new List<PointOfInterestDto>()
                    {
                        new PointOfInterestDto()
                        {
                            Id=1,
                            Name="Magodo",
                            Description="Where the rich converge"
                        },
                        new PointOfInterestDto()
                        {
                            Id=2,
                            Name="Supermarket",
                            Description="Buy and sell",

                        },
                    }
                },
                new CityDto()
                {
                    Id = 3,
                    Name = "Benin",
                    Description = "The Oba Palace",
                    PointsOfInterest = new List<PointOfInterestDto>()
                    {
                        new PointOfInterestDto()
                        {
                            Id=1,
                            Name="Agirks",
                            Description="The love of christ"
                        },
                        new PointOfInterestDto()
                        {
                            Id=2,
                            Name="Lively",
                            Description="Once more again",

                        },
                    }
                },
            };
        }
    }
}
