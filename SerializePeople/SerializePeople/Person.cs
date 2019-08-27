using System;
using System.IO;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace SerializePeople
{
    [Serializable]
    class Person : IDeserializationCallback, ISerializable
    {
        private string _name;
        private DateTime _birthDate;
        private Gender _gender;
        [NonSerialized()] private int _age;


        public Person()
        {

        }

        public Person(string name, DateTime birthDate, Gender gender)
        {
            _name = name;
            _birthDate = birthDate;
            _gender = gender;
        }

        public string Name { get; set; }
        public Gender Gender { get; set; }
        public DateTime BirthDate { get; set; }
        
        public int Age { get; set; }

        public int CalculateAge()
        {
            var today = DateTime.Today;

            var age = today.Year - _birthDate.Year;

            if (_birthDate.Date > today.AddYears(-age))
                age--;

            return age;
        }

        public override string ToString()
        {
            return "Name: " + Name + "Age: " + Age + "Gender: " + Gender;
        }

        public void Serialize(string output)
        {
            string personDetails = "Name: " + Name + "Age: " +Age + "Gender: " + Gender;
            FileStream fs = new FileStream(output , FileMode.Create);
            BinaryFormatter formatter = new BinaryFormatter();
            formatter.Serialize(fs, personDetails);
            fs.Close();
            
        }

        public void Deserialize()
        {
            Person person = new Person();
            FileStream fs = new FileStream("test.dat", FileMode.Open);

            BinaryFormatter formatter = new BinaryFormatter();

            person = (Person)formatter.Deserialize(fs);

            fs.Close();
        }

        public void OnDeserialization(object sender)
        {
            var today = DateTime.Today;

            var age = today.Year - _birthDate.Year;

            if (_birthDate.Date > today.AddYears(-age))
                age--;

            _age = age;
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Name", _name);
            info.AddValue("Gender", _gender);
            info.AddValue("BirthDay", _birthDate);

        }

        public Person(SerializationInfo info, StreamingContext context)
        {
            Name = (string)info.GetValue("Name", typeof(string));
            Gender = (Gender)info.GetValue("Gender", typeof(Gender));
            BirthDate = (DateTime)info.GetValue("BirthDay", typeof(DateTime));

        }
    }    
}
