using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoatClub.Controller
{
    class Controller
    {
        public enum MakeChanges
        {
            value,
        }

        private const string filePath = "BoatClub.fil";
        Model.DAL listOfMembers = new Model.DAL();
        View.Menu MenuView = new View.Menu();

        internal Model.Member Member
        {
            get
            {
                throw new System.NotImplementedException();
            }

            set
            {
            }
        }

        internal Model.Boat Boat
        {
            get
            {
                throw new System.NotImplementedException();
            }

            set
            {
            }
        }

        public void Run()
        {
            listOfMembers.LoadData(filePath);
            bool isLooping = true;

            do
            {
                MenuView.ClearConsole();
                MenuView.MenuShow();
                switch (HandleReadKey())
                {
                    case 1:
                        CreateMember();
                        break;
                    case 2:
                        DeleteMember(listOfMembers.GetMemberArray());
                        break;
                    case 3:
                        ListCompactMembers(listOfMembers.GetMemberArray());
                        break;
                    case 4:
                        ListVerboseMembers(listOfMembers.GetMemberArray());
                        break;
                    default:
                        listOfMembers.SaveData(filePath);
                        isLooping = false;
                        break;
                }

            } while (isLooping == true);

        }

        public void MemberMenu(Model.Member member)
        {
            bool isMemberMenu = true;

            do
            {
                MenuView.ClearConsole();
                MenuView.ShowMember(member);
                MenuView.MemberChoices();

                switch (HandleReadKey())
                {
                    case 1:
                        ChangeMember(member);
                        break;
                    case 2:
                        AddBoat(member);
                        break;
                    case 3:
                        ChangeBoat(member);
                        break;
                    case 4:
                        DeleteBoat(member);
                        break;
                    default: isMemberMenu = false;
                        break;
                }
            } while (isMemberMenu == true);
        }

        public void CreateMember()
        {
            try
            {
                MenuView.ClearConsole();
                string name = HandleMemberInputName();
                string personalNumber = HandleMemberPersonalNumber();
                Model.Member member = new Model.Member(name, personalNumber);

                member.Id = UniqueRandomId();
                listOfMembers.AddData(member);
            }
            catch (Exception e)
            {
                MenuView.ErrorMessage(e.Message);
                Console.ReadKey();
            }
        }

        public void ListCompactMembers(List<Model.Member> memberlist)
        {
            MenuView.ClearConsole();
            MenuView.ListingMembersMessage();
            MenuView.ListMembers(memberlist);

            int valueOfCompactMembersLine = HandleReadLine();

            if (valueOfCompactMembersLine != 0 && valueOfCompactMembersLine <= memberlist.Count)
            {
                var member = memberlist[valueOfCompactMembersLine - 1];
                MemberMenu(member);
            }
            else
            {
                MenuView.ClearConsole();
            }

        }

        public void ListVerboseMembers(List<Model.Member> memberlist)
        {
            MenuView.ClearConsole();

            foreach (var member in memberlist)
            {
                MenuView.ShowMember(member);
            }
            Console.ReadKey();
        }


        public void ChangeMember(Model.Member member)
        {
            try
            {
                MenuView.ClearConsole();
                MenuView.ShowMember(member);
                string name = HandleMemberInputName();
                string personalNr = HandleMemberPersonalNumber();

                member.Name = name;
                member.socialSecurityNr = personalNr;
                MenuView.ClearConsole();
            }
            catch (Exception e)
            {
                MenuView.ErrorMessage(e.Message);
                Console.ReadKey();
            }
        }

        public void DeleteMember(List<Model.Member> memberlist)
        {
            MenuView.DeleteMember(memberlist);
            int valueOfDeleteMemberLine = HandleReadLine();

            if (valueOfDeleteMemberLine != 0 && valueOfDeleteMemberLine <= memberlist.Count)
            {
                memberlist.RemoveAt(valueOfDeleteMemberLine - 1);
                MenuView.ClearConsole();
            }
            else
            {
                MenuView.ErrorMessage("Something went wrong");
                Console.ReadKey();
            }

        }

        public void ListBoatTypes()
        {
            int valueOfBoatTypesLine = 1;
            var boatArray = Enum.GetValues(typeof(Model.Boat.Type));

            foreach (var type in boatArray)
            {
                if (valueOfBoatTypesLine < boatArray.Length)
                {
                    MenuView.ListBoatTypes(type, valueOfBoatTypesLine);
                    valueOfBoatTypesLine++;
                }
            }
        }

        public void AddBoat(Model.Member member)
        {
            MenuView.ClearConsole();
            Model.Boat.Type boatTypes = Model.Boat.Type.None;
            float valueOfBoatType = 0;

            MenuView.ShowMember(member);
            ListBoatTypes();

            try
            {
                MenuView.EnterBoatType();
                int boatValue = HandleReadKey();
                boatTypes = HandleBoatType(boatValue);

                MenuView.EnterBoatLength();
                string floatValue = Console.ReadLine();
                valueOfBoatType = HandleBoatLength(floatValue);
                member.AddBoat(new Model.Boat(boatTypes, valueOfBoatType));
            }
            catch (Exception e)
            {
                MenuView.ErrorMessage(e.Message);
                Console.ReadKey();
            }

        }

        public void ChangeBoat(Model.Member member)
        {
            MenuView.ShowMember(member);
            MenuView.ChangeBoatMessage();
            Model.Boat boat;

            int value = HandleReadLine();

            if (value != 0 && member.Boats.Count != 0)
            {
                boat = member.Boats[value - 1];
                MenuView.ShowBoat(boat.BoatType, boat.Length);
                ListBoatTypes();

                MenuView.EnterBoatType();
                int boatValue = HandleReadKey();
                Model.Boat.Type boatTypes = HandleBoatType(boatValue);

                MenuView.EnterBoatLength();
                string floatValue = Console.ReadLine();
                float boatLength = HandleBoatLength(floatValue);

                boat.BoatType = boatTypes;
                boat.Length = boatLength;
            }

        }

        public void DeleteBoat(Model.Member member)
        {
            MenuView.ShowMember(member);
            MenuView.RemoveBoatMessage();
            Model.Boat boat;

            int value = HandleReadLine();
            if (value != 0 && value <= member.Boats.Count)
            {
                boat = member.Boats[value - 1];
                MenuView.ShowBoat(boat.BoatType, boat.Length);
                MenuView.ConfirmMessage();
                string change = Console.ReadKey().KeyChar.ToString();
                if (change == Controller.MakeChanges.value.ToString())
                {
                    member.Boats.RemoveAt(value - 1);

                }
                else if (change != Controller.MakeChanges.value.ToString())
                {
                    return;
                }
            }
        }

        public int HandleReadKey()
        {
            string key = Console.ReadKey().KeyChar.ToString();
            int value;
            int.TryParse(key, out value);
            return value;
        }

        public int HandleReadLine()
        {
            string key = Console.ReadLine();
            int value;
            int.TryParse(key, out value);
            return value;
        }

        public Model.Boat.Type HandleBoatType(int boatValue)
        {
            foreach (int i in Enum.GetValues(typeof(Model.Boat.Type)))
            {
                if (i == boatValue)
                {
                    return (Model.Boat.Type)Enum.ToObject(typeof(Model.Boat.Type), boatValue);
                }
            }
            return Model.Boat.Type.None;
        }

        public float HandleBoatLength(string inputLength)
        {
            try
            {
                return Convert.ToSingle(inputLength);
            }
            catch (Exception)
            {
                MenuView.BoatLengthMessage();
            }

            return 0;
        }

        public string HandleMemberInputName()
        {
            MenuView.EnterName();
            string name = Console.ReadLine();
            return name;
        }

        public string HandleMemberPersonalNumber()
        {
            MenuView.EnterPersonalNumber();
            string personalNumber = Console.ReadLine();
            return personalNumber;
        }

        public string UniqueRandomId()
        {
            int id = 0;
            bool statement = true;
            Random randomNumber = new Random();

            do
            {
                id = randomNumber.Next(int.MaxValue);
                foreach (var member in listOfMembers.GetMemberArray())
                {
                    if (id.ToString() == member.Id)
                    {
                        statement = true;
                        break;
                    }
                }
                statement = false;
            } while (statement);

            return id.ToString();
        }

    }

}
