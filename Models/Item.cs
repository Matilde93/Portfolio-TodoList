﻿namespace ToDoList.Models
{
    public class Item
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }


        public void ValidateName()
        {
            if(Name == null) throw new ArgumentNullException();
            if(Name.Length < 2) { throw new ArgumentException(); }
        }

        public override string ToString()
        {
            return $"Id {Id}: {Name} - {Description}";
        }
    }
}
