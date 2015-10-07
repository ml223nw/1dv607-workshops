using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoatClub.View
{
    class Menu
    {
        public void MenuShow()
        {
            Console.WriteLine("------------------------------------");
            Console.WriteLine("--------------BOAT CLUB-------------");
            Console.WriteLine("------------------------------------");
            Console.WriteLine();
            Console.WriteLine("[1] Add a new member");
            Console.WriteLine("[2] Delete a member");
            Console.WriteLine("[3] View / Edit members");
            Console.WriteLine("[4] View all members");
            Console.WriteLine();
            Console.WriteLine("Press any key to quit");
        }

        public void MemberChoices()
        {
            Console.WriteLine("[1] Edit member");
            Console.WriteLine("[2] Add a new boat");
            Console.WriteLine("[3] Edit boat");
            Console.WriteLine("[4] Delete boat");
            Console.WriteLine();
            Console.WriteLine("Press any key to return to main manu..\n");
        }

    
        public void EnterName()
        {
            Console.Write("Name of member: ");
        }

        public void EnterPersonalNumber()
        {
            Console.Write("Personal number: ");
        }

        public void DeleteMember(List<Model.Member> memberlist)
        {
            Console.Clear();
            ListMembers(memberlist);
            Console.WriteLine("\nTo select a member, input the name digit. Press Enter to confirm");

        }

        public void ListingMembersMessage()
        {
            Console.WriteLine("To select a member, input the name digit. Press Enter to confirm");
            Console.WriteLine();
        }

        public void ListMembers(List<Model.Member> memberlist)
        {
            string output;
            int line = 1;

            foreach (Model.Member member in memberlist)
            {
                output = string.Format("{2}: {0}\nPersonal number: {1}\nMember ID = {3}\nTotal boats: {4}\n"
                , member.Name, member.socialSecurityNr, line, member.Id.ToString(), member.Boats.Count);
                line++;
                Console.WriteLine(output);
            }
        }

        public void ShowMember(Model.Member member)
        {            
            string output = String.Format("Name: {0}\nPersonal number: {1}\nMember ID: {2}\nTotal boats: {3}\n"
            , member.Name, member.socialSecurityNr, member.Id, member.Boats.Count);
            int line = 1;

            foreach (Model.Boat boat in member.Boats)
            {
                output += String.Format("Boat: {2} | Type: {0} | Length: {1}\n", boat.BoatType, boat.Length, line);
                line++;
            }
            Console.WriteLine();
            Console.WriteLine(output);
        }

        public void ShowBoat(Model.Boat.Type type, float length)
        {
            Console.WriteLine("\n\nType: {0} | Length: {1}\n", type, length);
        }

        public void ListBoatTypes(Object value, int position)
        {
            string output = String.Format("{0}: {1}", position, value);
            Console.WriteLine(output);
        }

        public void BoatLengthMessage()
        {
            Console.WriteLine("Only integer numbers allowed");
        }

        public void ChangeBoatMessage()
        {
            Console.WriteLine("Select boat to edit");
            Console.WriteLine("Press any key to go back");
        }

        public void RemoveBoatMessage()
        {
            Console.WriteLine("Select boat to delete");
            Console.WriteLine("Press any key to go back");
        }

        public void EnterBoatType()
        {
            Console.WriteLine("Select type of boat");
        }

        public void EnterBoatLength()
        {
            Console.WriteLine("\nLength of the boat:");
        }

        public void ConfirmMessage()
        {
            Console.WriteLine("Are you sure you want to delete?");
            Console.WriteLine("(Y)es? / (N)o?");
        }

        public void ErrorMessage(string message)
        {
            Console.WriteLine(message);
        }

        public void ClearConsole()
        {
            Console.Clear();
        }
    }
}
