using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BoatClub.Model
{
    [Serializable]
    class Member
    {
        private string _name;
        private string _ssn;
        private string _id;
        private List<Boat> _boats = new List<Boat>();
        Regex RegExForValidation = new Regex(@"^(\d{6}|\d{8})[-|(\s)]{0,1}\d{4}$");

        public string Name
        {
            get
            {
                return _name;
            }
            
            set
            {
                if (value == "")
                {
                    throw new Exception("Name must contain at least one character");
                }
                _name = value;
            }
        }

        public string socialSecurityNr
        {
            get
            {
                return _ssn;
            }

            set
            {
                if (ValidateSSN(value) && value.Trim() == "")
                {
                    throw new Exception("A valid personal number is required");
                }
                _ssn = value;
            }
        }

        public string Id
        {
            get
            {
                return _id;
            }

            set
            {
                _id = value;
            }
        }

        public List<Boat> Boats
        {
            get
            {
                return _boats;
            }
        }

        public Member(string name, string ssn)
        {
            Name = name;
            socialSecurityNr = ssn;        
        }

        public void AddBoat(Boat boat)
        {
            _boats.Add(boat);
        }        

        public bool ValidateSSN(string ssn)
        {
            Match match = RegExForValidation.Match(ssn);
            if (match.Success)
            {
                return false;
            }
            return true;
        }
    }
}
