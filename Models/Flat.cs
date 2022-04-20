﻿namespace Apartment_Management.Models
{

    public enum FlatSize { 
        ONE_PLUS_ONE,
        TWO_PLUS_ONE,
        THREE_PLUS_ONE,
        FOUR_PLUS_ONE
    }

    public class Flat
    {
        public int FlatID { get; set; }
        public string Block { get; set; }
        public bool IsFull { get; set; }
        public FlatSize FlatSize { get; set; }
        public int Floor { get; set; }
        public int DoorNum { get; set; }
        public int UserID { get; set; }
        public User User { get; set; }

    }
}
