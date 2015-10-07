using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoatClub.Model
{
    [Serializable]
    class Boat
    {
        public enum Type
        {
            Sailboat = 1,
            Motorsailer = 2,
            Kayak = 3,
            Canoe = 4,
            Other = 5,
            None
        }

        private Type _boatType;
        private float _length;

        public float Length
        {
            get
            {
                return _length;
            }

            set
            {
                if (value < 1)
                {
                    throw new Exception("Length must be bigger than 0");
                }
                _length = value;
            }
        }

        public Type BoatType
        {
            get
            {
                return _boatType;
            }

            set
            {
                if (value == Type.None)
                {
                    throw new Exception("Boat type does not exist");
                }
                _boatType = value;
            }
        }

        internal View.Menu Menu
        {
            get
            {
                throw new System.NotImplementedException();
            }

            set
            {
            }
        }

        public Boat(Type type, float length)
        {
            BoatType = type;
            Length = length;
        }

    }
}
