﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab.MVC.Models
{
    public class MostrarModel
    {
        public int UserId { get; set; }
        public int Id { get; set; }
        public string Title { get; set; }
        public bool Completed { get; set; }
    }
}