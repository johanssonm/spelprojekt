﻿namespace Spelprojekt.Entities
{
    public class Identity
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int PlayerId { get; set; }
        public Player Player { get; set; }


    }
}