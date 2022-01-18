using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace CompositeAndIteratorAndProxyDP
{
    #region Iterator DP Classes

    public class Place
    {
        public string CityName { get; set; }
        public string State { get; set; }

        public Place(string name, string state)
        {
            CityName = name;
            State = state;
        }
    }

    public interface IIterator<Place>
    {
        Place NextPlace { get; }
        bool HasNext();
    }

    public interface ICarrier<Place>
    {
        IIterator<Place> CreatIterator();
    }

    public class PlaceCarrier : ICarrier<Place>
    {
        public List<Place> Places { get; } = new List<Place>();
        public int PlaceCount { get => Places.Count; }

        public void AddPlace(Place place) => Places.Add(place);
        public IIterator<Place> CreatIterator()
        {
            return new PlaceIterator(this);
        }
    }

    public class PlaceIterator : IIterator<Place>
    {
        private readonly PlaceCarrier placeCarrier;
        public PlaceIterator(PlaceCarrier _placeCarrier)
        {
            placeCarrier = _placeCarrier;
        }

        private int NowIndex = 0;
        public Place NextPlace { get; private set; }
        public bool HasNext()
        {
            if (NowIndex < placeCarrier.PlaceCount)
            {
                NextPlace = placeCarrier.Places[NowIndex++];
                return true;
            }
            else
            {
                return false;
            }
        }
    }

    public class ListPlace : ObservableCollection<Place>
    {
        public ListPlace()
        {
            PlaceCarrier pc = new PlaceCarrier();

            pc.AddPlace(new Place("Seattle", "WA"));
            pc.AddPlace(new Place("Redmond", "WA"));
            pc.AddPlace(new Place("Bellevue", "WA"));
            pc.AddPlace(new Place("Kirkland", "WA"));
            pc.AddPlace(new Place("Portland", "OR"));
            pc.AddPlace(new Place("San Francisco", "CA"));
            pc.AddPlace(new Place("Los Angeles", "CA"));
            pc.AddPlace(new Place("San Diego", "CA"));
            pc.AddPlace(new Place("San Jose", "CA"));
            pc.AddPlace(new Place("Santa Ana", "CA"));
            pc.AddPlace(new Place("Bellingham", "WA"));
            pc.AddPlace(new Place("Tacoma", "WA"));
            pc.AddPlace(new Place("Albany", "OR"));

            var iterator = pc.CreatIterator();

            while (iterator.HasNext())
            {
                Add(iterator.NextPlace);
            }
        }
    }
    #endregion
}