﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_Manager
{
    // Класс для задач ENTITY FRAMEWORK
    public class STask
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Date { get; set; }
        public string Status { get; set; }
        public int Priority { get; set; }
        public string Deadline { get; set; }

    }
}