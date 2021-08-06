﻿using Revisor2.Model.Infrastructure;
using System;

namespace Revisor2.Model.Data
{
    public class Paper
    {
        public Guid Id { get; set; }
        public string Name { get; init; }
        public int Number { get; init; }
    }
}