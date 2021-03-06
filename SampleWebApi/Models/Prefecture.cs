﻿using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace SampleWebApi.Models
{
    public partial class Prefecture
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public static void Initialize(DbContext context)
        {
            var t = context.Set<Prefecture>();
            if (!t.Any())
            {
                t.AddRange(
                    new Prefecture() { Name = "北海道" },
                    new Prefecture() { Name = "青森県" },
                    new Prefecture() { Name = "東京都" },
                    new Prefecture() { Name = "静岡県" },
                    new Prefecture() { Name = "沖縄県" }
                    );
                context.SaveChanges();
            }
        }

    }
}
