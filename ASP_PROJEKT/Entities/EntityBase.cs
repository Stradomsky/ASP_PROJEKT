﻿using System;

namespace ASP_PROJEKT.Entities
{
    public abstract class EntityBase
    {
        public int Id { get; set; }
        public DateTime CreationDate { get; set; }

        public EntityBase()
        {
            CreationDate = DateTime.Now;
        }
    }
}
