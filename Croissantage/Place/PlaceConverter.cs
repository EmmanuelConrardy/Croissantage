using System;

namespace Croissantage
{
    public static class PlaceConverter
    {
        public static Place Convert(string placeToConvert)
        {
            Place place;
            if (Enum.TryParse(placeToConvert, out place))
                return place;

            throw new ArgumentException($"{placeToConvert} doesn't exist");
        }
    }
}
