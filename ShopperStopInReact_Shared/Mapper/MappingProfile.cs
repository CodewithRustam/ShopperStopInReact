using AutoMapper;

namespace ShopperStopInReact_Shared.Maper
{
    public class MappingProfile
    {
        public static void MapObjectData<TSource, TDestination>(TSource source, TDestination destination)
        {
            Type sourceType = typeof(TSource);
            Type destinationType = typeof(TDestination);

            var sourceProperties = sourceType.GetProperties();
            var destinationProperties = destinationType.GetProperties();

            foreach (var sourceProperty in sourceProperties)
            {
                var destinationProperty = destinationProperties.FirstOrDefault(p => p.Name == sourceProperty.Name && p.PropertyType == sourceProperty.PropertyType);

                if (destinationProperty != null && destinationProperty.CanWrite)
                {
                    var value = sourceProperty.GetValue(source);
                    destinationProperty.SetValue(destination, value);
                }
            }
        }
    }
}
