using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace BoatClub.Model
{
    class DAL
    {
        List<Member> memberList = new List<Member>();

        public void LoadData(string filePath)
        {
            memberList.Clear();

            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream(filePath, FileMode.OpenOrCreate, FileAccess.Read);
            try
            {
                memberList = (List<Member>)formatter.Deserialize(stream);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                stream.Close();
            }
            
        }

        public void SaveData(string path)
        {
            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream(path, FileMode.Create, FileAccess.Write);

            formatter.Serialize(stream, memberList);
            stream.Close();
        }

        public void AddData(Member member)
        {
            memberList.Add(member);
        }

        public List<Member> GetMemberArray()
        {
            return memberList;
        }

    }
}
