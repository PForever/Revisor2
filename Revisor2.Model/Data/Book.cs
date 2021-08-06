﻿using Revisor2.Model.Infrastructure;
using System;

namespace Revisor2.Model.Data
{
    public class Book
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string ShortName { get; set; }
        public int Price { get; set; }
        public string Description { get; set; }
    }
}
